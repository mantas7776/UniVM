using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class BaseFileResource : Resource
    {
        FileResourceType fileResourceType;
        public BaseFileResource(ResType type, FileResourceType fileResourceType, int createdByProcess, int messageid) : base(type, createdByProcess, false, messageid) {
            this.fileResourceType = fileResourceType;
        }
    }
}
