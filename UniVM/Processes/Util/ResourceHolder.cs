using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceHolder
    {

        private List<ResourceDesc> requestedResources = new List<ResourceDesc>();
        private List<Resource> resourcesAcquired = new List<Resource>();

        public void giveResource(Resource resource)
        {
            resourcesAcquired.Add(resource);
            requestedResources.Find(o => o.messageid == resource.messageid && o.type == resource.type);
        }

        public Boolean blocked
        {
            get
            {
                return requestedResources.Count > 0;
            }
        }

        public void request(ResType type, int messageId = -1)
        {
            requestedResources.Add(new ResourceDesc() { type = type, messageid = messageId });
        }

        public Boolean haveResource(ResType type)
        {
            return resourcesAcquired.Exists(o => o.type == type);
        }

        public Resource getFirst(ResType resType)
        {
            Resource resFound = resourcesAcquired
                .Where(res => res.type == resType)
                .First();

            if (resFound == null) throw new Exception("The required resource with type: " + resType + " was not found!");
            return resFound;
        }

        public List<ResourceDesc> RequestedResources
        {
            get
            {
                return new List<ResourceDesc>(requestedResources);
            }
        }
    }
}
