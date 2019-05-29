using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ReadHandleResponse : BaseHandleResource
    {
        char result;
        public ReadHandleResponse(int creatorId, char readResult, int messageid) : base(ResType.ReadHandleResponse, HandleOperationType.Read, creatorId, messageid)
        {
            this.result = readResult;
        }
    }
}
