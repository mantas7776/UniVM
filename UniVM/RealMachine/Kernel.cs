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
            BaseSystemProcess startStop = new StartStop(100, kernelStorage);
            startStop.run();
            
        }

    }
}
