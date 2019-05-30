using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class IntHandler 
    {
        private KernelStorage kernelStorage;
        private JobGovernor process;

        public IntHandler(KernelStorage kernelStorage, JobGovernor process)
        {
            this.kernelStorage = kernelStorage;
            this.process = process;
        }

        public void handleInt(Interrupt interrupt)
        {
            Program program = process.virtualMachine.program;
            if (program.registers.SI > 0)
                handleSiInt(program.registers.SI);
            else if (program.registers.PI > 0)
                handlePiInt(program.registers.PI);
            else
                throw new Exception("Jobgovernor expected an int, but was not found inside the program.");


            //if (Enum.IsDefined(typeof(SiInt), interrupt.type) == true)
            //    handleSiInt(interrupt);
            //else if (Enum.IsDefined(typeof(PiInt), interrupt.type) == true)
            //    handlePiInt(interrupt);
            //else
            //    throw new NotImplementedException("Invalid int type was provided");
        }

        private void handleSiInt(SiInt intNr)
        {
            switch (intNr)
            {
                case SiInt.Halt:
                    {
                        process.destroyVM();
                        break;
                    }
                case SiInt.CreateFileHandle:
                    {
                        kernelStorage.resources.add(new CreateHandleRequest(process.id, process.programName));
                        break;
                    }
                case SiInt.CloseFileHandle:
                    {
                        Program program = process.virtualMachine.program;
                        kernelStorage.resources.add(new HandleOperationRequest(process.id, HandleOperationType.Close, (int)program.registers.B, process.programName));
                        break;
                    }
                case SiInt.WriteToHandle:
                    {
                        Program program = process.virtualMachine.program;
                        this.kernelStorage.resources.add(new WriteHandleRequest(process.id, (int)program.registers.B, (byte)program.registers.A));
                        break;
                    }
                case SiInt.ReadFromHandle:
                    {
                        Program program = process.virtualMachine.program;
                        this.kernelStorage.resources.add(new HandleOperationRequest(process.id, HandleOperationType.Read, (int)program.registers.B, process.programName));
                        break;
                    }
                case SiInt.DeleteFile:
                    {
                        Program program = process.virtualMachine.program;
                        this.kernelStorage.resources.add(new HandleOperationRequest(process.id, HandleOperationType.Delete, (int)program.registers.B, process.programName));
                        break;
                    }
            }

            return;
        }

        private void handlePiInt(PiInt intNr)
        {
            switch (intNr)
            {
                case PiInt.InvalidCommand:
                    process.destroyVM();
                    break;
            }

            return;
        }

        public void handleResponse(Resource resource)
        {
            switch(resource.type)
            {
                case ResType.CreateHandleResponse:
                    {
                        Program program = process.virtualMachine.program;
                        CreateHandleResponse createHandleResponse = (CreateHandleResponse)resource;
                        program.registers.B = (uint)(createHandleResponse.handle);
                        break;
                    }
                case ResType.ReadHandleResponse:
                    {
                        Program program = process.virtualMachine.program;
                        ReadHandleResponse readHandleResponse = (ReadHandleResponse)resource;
                        program.registers.A = (uint)(readHandleResponse.result);
                        break;
                    }
                case ResType.WriteHandleResponse:
                case ResType.CloseHandleResponse:
                case ResType.DeleteHandleResponse:
                    {
                        // do nothing - just wait and release
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
