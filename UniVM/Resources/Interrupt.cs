using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Interrupt: Resource
    {
        public IntType intType;
        public string programName;

        public Interrupt(int creatorId, IntType intType, string programName): base(ResType.Interrupt, creatorId, true)
        {
            this.intType = intType;
            this.programName = programName;
        }
    }
}
