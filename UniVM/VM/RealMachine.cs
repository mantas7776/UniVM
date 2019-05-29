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
            this.eval = new Eval();
            this.virtualMemory = new VirtualMemory(eval.registers.PTR, memory);
        }

        public void handleSiInt(Program program, SiInt siNr)
        {
            switch(siNr)
            {
                case SiInt.Halt:
                    {
                        program.setDone();
                        break;
                    }
            }

            return;
        }

        public void handlePiInt(Program program, PiInt PiNr)
        {
            switch (PiNr)
            {
                case PiInt.InvalidCommand:
                    {
                        program.setDone();
                        break;
                    }
            }

            return;
        }

        public void addProgramFromFile()
        {
            //var codeStorage = new Storage(fileName);

            byte[] altcode = Util.getCode("MOVA 0\nMOVATOCX\nMOVB 1\nADD\nLOOP 3\nHALT\n");
            byte[] altdata = Util.getData("0000000500000001");
            //Util.saveCodeToHdd(codeStorage, 10, new VMInfo { code = altcode, data = altdata });
            //uint rowCount = (uint)(codeStorage.getBytes().Length / Constants.BLOCK_SIZE);
            //uint rowCount = 10;
            MemAccesser memAccesser = virtualMemory.reserveMemory(5);
            memAccesser.writeFromAddr(0, altcode);
            memAccesser.writeFromAddr((uint)altcode.Length, altdata);
            Program program = new Program("a", memAccesser);
            program.registers.CS = 0;
            program.registers.DS = 0 + (uint)altcode.Length;

            programs.Add(program);
        }

        public void start()
        {
            //DEBUG
            addProgramFromFile();
            var regs = new Registers();
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
                    program.registers.TIMER = Constants.TIMER_VALUE;
                    eval.registers = program.registers;
                    while (eval.registers.TIMER > 0 && eval.registers.SI == 0 && eval.registers.PI == 0)
                    {
                        eval.run(program);
                    }


                    if (eval.registers.SI > 0)
                        handleSiInt(program, eval.registers.SI);
                    if (eval.registers.PI > 0)
                        handlePiInt(program, eval.registers.PI);

                    program.registers = eval.registers;
                }

                if (!ranAnything)
                    break;
            }

        }
    }
}