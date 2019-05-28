using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM.Processes
{
    class MainProc: BaseSystemProcess
    {
        private KernelStorage kernelStorage;

        public MainProc(int priority, KernelStorage kernelStorage) : base(priority)
        {
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            switch (this.IC)
            {
                case 0:
                    resourceHolder.request(ResType.ProgramStart);
                    this.IC++;
                    break;
                case 1:
                    ProgramStart programStart = resourceHolder.getFirst(ResType.ProgramStart);
                    if(!programStart.kill)
                    {
                        ProgramStart programStart = resourceHolder.getFirst(ResType.ProgramStart);
                        kernelStorage.
                        this.IC++;
                    }
                case 2:
                    ProgramStart programStart = resourceHoldes.getFirst(ResType.ProgramStart);
                    if(programStart.kill)
                    {

                    }
                    break;                  
            }

        }
    }
}
