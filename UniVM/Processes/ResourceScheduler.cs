using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceScheduler : BaseSystemProcess
    {

        public ResourceScheduler(KernelStorage kernelStorage) : base (ProcPriority.ResourceScheduler, kernelStorage)
        {
            this.kernelStorage = kernelStorage;
        }
        
        public override void run()
        {
            var waitingProcesses = kernelStorage
                .processes
                .Processes
                .Where(o => o.resourceRequestor.blocked)
                .OrderByDescending(o => o.priority)
                .ToList();

            foreach (var waitingProcess in waitingProcesses)
            {
                var requestedResources = waitingProcess.resourceRequestor.RequestedResources;
                foreach (var requestedResource in requestedResources)
                {
                    var resource = kernelStorage
                        .resources
                        .Resources
                        .Where(o => 
                            o.type == requestedResource.type && 
                            o.isFree() &&
                            o.Messageid == requestedResource.messageid
                         )
                        .First();
                    resource.assign(waitingProcess);
                    waitingProcess.resourceRequestor.removeRequest(requestedResource);
                }
            }
        }
    }
}
