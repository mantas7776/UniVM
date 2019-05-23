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
        public ResTypes type { get; private set; }

        public int creatorId { get; private set; }
        public bool staticRes { get; private set; }
        private BaseSystemProcess assignedTo = null;

        public Resource(ResTypes type, int creatorId, bool staticRes = false)
        {
            this.type = type;
            this.creatorId = creatorId;
            this.staticRes = staticRes;
        }

        public Boolean isFree()
        {
            return assignedTo == null;
        }

        public void assign(BaseSystemProcess process)
        {
            assignedTo = process;

        }

    }
}
