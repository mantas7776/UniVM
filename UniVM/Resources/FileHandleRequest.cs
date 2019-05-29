using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class FileHandleRequest : Resource
    {
        public string fileName { get; private set; }
        public FileHandleRequest(int creatorId, string fileName) : base(ResType.FileCreateRequest, creatorId, true, -1)
        {
            this.fileName = fileName;
        }
    }
}
