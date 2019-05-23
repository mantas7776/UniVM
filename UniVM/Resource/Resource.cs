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
        public string type { get; private set; }

        public int creatorId { get; private set; }
        private Program assignedTo = null;

        Resource(string type, int creatorId)
        {
            this.type = type;
            this.creatorId = creatorId;
        }

        public Boolean isFree()
        {
            return assignedTo == null;
        }

        public void assign()
        {

        }

    }
}
