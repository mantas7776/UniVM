using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class CreateFileInt: Interrupt
    {
        public string fileName;
        public CreateFileInt(int creatorId, string fileName, string programName): base(creatorId, IntType.CreateFileHandle, programName)
        {
            this.fileName = fileName;
        }
    }
}
