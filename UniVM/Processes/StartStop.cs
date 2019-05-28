using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class StartStop : BaseSystemProcess
    {
        private uint IC = 0;
        private KernelStorage kernelStorage;

        public StartStop(int priority, KernelStorage kernelStorage) : base(priority) {
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            for(int i = 0; i < Constants.BLOCKS_AMOUNT; i++) kernelStorage.resources.add(new Resource(ResType.Memory, this.id, true));

            kernelStorage.resources.add(new Resource(ResType.Storage, this.id, true));
            //kernelStorage.resources.add(new ProgramStart(this.id));

            kernelStorage.processes.add(new ResourceScheduler(99, kernelStorage));
            kernelStorage.processes.add(new VMScheduler(kernelStorage.memory));
            kernelStorage.processes.idle = new IdleProcess();

            this.resourceHolder.request(ResType.OSExit);
                

            kernelStorage.processes.killAll();
            kernelStorage.resources.clear();
        }
    }
}
