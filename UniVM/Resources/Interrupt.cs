using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Interrupt: Resource
    {
        public IntType type;
        public string programName;

        public Interrupt(int creatorId, IntType type, string programName): base(ResType.Interrupt, creatorId, true)
        {
            this.type = type;
            this.programName = programName;
        }
    }
}
