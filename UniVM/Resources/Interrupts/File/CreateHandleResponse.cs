using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class CreateHandleResponse : BaseHandleResource
    {
        FileHandle handle;
        public CreateHandleResponse(int creatorId, FileHandle handle, int messageid) : base(ResType.CreateHandleResponse, HandleOperationType.CreateHandle, creatorId, messageid)
        {
            this.handle = handle;
        }
    }
}
