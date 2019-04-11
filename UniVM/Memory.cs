using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Memory { 
        private uint[][] memory;
        private uint lastVirtualNumber = 1;
        static private readonly int translationTableIndex = 0;

        public Memory(uint blockAmount, uint blockSize)
        {
            memory = new uint[blockAmount][blockSize];
        }

        public uint getAvailableSegment()
        {
            for (int i = 0; i < Constants.BLOCK_SIZE; i++)
            {
                if (memory[translationTableIndex, i] == 0)
                {
                    uint newVirtNr = lastVirtualNumber++;
                    memory[translationTableIndex, i] = newVirtNr;
                    return newVirtNr;
                }
            }
            throw new Exception("No free segment available");
        }

        public 

        public uint get(uint rowNr, uint blockNr)
        {
            return memory[rowNr, blockNr]; 
        }

        public uint set(uint rowNr, uint blockNr)
        {
            return memory[rowNr, blockNr];
        }
    }
}
