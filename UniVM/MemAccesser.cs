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

        public byte get(uint virtAddr)
        {
            uint realMemAddr = virtAddrToRealAddr(virtAddr);
            return memory.get(realMemAddr);    
        }

        public void set(uint virtAddr, byte data)
        {
            uint realMemAddr = virtAddrToRealAddr(virtAddr);
            memory.set(realMemAddr, data);
        }

        public void writeFromAddr(uint fromVirtAddr, byte[] data)
        {
            foreach(byte dataByte in data)
            {
                this.set(fromVirtAddr, dataByte);
            }
        }

        public void readFromAddr(uint fromVirtAddr, uint byteCount)
        {
            byte[] bytesRead = new byte[byteCount];
            for(uint i = 0; i < byteCount; i++)
            {
                bytesRead[i] = this.get(fromVirtAddr + i);
            }

            return bytesRead;
        }

        private uint virtAddrToRealAddr(uint virtAddr)
        {
            uint offset = virtAddr % Constants.BLOCK_SIZE;
            uint rowNr = virtAddr / Constants.BLOCK_SIZE;
            uint virtRowNr = allowedVirtRows[rowNr];
            uint realRowNr = memory.get(PTR + virtRowNr);
            uint realMemAddr = realRowNr * Constants.BLOCK_SIZE + offset;
            return realMemAddr;
        }
    }
}
