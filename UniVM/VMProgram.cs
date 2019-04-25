using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class VMProgram
    {
        private Memory memory;
        private Storage storage;
        private byte[] dataMemory;
        private byte[] codeMemory;

        public VMProgram(Memory memory, Storage storage) {
            this.memory = memory;
            this.storage = storage;
            this.eval = eval;
        }

        public void run(string fileData) {
            byte[] inputDataRow = Util.getData("FFBBFFFF\"ABRG\"");
            byte[] inputCommandRow = Util.getCode("ADD\nHALT");
            byte dataSeg = memory.getAvailableSegment();
            byte codeSeg = memory.getAvailableSegment();
            this.dataMemory = memory.getMemRow(dataSeg);
            this.codeMemory = memory.getMemRow(codeSeg);
            Memory.copyBytesToRow(dataMemory, inputDataRow);
            Memory.copyBytesToRow(codeMemory, inputCommandRow);
            eval.run(dataSeg, codeSeg);
        }
    }
}
