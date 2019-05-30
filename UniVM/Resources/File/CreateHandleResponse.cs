using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class CreateHandleResponse : BaseHandleResource
    {
        public int handle { get; private set; }
        public CreateHandleResponse(int creatorId, int handle, int messageid) : base(ResType.CreateHandleResponse, HandleOperationType.CreateFileHandle, creatorId, messageid)
        {
            this.handle = handle;
        }
    }
}
