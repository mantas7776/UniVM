using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UniVM
{
    class IdleProcess : BaseSystemProcess
    {
        public IdleProcess(KernelStorage kernelStorage) : base(1, kernelStorage) { }
        public override void run()
        {
            switch(IC)
            {
                case 0:
                    Debug.Print("SleepProcess: Sleeping for 200 ms");
                    System.Threading.Thread.Sleep(200);
                    this.IC = 0;
                    break;
            }
        }
    }
}
