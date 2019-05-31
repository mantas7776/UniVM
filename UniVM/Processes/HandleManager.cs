using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class HandleManager : BaseSystemProcess
    {
        public HandleManager(KernelStorage kernelStorage, int creatorId) : base(50, kernelStorage, creatorId) { }

        private void setDevice(Handle handle, int status)
        {
            if (handle is FileHandle)
                this.kernelStorage.channelDevice.storage = status;
            else if (handle is ConsoleDevice)
                this.kernelStorage.channelDevice.storage = status;
            else
                throw new NotImplementedException();

        }

        public void createFileHandle(CreateHandleRequest request)
        {
            //wait until realeased
            //if (this.kernelStorage.handles.isFileTaken(request.fileName))
              //  return;

            StorageFile file = StorageFile.OpenOrCreate(this.kernelStorage.virtualHdd, request.fileName);


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

        private void readHandleFile(FileHandle hndl,ReadHandleRequest request)
        {
            this.kernelStorage.channelDevice.storage = 1;
            byte[] readBytes = new byte[request.amount];

            Resource response;
            uint amountRead = 0;
            try
            {
                for (uint i = 0; i < request.amount; i++)
                {
                    amountRead++;
                    readBytes[i] = hndl.read();
                }
                response = new ReadHandleResponse(this.id, readBytes, 0, checked((uint)request.amount), request.createdByProcess);
                //program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, readBytes);
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("Reading file out of bounds"))
                    throw e;

                response = new ReadHandleResponse(this.id, readBytes, 1, checked((uint)request.amount), request.createdByProcess);
                //program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, readBytes);
            }


            this.kernelStorage.channelDevice.storage = 0;
            kernelStorage.resources.add(response);
            request.release();
        }

        private void readHandleConsole(ConsoleDevice hndl, ReadHandleRequest request)
        {
            this.kernelStorage.channelDevice.console = 1;
            byte[] readBytes = hndl.readLine();

            Resource response;
            if (readBytes.Length > request.amount)
            {

                //program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, readBytes, program.registers.CX);
                //program.registers.A = 1;
                response = new ReadHandleResponse(this.id, readBytes, 1, checked((uint)request.amount), request.createdByProcess);
            }
            else
            {
                uint len = checked((uint)readBytes.Length);
                response = new ReadHandleResponse(this.id, readBytes, 0, checked((uint)request.amount), request.createdByProcess);
                //program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, readBytes, len);
                //program.registers.CX = len;
                //program.registers.A = 0;
            }

            this.kernelStorage.channelDevice.console = 0;
            //program.registers.A = 0;
            //program.registers.SI = SiInt.None;
            kernelStorage.resources.add(response);
            request.release();
        }

        private void readHandle(ReadHandleRequest request)
        {

            int bytesToReadAmount = request.amount;
            Handle hndl = this.kernelStorage.handles[request.handle];

            if (hndl is FileHandle)
                readHandleFile(hndl as FileHandle, request);
            else if (hndl is ConsoleDevice)
                readHandleConsole(hndl as ConsoleDevice, request);
            else if (hndl is Battery)
                readHandleBattery(hndl as Battery, request);

        }

        private void readHandleBattery(Battery battery, ReadHandleRequest request)
        {
            Resource response = new ReadHandleResponse(this.id, battery.getStatus(), 0, checked((uint)request.amount), request.createdByProcess);
            kernelStorage.resources.add(response);
            request.release();
        }

        private void closeHandle(HandleOperationRequest request)
        {
            this.kernelStorage.channelDevice.storage = 1;
            Handle handle = this.kernelStorage.handles[request.handle];
            this.kernelStorage.handles.remove(handle);

            if (handle is Battery)
                this.kernelStorage.channelDevice.battery = 0;

            Resource response = new HandleOperationResponse(this.id, HandleOperationType.Close, request.createdByProcess);

            this.kernelStorage.channelDevice.storage = 0;
            kernelStorage.resources.add(response);
            request.release();
        }

        private void writeBattery(WriteHandleRequest request)
        {
            Handle handle = this.kernelStorage.handles[request.handle];
            ((Battery)handle).setStatus(request.bytesToWrite[0]);
            Resource response = new WriteHandleResponse(this.id, 0, 4, request.createdByProcess);
            this.kernelStorage.resources.add(response);
            request.release();
        }

        private void writeHandle(WriteHandleRequest request)
        {
            
            Handle handle = this.kernelStorage.handles[request.handle];
            Resource response;

            if (handle is Battery)
            {
                writeBattery(request);
                return;
            }

            setDevice(handle, 1);

            uint amountWritten = 0;
            try
            {
                for (uint i = 0; i < request.bytesToWrite.Length; i++)
                {
                    amountWritten++;
                    handle.write(request.bytesToWrite[i]);
                }

                response = new WriteHandleResponse(this.id, 0, amountWritten, request.createdByProcess);
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("Writing file out of bounds"))
                    throw e;

                response = new WriteHandleResponse(this.id, 1, amountWritten, request.createdByProcess);
            }

            setDevice(handle, 0);

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
                    List<Resource> reqs = getAllResources(ResType.BaseHandleResource);
                    foreach (Resource baseReq in reqs)
                    {
                        BaseHandleResource req = baseReq as BaseHandleResource;

                        switch (req.handleResourceType)
                        {
                            case HandleOperationType.CreateFileHandle:
                                createHandle(req as CreateHandleRequest);
                                break;
                            case HandleOperationType.Read:
                                readHandle(req as ReadHandleRequest);
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
                            case HandleOperationType.CreateBatteryHandle:
                                mountBattery(req);
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                    }
                    if (this.kernelStorage.resources.Resources
                        .Where(res => res.assignedTo == this)
                        .Count() == 0
                        ) this.IC = 0;
                    break;
            }
        }

        private void mountBattery(BaseHandleResource request)
        {
            if (this.kernelStorage.channelDevice.battery == 1)
                return;
            this.kernelStorage.channelDevice.battery = 1;
            int hndl = this.kernelStorage.handles.add(new Battery());

            Resource response = new CreateHandleResponse(this.id, hndl, request.createdByProcess, HandleType.Battery);
            kernelStorage.resources.add(response);
            request.release();
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
