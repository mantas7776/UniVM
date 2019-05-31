using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class SetHandleSeekRequest : BaseHandleResource
    {
        public int where { get; private set; }
        public int handle { get; private set; }

        public SetHandleSeekRequest(int createdBy, int handle, int where) : base(ResType.BaseHandleResource, HandleOperationType.Seek, createdBy, -1)
        {
            this.handle = handle;
            this.where = where;
        }
    }
}
