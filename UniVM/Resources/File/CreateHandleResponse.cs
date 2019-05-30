using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public enum HandleType
    {
        File,
        Battery
    }
    class CreateHandleResponse : BaseHandleResource
    {
        public int handle { get; private set; }
        public HandleType handleType { get; private set; }
        public CreateHandleResponse(int creatorId, int handle, int messageid, HandleType type = HandleType.File) : base(ResType.CreateHandleResponse, HandleOperationType.CreateFileHandle, creatorId, messageid)
        {
            this.handle = handle;
            this.handleType = type;
        }
    }
}
