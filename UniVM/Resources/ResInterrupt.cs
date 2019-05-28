using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ResInterrupt: Resource
    {
        public IntType type;

        public ResInterrupt(int creatorId): base(ResType.Interrupt, creatorId, true)
        {
     
        }
    }
}
