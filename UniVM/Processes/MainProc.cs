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
                    break;
                case 1:
                    Progress = resourceHolder.
                    kernelStorage.processes.add(new JobGovernor(99, Resource.procName));
                    break;

            }

        }
    }
}
