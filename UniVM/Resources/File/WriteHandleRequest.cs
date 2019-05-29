using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class WriteHandleRequest : BaseHandleResource
    {
        public Handle handle { get; private set; }
        public byte toWrite { get; private set; }
        public WriteHandleRequest(int creatorId, Handle handle, byte toWrite) : base(ResType.BaseHandleResource, HandleOperationType.Write, creatorId, -1)
        {
            this.toWrite = toWrite;
            this.handle = handle;
        }
    }
}
