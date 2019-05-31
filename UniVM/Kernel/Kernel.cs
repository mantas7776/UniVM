using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class Kernel
    {
        public bool run = true;
        public KernelStorage kernelStorage = new KernelStorage();
        private ProcessScheduler processScheduler;

        public Kernel()
        {
            this.processScheduler = new ProcessScheduler(kernelStorage);
            BaseSystemProcess startStop = new StartStop(100, kernelStorage, 0);
            kernelStorage.processes.add(startStop);
            this.startScheduler();
            //startStop.execute();
        }

        public void startScheduler()
        {
            processScheduler.start();
        }
    }
}
