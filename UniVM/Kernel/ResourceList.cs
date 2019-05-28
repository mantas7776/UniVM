using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceList
    {
        private List<Resource> resourceList = new List<Resource>();
        private ProcessList processList;

        public ResourceList(ProcessList processList)
        {
            this.processList = processList;
        }

        public List<Resource> Resources
        {
            get
            {
                return new List<Resource>(resourceList);
            }
        }

        public void add(Resource resource)
        {
            resourceList.Add(resource);
        }

        public void clear()
        {
            resourceList.Clear();
        }
    }
}
