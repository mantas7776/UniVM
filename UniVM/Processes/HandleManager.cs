using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM.Processes
{
    class HandleManager : BaseSystemProcess
    {
        public HandleManager(KernelStorage kernelStorage) : base(50, kernelStorage) { }

        private void createHandle(CreateHandleRequest request)
        {
            StorageFile file = StorageFile.Open(this.kernelStorage.virtualHdd, request.fileName);
            FileHandle fh = new FileHandle(file);
            this.kernelStorage.handles.add(fh);

            Resource response = new CreateHandleResponse(this.id, fh, request.createdByProcess);

            kernelStorage.resources.add(response);
        }

        private void readHandle(HandleOperationRequest request)
        {
            Resource response = new ReadHandleResponse(this.id, request.handle.read(), request.createdByProcess);

            kernelStorage.resources.add(response);
        }

        private void closeHandle(HandleOperationRequest request)
        {
            request.handle.close();
            Resource response = new HandleOperationResponse(this.id, HandleOperationType.Close, request.createdByProcess);

            kernelStorage.resources.add(response);
        }

        private void writeHandle(WriteHandleRequest request)
        {
            request.handle.write(request.toWrite);
            Resource response = new ReadHandleResponse(this.id, request.handle.read(), request.createdByProcess);

            kernelStorage.resources.add(response);
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
                        default:
                            throw new NotImplementedException();
                    }
                    
                    this.IC = 0;
                    break;
            }
        }
    }
}
