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
            this.memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCK_SIZE);
            this.storage = new Storage("HDD.txt", 1024);
            this.eval = new Eval(memory, storage);
        }

        public void addProgramFromFile(Storage storage, int location)
        {
            VMInfo info = Util.readCodeFromHdd(storage, location);
            byte[] altcode = Util.getCode("MOVA 1\nMOVB 2\nADD\nSUB\nHALT\n");
            Program program = new Program(info.data, altcode, eval, memory);
            programs.Add(program);
        }

        public void start() {
            var codeStorage = new Storage("code.bin");
            addProgramFromFile(codeStorage, 10);
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
