using System.Collections.Generic;

namespace UniVM {

    //struct ProgramInfo
    //{
    //    byte[] code;
    //    byte[] data;
    //    Storage storage;
    //}

    class RealMachine
    {
        private List<Program> programs = new List<Program>();
        private Memory memory;
        private Storage storage;
        private Eval eval;

        public RealMachine()
        {
            this.memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCKS_AMOUNT);
            this.storage = new Storage("HDD.txt", 1024);
            this.eval = new Eval(memory, storage);
        }

        public void addProgram(string fileName)
        {
            byte dataSeg = memory.getAvailableSegment();
            byte codeSeg = memory.getAvailableSegment();
            byte[] dataMemory = memory.getMemRow(dataSeg);
            byte[] codeMemory = memory.getMemRow(codeSeg);
            Program program = new Program(fileName, dataMemory, codeMemory, eval);
            programs.Add(program);
        }

        public void start() {                      
            string fileName = "program.txt";
            addProgram(fileName);
            programs[0].run();
        }
    }
}

/*
 *             for (Program program : programs)
            {
                program.run();
                VM.loadImportantRegister(Register register);
                VM.run(data blokas, storage blokas);
                kai baigiasi runas = timer interupt
                Register VM.getImportantRegister();
            }
 * 
 * 
 */
