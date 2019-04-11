using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public struct Registers
    {
        public uint
            R0,
            R1,
            MODE,
            PTR,
            IP, /* instruction pointer */
            COND,
            SI,
            PI,
            CH1, 
            CH2,
            CH3;
    };
}
