using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class ResourceRequestor
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
            if (type == ResType.Any && messageId == -1) throw new Exception("You probably dont want to reserve all the resources!");
            requestedResources.Add(new ResourceDesc() { type = type, messageid = messageId });
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
