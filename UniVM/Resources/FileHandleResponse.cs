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
        public FileHandleResponse(int creatorId, FileHandle handle, int messageid) : base(ResType.FileCreateResponse, creatorId, false, messageid)
        {
            this.handle = handle;
        }
    }
}
