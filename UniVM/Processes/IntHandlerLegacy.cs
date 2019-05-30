using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class IntHandlerLegacy: BaseSystemProcess
    {
        private IntHandler intHandler;
        public IntHandlerLegacy(KernelStorage kernelStorage): base(ProcPriority.IntHandler, kernelStorage)
        {
            this.kernelStorage = kernelStorage;
            //intHandler = new IntHandler(kernelStorage, this);
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
                    //intHandler.handle(interrupt);
                    interrupt.release();
                    this.IC = 0;
                    break;
            } 
        }
    }
}
