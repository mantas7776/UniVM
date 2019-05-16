using System.Collections.Generic;

namespace UniVM {
    class RealMachine
    {
        private readonly uint PTR = 0;
        private List<Program> programs = new List<Program>();
        private Storage storage = new Storage("HDD.txt", 1024);
        private Memory memory;
        private VirtualMemory virtualMemory;
        private Eval eval;

        public RealMachine()
        {
            this.memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCK_SIZE);
            this.eval = new Eval(this.storage);
            this.virtualMemory = new VirtualMemory(PTR, memory);
        }

        public void handleSiInt(ProgramOld program, uint siNr)
        {
            switch(siNr)
            {
                case 1:
                    {
                        program.setDone();
                        break;
                    }
            }

            return;
        }

        public void handlePiInt(ProgramOld program, uint siNr)
        {
            switch (siNr)
            {
                case 2:
                    {
                        program.setDone();
                        break;
                    }
            }

            return;
        }

        public void addProgramFromFile(string fileName, int location)
        {
            var codeStorage = new Storage("code.bin");
            VMInfo info = Util.readCodeFromHdd(storage, location);
            byte[] altcode = Util.getCode("MOVA 1\nMOVB 2\nADD\nSUB\nHALT\n");
            byte[] altdata = Util.getData("FFFFFFFFAAAABBBB");
            //Util.saveCodeToHdd(storage, location, new VMInfo { code = altcode, data = altdata });

            uint rowCount = (uint)(codeStorage.getBytes().Length / Constants.BLOCK_SIZE);
            MemAccesser memAccesser = virtualMemory.reserveMemory(fileName, rowCount);
            Program program = new Program(memAccesser);
            programs.Add(program);
        }



        public void start() {
            // SET PTR HERE or in constructor;
            addProgramFromFile("code.bin", 10);
            while (true)
            {
                bool ranAnything = false;
                foreach (var program in programs)
                {
                    if (program.completed)
                        continue;

                    ranAnything = true;

                    eval.importantRegisters = program.ImportantRegisters;

                    eval.run(program);


                    if (eval.importantRegisters.SI > 0) handleSiInt(program, eval.importantRegisters.SI);
                    if (eval.importantRegisters.PI > 0) handlePiInt(program, eval.importantRegisters.PI);
                    program.ImportantRegisters = eval.importantRegisters;
                }

                if (!ranAnything) break;
            }
            
        }
    }
}