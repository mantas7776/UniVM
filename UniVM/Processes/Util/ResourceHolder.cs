using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceHolder
    {

        private List<ResTypes> requestedResources = new List<ResTypes>();
        private List<Resource> resourcesAcquired = new List<Resource>();

        public void giveResource(Resource resource)
        {
            resourcesAcquired.Add(resource);
            requestedResources.Remove(resource.type);
        }

        public Boolean blocked
        {
            get
            {
                return requestedResources.Count > 0;
            }
        }

        public void request(ResTypes type)
        {
            requestedResources.Add(type);
        }

        public Boolean haveResource(ResTypes type)
        {
            return resourcesAcquired.Exists(o => o.type == type);
        }

        private void requestResource(ResTypes type)
        {
            if (requestedResources.Contains(type)) return;
            if (haveResource(type)) return;

        }

        public List<ResTypes> RequestedResources
        {
            get
            {
                return new List<ResTypes>(requestedResources);
            }
        }
    }
}
