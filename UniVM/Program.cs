using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Program
    {
        private byte[] dataMemory;
        private byte[] codeMemory;
        private Eval eval;

        public Program(byte[] dataMemory, byte[] codeMemory, Eval eval, Memory memory)
        {
            byte dataSeg = memory.getAvailableSegment();
            byte codeSeg = memory.getAvailableSegment();
            this.dataMemory = memory.getMemRow(dataSeg);
            this.codeMemory = memory.getMemRow(codeSeg);

            dataMemory.CopyTo(this.dataMemory, 0);
            codeMemory.CopyTo(this.codeMemory, 0);

            this.eval = eval;
        }

        public void run()
        {

            //Memory.copyBytesToRow(dataMemory, inputDataRow);
            //Memory.copyBytesToRow(codeMemory, inputCommandRow);
            eval.run(dataMemory, codeMemory);
        }
    }
}


        //Registers.PTR = 0;
        /* supervizorinis rezimas 
            1. Sukuriam VM'a:
                a) Priskiriam memory[0] -> transliavimo row.
                b) priskiriam memory[0][0] -> dataSegRow
                c) priskiriam memory[0][1] -> codeSegRow;
        */

        //    VM.
        //    memory[0] = { 1, 2};
        //    [dataSeg, codeSeg]
        //[0, 1, 2]

        //paleiskPrograma() {
        //const virtualSegNr = memory.getAvailSeg() -> is memory gauni segmenta laisva
        //setSeg(virtualSegNr, uint arr)

        //getavailseg kodui
        //setSeg(uint kodasarr)

        //eval(uint dataVirtualSegNr, uint codeVirtualSegNr)
        //}

        //Memory.getAvailSeg() {
        //    firstRow{uzimti_segmentai } = [];
        //    allRows.forEach()
        //    firstRow.push()
        //}

        //    Eval()
        //    {
        //        getSegment(dataVirtualSegNr)
        //    }

        //getSegment(uint virtualSegNr)
        //{
        //    const realRow = translationRow[virtualSegNr]
        //     return realRow;
        //}

        //    //atlaisvinam jei nereik tuos segus su freeseg()

        //}

        //private void setSegments()
        //{
        //    const uint pagesRowNr = 0;
        //    const uint dataSegRowNr = 1;
        //    const uint codeSegRowNr = 2;

        //    regs.PTR = pagesRowNr;
        //    memory.set(pagesRow, 0, dataSegRow);
        //    memory.set(pagesRow, 1, codeSegRow);
        //}
