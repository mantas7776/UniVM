using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class CreateFileRequest : Resource
    {
        public string filename { get; private set; }
        public CreateFileRequest(int creatorId, string filename, bool staticRes = false, int messageid = -1) : base(ResType.FileCreateRequest, creatorId, staticRes, messageid)
        {
            this.filename = filename;
        }
    }
}
