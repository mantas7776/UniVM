using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class Memory
    {
        private byte[] physicalMemory;

        public Memory(uint blockSize, uint blocksAmount)
        {
             this.physicalMemory = new byte[4 * blockSize * blocksAmount];
        }

        public byte get(uint addr)
        {
            if (!this.addrCheck(addr)) throw new Exception("Trying to access invalid memory at addr: " + addr);
            return physicalMemory[addr];
        }

        public void set(uint addr, byte data)
        {
            if (!this.addrCheck(addr)) throw new Exception("Trying to access invalid memory at addr: " + addr);
            physicalMemory[addr] = data;
        }

        private Boolean addrCheck(uint addr)
        {
            if (addr < 0 || addr > 4 * Constants.BLOCK_SIZE * Constants.BLOCKS_AMOUNT - 1) return false;
            return true;
        }
    }
}
