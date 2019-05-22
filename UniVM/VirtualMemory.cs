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
            this.initTranslTable();
        }

        private void initTranslTable()
        {
            byte reservedValue = BitConverter.GetBytes(255)[0];
            for(uint i = 0; i < Constants.BLOCK_SIZE-1; i++)
            {
                memory.set(i, reservedValue);
            }
        }

        public MemAccesser reserveMemory(string progName, uint rowCount)
        {
            uint[] reservedTranslIndexes = this.reserveVirtRows(rowCount);
            return new MemAccesser(reservedTranslIndexes, memory, PTR);
        }

        private List<uint> getAllFreeVirtRowsIndexes()
        {
            uint translTableLength = Constants.BLOCK_SIZE - 1; // -1 because last cell is not used. We have only 15 blocks without transl table;
            List<uint> freeVirtRows = new List<uint>((int)translTableLength);

            for(uint i = 0; i < translTableLength; i++) 
            {

                int translCellValue = memory.get(PTR + i);
                if(translCellValue == 255)
                {
                    freeVirtRows.Add(i);
                }

            }

            return freeVirtRows;
        }

        private uint[] reserveVirtRows( uint rowCount)
        {
            List<uint> allFreeTranslTableIndexes = this.getAllFreeVirtRowsIndexes();
            if (allFreeTranslTableIndexes.Count < rowCount) throw new Exception("There are not enough virtual memory rows!");

            Random rnd = new Random();
            uint[] allFreeVirtRowNrs = new uint[allFreeTranslTableIndexes.Count];
            uint[] allTakenVirtRowNrs = new uint[Constants.BLOCK_SIZE - 1 - allFreeTranslTableIndexes.Count];
            uint[] reservedTranslTableIndexes = new uint[rowCount];
            int takenAdded = 0;
            int freeAdded = 0;
            int reservedCount = 0;

            for(uint i = 0; i < Constants.BLOCK_SIZE-1; i++) // get all taken virt rows
            {
                int translatedValue = (int)memory.get(PTR + i);
                if (translatedValue != 255)
                {
                    allTakenVirtRowNrs[takenAdded] = (uint)translatedValue;
                    takenAdded++;
                }
            }

            for(uint i = 1; i <= Constants.BLOCK_SIZE-1; i++) // get all free virt row nrs
            {
                if (!allTakenVirtRowNrs.Contains(i))
                {
                    allFreeVirtRowNrs[freeAdded] = i;
                    freeAdded++;
                }
            }

            List<uint> cAllFreeVirtRowNrs = new List<uint>(allFreeVirtRowNrs);
            for (int i = 0; i < rowCount; i++) // reserve rows
            {
                if ((int)memory.get(PTR + allFreeTranslTableIndexes[reservedCount]) != 255) throw new Exception("Trying to reserve a virtual row that is already taken!");

                int rngNr = rnd.Next(0, cAllFreeVirtRowNrs.Count);
                memory.set(PTR + allFreeTranslTableIndexes[reservedCount], (byte)cAllFreeVirtRowNrs[rngNr]);
                reservedTranslTableIndexes[reservedCount] = allFreeTranslTableIndexes[reservedCount];
                cAllFreeVirtRowNrs.RemoveAt(rngNr);
                reservedCount++;
            }

            return reservedTranslTableIndexes;
        }
    }
}
