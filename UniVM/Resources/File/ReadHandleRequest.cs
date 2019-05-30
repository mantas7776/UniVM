using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ReadHandleRequest : BaseHandleResource
    {
        public int handle { get; private set; }
        public int amount { get; private set; }
        public ReadHandleRequest(int creatorId, int handle, int amount, string fileName) : base(ResType.BaseHandleResource, HandleOperationType.Read, creatorId, -1)
        {
            this.handle = handle;
            this.amount = amount;
        }
    }
}