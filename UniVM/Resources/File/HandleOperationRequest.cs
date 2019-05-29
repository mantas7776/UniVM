using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class HandleOperationRequest : BaseHandleResource
    {
        public Handle handle { get; private set; }
        public HandleOperationRequest(int creatorId, HandleOperationType operation, Handle handle, string fileName) : base(ResType.BaseHandleResource, operation, creatorId, -1)
        {
            this.handle = handle;
        }
    }
}