using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class CreateHandleRequest : BaseHandleResource
    {
        public string fileName { get; private set; }
        public CreateHandleRequest(int creatorId, string fileName) : base(ResType.BaseHandleResource, HandleOperationType.CreateHandle, creatorId, -1)
        {
            this.fileName = fileName;
        }
    }
}
