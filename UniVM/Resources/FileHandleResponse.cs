using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class FileHandleResponse : Resource
    {
        FileHandle handle;
        public FileHandleResponse(int creatorId, FileHandle handle, int messageid = -1, bool staticRes = false) : base(ResType.FileCreateResponse, creatorId, staticRes, messageid)
        {
            this.handle = handle;
        }
    }
}
