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
        public uint PTR { get; private set; }

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
            for(uint i = 0; i < data.Length; i++)
            {
                this.set(fromVirtAddr+i, data[i]);
            }
        }

        public byte[] readFromAddr(uint fromVirtAddr, uint byteCount)
        {
            byte[] bytesRead = new byte[byteCount];
            for(uint i = 0; i < byteCount; i++)
            {
                bytesRead[i] = this.get(fromVirtAddr + i);
            }

            return bytesRead;
        }

        public int size()
        {
            return allowedVirtRows.Length * 16;
        }

        public byte[] getAllBytes()
        {
            int sz = size();
            return readFromAddr(0, checked((uint)sz));
        }
        public bool setAllBytes(byte[] toWrite)
        {
            int sz = size();
            if (sz != toWrite.Length)
                throw new Exception("Memory size is different from array toWrite");
            writeFromAddr(0, toWrite);
            return true;
        }

        private uint virtAddrToRealAddr(uint virtAddr)
        {
            uint offset = virtAddr % Constants.BLOCK_SIZE;
            uint rowNr = virtAddr / Constants.BLOCK_SIZE;
            uint translTableIndex = allowedVirtRows[rowNr];
            uint realRowNr = memory.get(PTR + translTableIndex);
            uint realMemAddr = realRowNr * Constants.BLOCK_SIZE + offset;
            return realMemAddr;
        }
    }
}
