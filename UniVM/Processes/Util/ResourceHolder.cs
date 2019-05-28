using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceRequestor
    {

        private List<ResourceDesc> requestedResources = new List<ResourceDesc>();

        public void removeRequest(ResourceDesc resourceDesc)
        {
            requestedResources.Remove(resourceDesc);
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


        public List<ResourceDesc> RequestedResources
        {
            get
            {
                return new List<ResourceDesc>(requestedResources);
            }
        }

        public void releaseAllResources()
        {
            resourcesAcquired.ForEach(res => res.release());
        }
    }
}
