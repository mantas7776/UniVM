using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Memory
    {
        private byte[] physicalMemory;

        public Memory(uint blockSize, uint blocksAmount)
        {
             this.physicalMemory = new byte[4 * blockSize * blocksAmount];
        }

        public byte get(uint pos)
        {
            if (pos < 0 || pos > 4 * Constants.BLOCK_SIZE * Constants.BLOCKS_AMOUNT - 1) throw new Exception("Trying to access outside bounds memory!");
            return physicalMemory[pos];
        }
    }
}
