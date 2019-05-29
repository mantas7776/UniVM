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
            if (Enum.IsDefined(typeof(SiInt), interrupt.type) == true)
                handleSiInt(interrupt);
            else if (Enum.IsDefined(typeof(PiInt), interrupt.type) == true)
                handlePiInt(interrupt);
            else
                throw new NotImplementedException("Invalid int type was provided");

        }

        public void handleSiInt(Interrupt interrupt)
        {
            switch ((SiInt)interrupt.type)
            {
                case SiInt.Halt:
                    {
                        process.destroyVM();
                        kernelStorage.resources.add(new ProgramStartKill(interrupt.createdByProcess, true, interrupt.programName));
                        break;
                    }
                case SiInt.CreateFileHandle:
                    {
                        CreateFileInt createFileInt = (CreateFileInt)interrupt;
                        kernelStorage.resources.add(new FileHandleRequest(process.id, createFileInt.fileName));
                        //this.kernelStorage.processes.Processes.Find(proc => proc.id == );
                        process.resourceRequestor.request(ResType.FileCreateResponse, process.id);
                        break;
                    }
            }

            return;
        }

        public void handlePiInt(Interrupt interrupt)
        {
            switch ((PiInt)interrupt.type)
            {
                case PiInt.OperandUndefined:
                    {
                        break;
                    }
            }

            return;
        }

        public void handleResponse(Resource resource)
        {
            switch(resource.type)
            {
                case ResType.CreateHandleResponse:

                    break;
                case ResType.CloseHandleResponse:
                    
                    break;
                case ResType.ReadHandleResponse:

                    break;
                case ResType.WriteHandleResponse:

                    break;
                default:
                    throw new NotFiniteNumberException();
            }

        }
    }
}
