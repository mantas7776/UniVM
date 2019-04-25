using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Memory { 
        private byte[][] memory;
        private byte lastVirtualNumber = 2;
        static private readonly int translationTableIndex = 0;

        public Memory(uint blockAmount, uint blockSize)
        {
            memory = new byte[blockAmount][];
            for (int i = 0; i < blockAmount; i++) memory[i] = new byte[blockSize*4];
            memory[translationTableIndex][0] = 1;
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
            if (virtRowNr == 0) throw new Exception("Virtual memory row can not be 0");
            //mem row - > virt row
            byte[] translationTable = memory[translationTableIndex];
            for (int i = 0; i < translationTable.Length; i++)
            {
                if (translationTable[i] == virtRowNr)
                    return memory[i]; 
            }
            throw new Exception("Virtual memory row: " + virtRowNr + " does not exist.");
        }

        public static void copyBytesToRow(byte[] memRow, byte[] newData)
        {
            if (newData.Length > memRow.Length) throw new Exception("Newdata is too big for memory row.");
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
