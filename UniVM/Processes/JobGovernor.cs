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
        private VirtualMemory virtualMemory;

        public string programName;
        private KernelStorage kernelStorage;
        private VirtualMachine virtualMachine;

        public JobGovernor(string programName, KernelStorage kernelStorage) : base(ProcPriority.JobGovernor, kernelStorage)
        {
            this.programName = programName;
            this.kernelStorage = kernelStorage;
            virtualMemory = new VirtualMemory(0, this.kernelStorage.memory);
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
                    long fileSize = new System.IO.FileInfo(programName).Length;
                    if (fileSize == 0) throw new Exception($"File {programName} is empty!");

                    uint rowCount = (uint)(fileSize / Constants.BLOCK_SIZE);
                    for (int i = 0; i < rowCount; i++) this.resourceRequestor.request(ResType.Memory);
                    this.IC++;
                    break;
                case 1:
                    MemAccesser memAcceser = this.virtualMemory.reserveMemory(programName, this.getResourceTypeCount(ResType.Memory));
                    Program program = new Program(programName, memAcceser);

                    this.virtualMachine = new VirtualMachine(program, memAcceser, kernelStorage);
                    kernelStorage.processes.add(virtualMachine);

                    this.resourceRequestor.request(ResType.Interrupt);
                    this.IC++;
                    break;
                case 2:
                    Interrupt interrupt = (Interrupt)this.getFirstResource(ResType.Interrupt);
                    if (interrupt.type != IntType.Halt)
                        this.intHandler.handle(interrupt.type);
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
            this.resourceRequestor.request(ResType.NonExistent);
        }
    }
}
