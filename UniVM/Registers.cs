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
            MODE,
            PTR,
            IP, /* instruction pointer */
            FLAGS,
            SI,
            PI,
            CH1,
            CH2,
            CH3,
            CS,
            TIMER,
            DS;
    };
}
