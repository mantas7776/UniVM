using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class IntHandler: BaseSystemProcess
    {
        public IntHandler(KernelStorage kernelStorage): base(ProcPriority.IntHandler, kernelStorage)
        {
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            switch(this.IC) {
                case 0:
                    this.resourceRequestor.request(ResType.Interrupt);
                    this.IC++;
                    break;
                case 1:
                    Interrupt interrupt = (Interrupt)this.getFirstResource(ResType.Interrupt);
                    this.handle(interrupt);
                    interrupt.release();
                    this.IC = 0;
                    break;
            } 

        }

        private void handle(Interrupt interrupt)
        {
            if (Enum.IsDefined(typeof(SiInt), interrupt.type) == true)
                handleSiInt(interrupt);
            else if (Enum.IsDefined(typeof(PiInt), interrupt.type) == true)
                handlePiInt(interrupt);
            else
                throw new NotImplementedException("Invalid int type was provided");

        }

        private void handleSiInt(Interrupt interrupt)
        {
            switch ((SiInt)interrupt.type)
            {
                case SiInt.Halt:
                    {
                        kernelStorage.resources.add(new ProgramStartKill(interrupt.createdByProcess, true, interrupt.programName));
                        break;
                    }
            }

            return;
        }

        private void handlePiInt(Interrupt interrupt)
        {
            switch ((PiInt)interrupt.type)
            {
                case PiInt.OperandUndefined:
                    {
                        break;
                    }
            }

            return;
        }
    }
}
