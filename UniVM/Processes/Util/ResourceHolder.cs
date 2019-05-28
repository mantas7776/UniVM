using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceHolder
    {

        private List<ResType> requestedResources = new List<ResType>();
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

        public void request(ResType type)
        {
            requestedResources.Add(type);
        }

        public Boolean haveResource(ResType type)
        {
            return resourcesAcquired.Exists(o => o.type == type);
        }

        private void requestResource(ResType type)
        {
            if (requestedResources.Contains(type)) return;
            if (haveResource(type)) return;

        }

        public List<ResType> RequestedResources
        {
            get
            {
                return new List<ResType>(requestedResources);
            }
        }
    }
}
