using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Constants
    {
        public static readonly int WORD_SIZE = sizeof(UInt32);
        public static readonly uint MAX_BLOCK_COUNT = 16;
        public static readonly uint BLOCK_SIZE = 16;
        public static readonly uint BLOCKS_AMOUNT = 16;
        public static readonly uint START = 0x3000;
        public static readonly uint PTR = 0;
        public static readonly uint TIMER_VALUE = 4;


        public enum Opcodes
        {
            ADD
        }

        [Flags]
        public enum CondFlags
        {
            SF = 1 << 0,
            ZF = 1 << 1,
            OF = 1 << 2
        }
    }
}
