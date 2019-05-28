﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class StartStop : BaseSystemProcess
    {
        private bool first = true;
        private KernelStorage kernelStorage;

        public StartStop(int priority, KernelStorage kernelStorage) : base(priority) {
            this.kernelStorage = kernelStorage;
        }
        public override void run()
        {
            first = false;
            kernelStorage.resources.add(new Resource(ResTypes.Memory, this.id, true));
            kernelStorage.resources.add(new Resource(ResTypes.Storage, this.id, true));
            //kernelStorage.resources.add(new ProgramStart(this.id));

            kernelStorage.processes.add(new ResourceScheduler(99, kernelStorage));
            kernelStorage.processes.add(new VMScheduler(kernelStorage.memory));
            kernelStorage.processes.idle = new IdleProcess();

            this.resourceHolder.request(ResTypes.OSExit);
                

            kernelStorage.processes.killAll();
            kernelStorage.resources.clear();
        }
    }
}
