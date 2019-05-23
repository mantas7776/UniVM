using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ProcessScheduler : BaseSystemProcess
    {
        private KernelStorage kernelStorage;

        public ProcessScheduler(KernelStorage kernelStorage) : base(-1)
        {
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            List<BaseSystemProcess> processes = kernelStorage
                .processes
                .Processes
                .Where(o => !o.resourceHolder.blocked && o.priority > 0)
                .OrderByDescending(o => o.priority)
                .ToList();

            foreach (var process in processes)
            {
                process.run();
            }
           

        }
    }
}
