using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class VirtualMemory
    {
        private uint PTR;
        private Memory memory;

        public VirtualMemory(uint PTR, Memory memory)
        {
            this.PTR = PTR;
            this.memory = memory;
        }

        public MemAccesser reserveMemory(string progName, uint rowCount)
        {
            uint[] allowedVirtRows = this.getFreeVirtRows(rowCount);
            return new MemAccesser(allowedVirtRows, memory, PTR);
        }

        private uint[] getFreeVirtRows(uint rowCount)
        {
            uint[] freeVirtRows = new uint[rowCount];
            uint rowToSet = 0;

            for(uint i = 0; i < Constants.BLOCK_SIZE; i++)
            {
                byte[] oneByteArr = { memory.get(PTR + i) };
                int translCellValue = BitConverter.ToInt32(oneByteArr, 0);
                if(translCellValue != -1)
                {
                    freeVirtRows[rowToSet] = i;
                    rowToSet++;
                }

                if (rowToSet == rowCount+1) break;
            }

            if (rowToSet != rowCount + 1) throw new Exception("Not enough virtual memory!");

            return freeVirtRows;
        }
    }
}
