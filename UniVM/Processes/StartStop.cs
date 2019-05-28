using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class StartStop : BaseSystemProcess
    {
        private KernelStorage kernelStorage;

        public StartStop(int priority, KernelStorage kernelStorage) : base(priority, kernelStorage) {
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            for(int i = 0; i < Constants.BLOCKS_AMOUNT; i++) kernelStorage.resources.add(new Resource(ResType.Memory, this.id, true));

            kernelStorage.resources.add(new Resource(ResType.Storage, this.id, true));
            //kernelStorage.resources.add(new ProgramStart(this.id));

            kernelStorage.processes.add(new ResourceScheduler(99, kernelStorage));
            kernelStorage.processes.add(new VMScheduler(kernelStorage));
            kernelStorage.processes.idle = new IdleProcess(kernelStorage);

            this.resourceHolder.request(ResType.OSExit);
                

            kernelStorage.processes.killAll();
            kernelStorage.resources.clear();
        }
    }
}
