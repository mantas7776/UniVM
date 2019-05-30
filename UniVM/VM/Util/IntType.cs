using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public enum SiInt
    {
        Halt,
        CreateFileHandle,
        PrintConsole,
        ReadConsole
    }
    public enum PiInt
    {
        OPKUndefined,
        OperandUndefined
    }
    public enum IntType
    {
        Halt,
        OPKUndefined,
        OperandUndefined,
        CreateFileHandle,
    }
}
