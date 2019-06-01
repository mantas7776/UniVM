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
        }

        private void handleSiInt(SiInt intNr)
        {
            Program program = process.virtualMachine.program;
            switch (intNr)
            {
                case SiInt.Halt:
                    {
                        process.destroyVM();
                        break;
                    }
                case SiInt.OpenFileHandle:
                    {
                        byte[] memoryBytes = program.memAccesser.getAllBytes();
                        string fileName = Util.AsciiBytesToString(memoryBytes, checked((int)(program.registers.B + program.registers.DS)));

                        kernelStorage.resources.add(new CreateHandleRequest(process.id, fileName));
                        break;
                    }
                case SiInt.WriteToHandle:
                    {

                        uint bytesToWriteAmount = program.registers.CX;
                        if (bytesToWriteAmount == 0xFFFFFFFF)
                            bytesToWriteAmount = 4;

                        byte[] bytesToWrite = program.memAccesser.readFromAddr(program.registers.DS + program.registers.A, bytesToWriteAmount);

                        this.kernelStorage.resources.add(new WriteHandleRequest(process.id, (int)program.registers.B, bytesToWrite));
                        break;
                    }
                case SiInt.CloseFileHandle:
                    {
                        kernelStorage.resources.add(new HandleOperationRequest(process.id, HandleOperationType.Close, (int)program.registers.B, process.programName));
                        break;
                    }
                case SiInt.ReadFromHandle:
                    {
                        this.kernelStorage.resources.add(new ReadHandleRequest(process.id, (int)program.registers.B, (int)program.registers.CX, process.programName));
                        break;
                    }
                case SiInt.DeleteFile:
                    {
                        this.kernelStorage.resources.add(new HandleOperationRequest(process.id, HandleOperationType.Delete, (int)program.registers.B, process.programName));
                        break;
                    }
                case SiInt.MountBattery:
                    {
                        this.kernelStorage.resources.add(
                            new BaseHandleResource(ResType.BaseHandleResource, HandleOperationType.CreateBatteryHandle, process.id, -1)
                        );
                        break;
                    }
                case SiInt.SeekHandle:
                    {
                        this.kernelStorage.resources.add(
                            new SetHandleSeekRequest(process.id, (int)program.registers.B, (int)program.registers.CX)
                        );
                        break;
                    }
                case SiInt.PrintConsoleRegA:
                    {
                        string numbers = program.registers.A.ToString() + "\n";
                        this.kernelStorage.resources.add(new WriteHandleRequest(process.id, 0, Encoding.ASCII.GetBytes(numbers)));
                        break;
                    }
                default:
                    throw new NotImplementedException();
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
                default:
                    throw new NotImplementedException();
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
                        program.registers.SI = SiInt.None;
                        break;
                    }
                case ResType.ReadHandleResponse:
                    {
                        Program program = process.virtualMachine.program;
                        ReadHandleResponse response = (ReadHandleResponse)resource;
                        if (response.readBytes.Length > response.bytesRequested)
                        {
                            program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, response.readBytes, response.bytesRequested);
                            program.registers.CX = response.bytesRequested;
                            program.registers.SI = SiInt.None;
                        }
                        else
                        {
                            uint len = checked((uint)response.readBytes.Length);
                            program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, response.readBytes, len);
                            program.registers.CX = len;
                        }

                        program.registers.A = response.status;
                        program.registers.SI = SiInt.None;

                        break;
                    }
                case ResType.WriteHandleResponse:
                    {
                        Program program = process.virtualMachine.program;
                        WriteHandleResponse writeHandleResponse = (WriteHandleResponse)resource;
                        program.registers.A = writeHandleResponse.status;
                        program.registers.CX = writeHandleResponse.amountWritten;
                        program.registers.SI = SiInt.None;
                        break;
                    }
                case ResType.CloseHandleResponse:
                case ResType.DeleteHandleResponse:
                case ResType.SeekHandleResponse:
                    {
                        Program program = process.virtualMachine.program;
                        program.registers.SI = SiInt.None;
                        // do nothing - just wait and release
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }

        }
    }
}
