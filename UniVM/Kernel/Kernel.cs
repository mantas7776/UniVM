using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Kernel
    {
        private KernelStorage kernelStorage = new KernelStorage();

        public Kernel()
        {
            ProcessScheduler scheduler = new ProcessScheduler(kernelStorage);
            BaseSystemProcess startStop = new StartStop(100, kernelStorage, 0);
            kernelStorage.processes.add(startStop);
            while (true)
            {
                scheduler.start();
            }
        }
    }
}
