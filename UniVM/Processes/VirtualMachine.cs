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
        private int creatorId;
        private Storage storage = new Storage("HDD.txt", 1024);
        private Eval eval = new Eval();

        public VirtualMachine(Program program, MemAccesser memAccesser, KernelStorage kernelStorage, int creatorId) : base(ProcPriority.VirtualMachine, kernelStorage)
        {
            this.program = program;
            this.memAccesser = memAccesser;
            this.creatorId = creatorId;
        }

        public override void run()
        {
            switch (this.IC)
            {
                case 0:
                    var regs = new Registers();
                    regs.PTR = 0;
                    eval.registers = regs;
                    while (true)
                    {
                        bool ranAnything = false;
                        if (program.completed)
                            continue;

                        ranAnything = true;
                        program.registers.TIMER = Constants.TIMER_VALUE;
                        eval.registers = program.registers;

                        while (eval.registers.TIMER > 0 && eval.registers.SI == 0 && eval.registers.PI == 0)
                        {
                            eval.run(program);
                        }

                        if (eval.registers.SI > 0 || eval.registers.PI > 0)
                        {
                            intCreator();
                        }
                        program.registers = eval.registers;

                        if (!ranAnything) break;
                    }
                    break;
            }
        }

        private void intCreator()
        {
            if(eval.registers.SI > 0)
            {
                switch(eval.registers.SI)
                {
                    case SiInt.CreateFileHandle:
                        this.kernelStorage.resources.add(new CreateHandleRequest(this.creatorId, this.program.fileName));
                        break;
                    case SiInt.WriteToHandle:
                        this.kernelStorage.resources.add(new WriteHandleRequest(this.creatorId, (int)eval.registers.B, (byte)eval.registers.A));
                        break;
                    case SiInt.ReadFromHandle:
                        //this.kernelStorage.resources.add(new HandleOperationRequest(this.creatorId, HandleOperationType.Read, (int)eval.registers.B));
                        break;
                    case SiInt.CloseFileHandle:
                        //this.kernelStorage.resources.add(new HandleOperationRequest(this.creatorId, HandleOperationType.Close, (int)eval.registers.B));
                        break;
                    case SiInt.DeleteFile:
                        //this.kernelStorage.resources.add(new HandleOperationRequest(this.creatorId, HandleOperationType., (int)eval.registers.B));
                        break;

                }
            }

            if (eval.registers.PI > 0) {

            }
        
            this.kernelStorage.resources.add(new Interrupt(this.creatorId, (IntType)eval.registers.PI, this.program.fileName));
        }
    }
}





