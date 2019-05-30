using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class WriteHandleResponse : BaseHandleResource
    {
        public uint status { get; private set; }
        public uint amountWritten { get; private set; }
        public WriteHandleResponse(int creatorId, uint status, uint amountWritten, int messageid) : base(ResType.WriteHandleResponse, HandleOperationType.Write, creatorId, messageid)
        {
            this.status = status;
            this.amountWritten = amountWritten;
        }
    }
}
