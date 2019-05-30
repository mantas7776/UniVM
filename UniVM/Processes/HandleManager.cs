using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class HandleManager : BaseSystemProcess
    {
        public HandleManager(KernelStorage kernelStorage) : base(50, kernelStorage) { }

        public void createFileHandle(CreateHandleRequest request)
        {
            //wait until realeased
            if (this.kernelStorage.handles.isFileTaken(request.fileName))
                return;

            StorageFile file;
            try
            {
                file = StorageFile.createFile(this.kernelStorage.virtualHdd, request.fileName, 256);
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("already exists"))
                    throw e;
                file = StorageFile.Open(this.kernelStorage.virtualHdd, request.fileName);
            }
            
            FileHandle fh = new FileHandle(file);
            int hndl = this.kernelStorage.handles.add(fh);

            Resource response = new CreateHandleResponse(this.id, hndl, request.createdByProcess);

            kernelStorage.resources.add(response);
            request.release();
        }

        private void createHandle(CreateHandleRequest request)
        {
            this.kernelStorage.channelDevice.storage = 1;
            createFileHandle(request);
            this.kernelStorage.channelDevice.storage = 0;
        }

        private void readHandle(HandleOperationRequest request)
        {
            this.kernelStorage.channelDevice.storage = 1;
            Handle handle = this.kernelStorage.handles[request.handle];
            Resource response = new ReadHandleResponse(this.id, handle.read(), request.createdByProcess);

            this.kernelStorage.channelDevice.storage = 0;
            kernelStorage.resources.add(response);
            request.release();
        }

        private void closeHandle(HandleOperationRequest request)
        {
            this.kernelStorage.channelDevice.storage = 1;
            Handle handle = this.kernelStorage.handles[request.handle];
            this.kernelStorage.handles.remove(handle);
            
            Resource response = new HandleOperationResponse(this.id, HandleOperationType.Close, request.createdByProcess);

            this.kernelStorage.channelDevice.storage = 0;
            kernelStorage.resources.add(response);
            request.release();
        }

        private void writeHandle(WriteHandleRequest request)
        {
            this.kernelStorage.channelDevice.storage = 1;
            Handle handle = this.kernelStorage.handles[request.handle];
            handle.write(request.toWrite);
            Resource response = new HandleOperationResponse(this.id, HandleOperationType.Write, request.createdByProcess);
            this.kernelStorage.channelDevice.storage = 0;

            kernelStorage.resources.add(response);
            request.release();
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
                    this.resourceRequestor.request(ResType.BaseHandleResource);
                    this.IC++;
                    break;
                case 1:
                    BaseHandleResource req = getFirstResource(ResType.BaseHandleResource) as BaseHandleResource;
                    //TODO GET ALL ASSIGNED RESOURCES
                    switch (req.handleResourceType)
                    {
                        case HandleOperationType.CreateHandle:
                            createHandle(req as CreateHandleRequest);
                            break;
                        case HandleOperationType.Read:
                            readHandle(req as HandleOperationRequest);
                            break;
                        case HandleOperationType.Write:
                            writeHandle(req as WriteHandleRequest);
                            break;
                        case HandleOperationType.Close:
                            closeHandle(req as HandleOperationRequest);
                            break;
                        case HandleOperationType.Delete:
                            deleteHandle(req as HandleOperationRequest);
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    this.IC = 0;
                    break;
            }
        }

        private void deleteHandle(HandleOperationRequest request)
        {
            this.kernelStorage.channelDevice.storage = 1;
            Handle handle = this.kernelStorage.handles[request.handle];
            if (handle.GetType() != typeof(FileHandle))
                throw new Exception("Only file handles can be deleted");
            FileHandle file = (FileHandle)handle;
            string fileName = file.fileName;
            this.kernelStorage.handles.remove(handle);

            StorageFile.DeleteFile(this.kernelStorage.virtualHdd, fileName);

            Resource response = new HandleOperationResponse(this.id, HandleOperationType.Delete, request.createdByProcess);

            this.kernelStorage.channelDevice.storage = 0;
            kernelStorage.resources.add(response);
            request.release();
        }
    }
}
