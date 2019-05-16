using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class MemAccesser
    {
        private uint[] allowedVirtRows;
        private Memory memory;
        private uint PTR;

        public MemAccesser(uint[] allowedVirtRows, Memory memory, uint PTR)
        {
            this.allowedVirtRows = allowedVirtRows;
            this.memory = memory;
            this.PTR = PTR;
        }

        public byte get(uint virtAddress)
        {
            uint offset = virtAddress % Constants.BLOCK_SIZE;
            uint rowNr = virtAddress / Constants.BLOCK_SIZE;
            uint virtRowNr = allowedVirtRows[rowNr];
            uint realRowNr = memory.get(PTR + virtRowNr);
            uint realMemLoc = realRowNr * Constants.BLOCK_SIZE + offset;
            return memory.get(realMemLoc);    
        }
    }
}
