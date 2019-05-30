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
            A,
            B,
            CX,
            MODE,
            PTR,
            PTRI,
            IP, /* instruction pointer */
            FLAGS,
            CS,
            TIMER,
            DS;

        public SiInt SI;
        public PiInt PI;
    };
}
