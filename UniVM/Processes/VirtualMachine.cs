using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class VirtualMachine: BaseSystemProcess
    {
        private string programName;

        public VirtualMachine(string programName): base(ProcPriority.VirtualMachine)
        {
            this.programName = programName;
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:

                    break;
            }
        }
    }
}
