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

        public Interrupt(int creatorId): base(ResType.Interrupt, creatorId, true)
        {
     
        }
    }
}
