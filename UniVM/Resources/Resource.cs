using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Resource
    {
        public int id { get; private set; }
        public ResType type { get; private set; }

        public int creatorId { get; private set; }
        public bool staticRes { get; private set; }
        public BaseSystemProcess assignedTo { get; private set; }
        public int messageid { get; private set; }
        public bool expired { get; private set; }

        public Resource(ResType type, int creatorId, bool staticRes = false, int messageid = -1)
        {
            this.type = type;
            this.creatorId = creatorId;
            this.staticRes = staticRes;
            this.messageid = messageid;
            this.assignedTo = null;
            this.expired = false;
        }

        public Boolean isFree()
        {
            return assignedTo == null && !expired;
        }

        public void release()
        {
            assignedTo = null;
            if (staticRes)
                expired = true;
        }

        public void assign(BaseSystemProcess process)
        {
            assignedTo = process;

        }

    }
}
