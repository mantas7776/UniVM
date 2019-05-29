using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class BaseHandleResource : Resource
    {
        public HandleOperationType handleResourceType { get; protected set; }
        public BaseHandleResource(ResType type, HandleOperationType handleResourceType, int createdByProcess, int messageid) : base(type, createdByProcess, false, messageid) {
            this.handleResourceType = handleResourceType;
        }
    }
}
