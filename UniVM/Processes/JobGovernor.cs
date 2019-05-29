using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class JobGovernor : BaseSystemProcess
    {
        private IntHandler intHandler;
        private VirtualMemory virtualMemory;

        public string programName;
        private KernelStorage kernelStorage;
        private VirtualMachine virtualMachine;

        public JobGovernor(string programName, KernelStorage kernelStorage) : base(ProcPriority.JobGovernor, kernelStorage)
        {
            this.programName = programName;
            this.kernelStorage = kernelStorage;
            virtualMemory = new VirtualMemory(0, this.kernelStorage.memory);
            intHandler = new IntHandler(this.kernelStorage, this);
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
                    MemAccesser memAcceser = this.virtualMemory.reserveMemory(this.getResourceTypeCount(ResType.Memory));
                    Program program = new Program(programName, memAcceser);

                    this.virtualMachine = new VirtualMachine(program, memAcceser, kernelStorage, this.id);
                    kernelStorage.processes.add(virtualMachine);
                    this.IC++;
                    break;
                case 2:
                    this.resourceRequestor.request(ResType.Any, this.id);
                    this.IC++;
                    break;
                case 3:
                    Resource resource = this.getFirstResource(ResType.Any);
                    if(resource.type == ResType.Interrupt)
                    {
                        this.intHandler.handleInt((Interrupt)resource);
                    } else 
                    {
                        this.intHandler.handleResponse(resource);
                    }
                    break;
                //case 4:
                //    InterruptRes interruptRes = (InterruptRes)this.getFirstResource(ResType.InterruptRes);
                //    intHandler.resHandle(InterruptRes);
                //    this.IC = 2;
                //    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public void destroyVM()
        {
            kernelStorage.processes.remove(this.virtualMachine);
            kernelStorage.resources.add(new ProgramStartKill(this.id, true, this.programName));
            this.resourceRequestor.request(ResType.NonExistent);
        }
    }
}
