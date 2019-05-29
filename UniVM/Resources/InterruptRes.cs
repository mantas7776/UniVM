using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class InterruptRes: Resource
    {
        public InterruptRes(int creatorId): base(ResType.InterruptRes, creatorId )
        {

        }
    }
}
