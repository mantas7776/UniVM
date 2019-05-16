using System.Collections.Generic;

namespace UniVM {
    class RealMachine
    {
        private List<Program> programs = new List<Program>();
        private Storage storage = new Storage("HDD.txt", 1024);
        private Memory memory;
        private VirtualMemory virtualMemory;
        private Eval eval;

        public RealMachine()
        {
            this.memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCK_SIZE);
            this.eval = new Eval(this.storage);
            this.virtualMemory = new VirtualMemory(eval.registers.PTR, memory);
        }

        public void handleSiInt(Program program, uint siNr)
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

        public void handlePiInt(Program program, uint siNr)
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

        public void addProgramFromFile(string fileName)
        {
            var codeStorage = new Storage(fileName);
            uint rowCount = (uint)(codeStorage.getBytes().Length / Constants.BLOCK_SIZE);
            MemAccesser memAccesser = virtualMemory.reserveMemory(fileName, rowCount);
            Program program = new Program(memAccesser, fileName, eval.registers);
            programs.Add(program);
        }

        public void start() {
            var regs = eval.registers;
            regs.PTR = 0;
            eval.registers = regs; 

            while (true)
            {
                bool ranAnything = false;
                foreach (var program in programs)
                {
                    if (program.completed)
                        continue;

                    ranAnything = true;

                    eval.registers = program.importantRegisters;
                    eval.run(program);


                    if (eval.registers.SI > 0) handleSiInt(program, eval.registers.SI);
                    if (eval.registers.PI > 0) handlePiInt(program, eval.registers.PI);
                    program.registers = eval.registers;
                }

                if (!ranAnything) break;
            }
            
        }
    }
}