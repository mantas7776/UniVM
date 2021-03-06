﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class ResourceRequestor
    {
        private int procid;
        private List<ResourceDesc> requestedResources = new List<ResourceDesc>();

        public ResourceRequestor(int procid)
        {
            this.procid = procid;
        }
        public void removeRequest(ResourceDesc resourceDesc)
        {
            requestedResources.Remove(resourceDesc);
        }

        public Boolean blocked
        {
            get
            {
                return requestedResources.Where(res => res.blocking).Any();
            }
        }

        public void request(ResType type, int messageId = -1, bool blocking = true)
        {
            Debug.Print("["+this.procid+"]Requesting: " + type);
            if (type == ResType.Any && messageId == -1) throw new Exception("You probably dont want to reserve all the resources!");
            requestedResources.Add(new ResourceDesc() { type = type, messageid = messageId, blocking = blocking });
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
