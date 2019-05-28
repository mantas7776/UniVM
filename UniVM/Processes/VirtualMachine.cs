using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class VirtualMachine: BaseSystemProcess
    {
        public Program program { get; private set; }
        private MemAccesser memAccesser;
        private int creatorId;
        private List<Program> programs = new List<Program>();
        private Storage storage = new Storage("HDD.txt", 1024);
        private Eval eval;

        public VirtualMachine(Program program, MemAccesser memAccesser, KernelStorage kernelStorage, int creatorId): base(ProcPriority.VirtualMachine, kernelStorage)
        {
            programs.Add(program);
            this.program = program;
            this.memAccesser = memAccesser;
            this.creatorId = creatorId;
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
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

                            if(eval.registers.SI > 0)
                                this.kernelStorage.resources.add(new Interrupt(this.creatorId, (IntType)eval.registers.SI, this.program.fileName));
                            else if(eval.registers.PI > 0)
                                this.kernelStorage.resources.add(new Interrupt(this.creatorId, (IntType)eval.registers.PI, this.program.fileName));
                            
                            program.registers = eval.registers;
                        }

                        if (!ranAnything) break;
                    }
                    break;
            }
        }
    }
}





