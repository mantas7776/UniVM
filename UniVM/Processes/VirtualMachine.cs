using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class VirtualMachine : BaseSystemProcess
    {
        public Program program { get; private set; }
        private MemAccesser memAccesser;
        private Storage storage = new Storage("HDD.txt", 1024);
        private Eval eval = new Eval();

        public VirtualMachine(Program program, MemAccesser memAccesser, KernelStorage kernelStorage, int creatorId) : base(ProcPriority.VirtualMachine, kernelStorage, creatorId)
        {
            this.program = program;
            this.memAccesser = memAccesser;
        }

        public override void run()
        {
            switch (this.IC)
            {
                case 0:
                    var regs = new Registers();
                    regs.PTR = Constants.PTR;
                    eval.registers = regs;
                    if (program.completed)
                        return;

                    program.registers.TIMER = Constants.TIMER_VALUE;
                    eval.registers = program.registers;

                    while (eval.registers.TIMER > 0 && eval.registers.SI == 0 && eval.registers.PI == 0)
                    {
                        eval.run(program);
                    }

                    if (eval.registers.SI > 0 || eval.registers.PI > 0)
                    {
                        this.kernelStorage.resources.add(new Interrupt(this.id, this.program.fileName, this.creatorId));
                        this.resourceRequestor.request(ResType.FromInterrupt, this.id);
                        this.IC++;
                    }

                    program.registers = eval.registers;
                    break;
                case 1:
                    Resource resource = this.getFirstResource(ResType.FromInterrupt, this.id);
                    resource.release();
                    this.IC = 0;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}



