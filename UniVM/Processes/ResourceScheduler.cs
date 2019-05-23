using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceScheduler : BaseSystemProcess
    {
        private KernelStorage kernelStorage;

        public ResourceScheduler(int priority, KernelStorage kernelStorage) : base (priority)
        {
            this.kernelStorage = kernelStorage;
        }
        
        public override void run()
        {
            var waitingProcesses = kernelStorage
                .processes
                .Processes
                .Where(o => o.resourceHolder.blocked)
                .OrderByDescending(o => o.priority)
                .ToList();

            foreach (var waitingProcess in waitingProcesses)
            {
                var requestedResources = waitingProcess.resourceHolder.RequestedResources;
                foreach (var requestedResource in requestedResources)
                {
                    var resource = kernelStorage.resources.Resources.Where(o => o.type == requestedResource && o.isFree()).First();
                    resource.assign(waitingProcess);
                }
            }
        }
    }
}
