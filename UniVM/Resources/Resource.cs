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
        private BaseSystemProcess assignedTo = null;
        public int messageid { get; private set; }

        public Resource(ResType type, int creatorId, bool staticRes = false, int messageid = -1)
        {
            this.type = type;
            this.creatorId = creatorId;
            this.staticRes = staticRes;
            this.messageid = messageid;
        }

        public Boolean isFree()
        {
            return assignedTo == null;
        }

        public void release()
        {
            assignedTo = null;
        }

        public void assign(BaseSystemProcess process)
        {
            assignedTo = process;

        }

    }
}
