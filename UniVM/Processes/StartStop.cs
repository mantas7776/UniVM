using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class StartStop : BaseSystemProcess
    {

        public StartStop(int priority, KernelStorage kernelStorage) : base(priority, kernelStorage) {
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
                    for (int i = 0; i < Constants.BLOCKS_AMOUNT; i++) kernelStorage.resources.add(new Resource(ResType.Memory, this.id));

                    kernelStorage.resources.add(new Resource(ResType.Storage, this.id, false));
                    kernelStorage.resources.add(new ProgramStartKill(this.id, true, "code.bin"));

                    //kernelStorage.processes.add(new IntHandler(kernelStorage));
                    kernelStorage.processes.add(new MainProc(kernelStorage));
                    kernelStorage.processes.add(new ResourceScheduler(kernelStorage));
                    kernelStorage.processes.add(new VMScheduler(kernelStorage));
                    kernelStorage.processes.idle = new IdleProcess(kernelStorage);

                    this.resourceRequestor.request(ResType.OSExit);
                    this.IC++;
                    break;
                case 1:
                    kernelStorage.processes.killAll();
                    kernelStorage.resources.clear();
                    break;
            }

        }
    }
}
