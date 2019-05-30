using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ReadHandleResponse : BaseHandleResource
    {
        public uint status { get; private set; }
        public byte[] readBytes { get; private set; }
        public uint bytesRequested { get; private set; }
        public ReadHandleResponse(int creatorId, byte[] result, uint status, uint bytesRequested, int messageid) : base(ResType.ReadHandleResponse, HandleOperationType.Read, creatorId, messageid)
        {
            this.status = status;
            this.readBytes = result;
            this.bytesRequested = bytesRequested;
        }
    }
}
