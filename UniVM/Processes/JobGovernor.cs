using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM.Processes
{
    class JobGovernor : BaseSystemProcess
    {
        private IntHandler intHandler = new IntHandler();

        public string programName;
        private KernelStorage kernelStorage;
        private VirtualMachine virtualMachine;

        public JobGovernor(string programName, KernelStorage kernelStorage) : base(ProcPriority.JobGovernor)
        {
            this.programName = programName;
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
                    long fileSize = new System.IO.FileInfo(programName).Length;
                    if (fileSize == 0) throw new Exception($"File {programName} is empty!");

                    uint rowCount = (uint)(fileSize / Constants.BLOCK_SIZE);
                    for (int i = 0; i < rowCount; i++) this.resourceHolder.request(ResType.Memory);
                    this.IC++;
                    break;
                case 1:
                    this.virtualMachine = new VirtualMachine(programName);
                    kernelStorage.processes.add(virtualMachine);

                    this.resourceHolder.request(ResType.Interrupt);
                    this.IC++;
                    break;
                case 2:
                    ResInterrupt resInterrupt = (ResInterrupt)resourceHolder.getFirst(ResType.Interrupt);
                    if (resInterrupt.type != IntType.Halt)
                        this.intHandler.handle(resInterrupt.type);
                    else
                        this.destroyVM();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void destroyVM()
        {
            kernelStorage.processes.remove(this.virtualMachine);
            this.resourceHolder.releaseAllResources();
            this.resourceHolder.request(ResType.NonExistent);
        }
    }
}
