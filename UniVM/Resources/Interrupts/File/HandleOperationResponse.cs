using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class HandleOperationResponse : BaseHandleResource
    {
        public HandleOperationResponse(int creatorId, HandleOperationType operation, int messageid) : base(ResType.NonExistent, operation, creatorId, messageid)
        {
            switch (operation)
            {
                case HandleOperationType.Write:
                    this.type = ResType.WriteHandleResponse;
                    break;
                case HandleOperationType.Close:
                    this.type = ResType.CloseHandleResponse;
                    break;
            }
        }
    }
}