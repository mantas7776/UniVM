using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class CreateHandleResponse : BaseHandleResource
    {
        int handle;
        public CreateHandleResponse(int creatorId, int handle, int messageid) : base(ResType.CreateHandleResponse, HandleOperationType.CreateHandle, creatorId, messageid)
        {
            this.handle = handle;
        }
    }
}
