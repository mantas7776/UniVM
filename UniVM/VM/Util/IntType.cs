using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    enum SiInt
    {
        Halt
    }
    enum PiInt
    {
        OPKUndefined,
        OperandUndefined
    }
    enum IntType
    {
        Halt = SiInt.Halt,
        OPKUndefined = PiInt.OPKUndefined,
        OperandUndefined = PiInt.OperandUndefined
    }
}
