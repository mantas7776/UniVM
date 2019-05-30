using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class StartStop : BaseSystemProcess
    {

        public StartStop(int priority, KernelStorage kernelStorage, int creatorId) : base(priority, kernelStorage, creatorId) {
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
                    for (int i = 0; i < Constants.BLOCKS_AMOUNT; i++) kernelStorage.resources.add(new Resource(ResType.Memory, this.id));

                    kernelStorage.resources.add(new Resource(ResType.Storage, this.id, false));
                    kernelStorage.resources.add(new ProgramStartKill(this.id, false, "code.bin"));

                    kernelStorage.processes.add(new MainProc(kernelStorage, this.id));
                    kernelStorage.processes.add(new ResourceScheduler(kernelStorage, this.id));
                    kernelStorage.processes.add(new HandleManager(kernelStorage, this.id));
                    kernelStorage.processes.idle = new IdleProcess(kernelStorage, this.id);

                    //test
                    //kernelStorage.processes.add(new Test(kernelStorage));

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
