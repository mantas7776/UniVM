using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResourceHolder
    {

        public void giveResource(Resource resource)
        {
            resourcesAquired.Add(resource);
        }

        private Boolean haveResource(string type)
        {
            return resourcesAquired.Exists(o => o.type == type);
        }

        private void requestResource(string type)
        {
            if (requestedResources.Contains(type)) return;
            if (haveResource(type)) return;

        }

        private List<string> requestedResources = new List<string>();
        private List<Resource> resourcesAquired = new List<Resource>();

        public List<string> RequestedResources
        {
            get
            {
                return new List<string>(requestedResources);
            }
        }
    }
}
