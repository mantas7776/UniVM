using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class WriteHandleRequest : BaseHandleResource
    {
        public int handle { get; private set; }
        public byte[] bytesToWrite { get; private set; }
        public WriteHandleRequest(int creatorId, int handle, byte[] bytesToWrite) : base(ResType.BaseHandleResource, HandleOperationType.Write, creatorId, -1)
        {
            this.bytesToWrite = bytesToWrite;
            this.handle = handle;
        }
    }
}
