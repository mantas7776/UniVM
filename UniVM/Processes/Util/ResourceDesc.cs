using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public struct ResourceDesc
    {
        public ResType type;
        public int messageid;
        public bool blocking;

        public ResourceDesc(ResType type, int messageid)
        {
            this.type = type;
            this.messageid = messageid;
            blocking = true;
        }
    }
}
