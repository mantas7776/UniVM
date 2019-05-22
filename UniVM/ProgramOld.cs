using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ProgramOld
    {
        public byte[] dataMemory { get; }
        public byte[] codeMemory { get; }
        private Eval eval;
        public bool completed { get; private set; } = false;
        public Registers ImportantRegisters { get; set; }
        

        public ProgramOld(byte[] dataMemory, byte[] codeMemory, MemoryOld memory)
        {
            byte dataSeg = memory.getAvailableSegment();
            byte codeSeg = memory.getAvailableSegment();
            this.dataMemory = memory.getMemRow(dataSeg);
            this.codeMemory = memory.getMemRow(codeSeg);

            dataMemory.CopyTo(this.dataMemory, 0);
            codeMemory.CopyTo(this.codeMemory, 0);
        }

        public void setDone()
        {
            completed = true;
        }
    }
}
