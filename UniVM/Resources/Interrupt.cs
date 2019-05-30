using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Interrupt: Resource
    {
        public string programName;
        public Interrupt(int creatorId, string programName, int messageid): base(ResType.Interrupt, creatorId, false, messageid)
        {
            this.programName = programName;
        }
    }
}
