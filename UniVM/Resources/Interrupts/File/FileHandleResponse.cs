using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class FileHandleResponse : BaseFileResource
    {
        FileHandle handle;
        public FileHandleResponse(int creatorId, FileHandle handle, int messageid) : base(ResType.FileHandleResponse, FileResourceType.CreateHandle, creatorId, messageid)
        {
            this.handle = handle;
        }
    }
}
