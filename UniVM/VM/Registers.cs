using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public struct Registers
    {
        public uint A { get; set; }
            public uint B{ get; set; }
           public uint CX { get; set; }
            public uint PTR{ get; set; }
            public uint PTRI { get; set; }
            public uint IP{ get; set; } /* instruction pointer */
            public uint FLAGS{ get; set; }
            public uint CS{ get; set; }
            public uint TIMER{ get; set; }
            public uint DS{ get; set; }
        public SiInt SI { get; set; }
        public PiInt PI { get; set; }

    };
}
