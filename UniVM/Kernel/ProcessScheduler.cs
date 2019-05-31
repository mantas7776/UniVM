using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UniVM
{
    class ProcessScheduler
    {
        private KernelStorage kernelStorage;

        public ProcessScheduler(KernelStorage kernelStorage)
        {
            this.kernelStorage = kernelStorage;
        }

        public void start()
        {

            List<BaseSystemProcess> processes = kernelStorage
                .processes
                .Processes
                .Where(o => !o.resourceRequestor.blocked && o.priority > 0 )
                .OrderByDescending(o => o.priority)
                .ToList();

            foreach (var process in processes)
            {
                Debug.Print("Running: " + process.GetType());
                //GUI.ShowMainMenu();
                process.execute();
            }
            if (processes.Count == 0)
            {
                kernelStorage.processes.idle.run();
            }
        }
    }
}
