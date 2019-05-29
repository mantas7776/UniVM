using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class FileHandleRequest : BaseFileResource
    {
        public string fileName { get; private set; }
        public FileHandleRequest(int creatorId, string fileName) : base(ResType.BaseFileResource, FileResourceType.CreateHandle, creatorId, -1)
        {
            this.fileName = fileName;
        }
    }
}
