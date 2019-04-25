using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Memory { 
        private byte[][] memory;
        private byte lastVirtualNumber = 1;
        static private readonly int translationTableIndex = 0;

        public Memory(uint blockAmount, uint blockSize)
        {
            memory = new byte[blockAmount][];
            for (int i = 0; i < blockAmount; i++) memory[i] = new byte[blockSize*4];
        }

        public byte getAvailableSegment()
        {
            for (int i = 0; i < Constants.BLOCK_SIZE; i++)
            {
                if (memory[translationTableIndex][i] == 0)
                {
                    byte newVirtNr = lastVirtualNumber++;
                    memory[translationTableIndex][i] = newVirtNr;
                    return newVirtNr;
                }
            }
            throw new Exception("No free segment available");
        }

        public byte[] getMemRow(byte virtRowNr)
        {
            byte realRowNr = memory[translationTableIndex][virtRowNr];
            return memory[realRowNr];
        }

        public void copyBytesToRow(byte[] memRow, byte[] newData)
        {
            newData.CopyTo(memRow, 0);
        }


        //public uint get(uint rowNr, uint blockNr)
        //{
        //    return memory[rowNr, blockNr]; 
        //}

        //public uint set(uint rowNr, uint blockNr)
        //{
        //    return memory[rowNr, blockNr];
        //}
    }
}
