using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceScheduler
    {
        private List<Resource> resourceList;

        public ResourceScheduler(ProcessList processList)
        {
            this.processList = processList;
        }
    }
}
