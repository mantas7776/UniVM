using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ProcPriority
    {
        public static int
            ResourceScheduler = 99,
            MainProc = 97,
            JobGovernor = 95,
            IntHandler = 98,
            VirtualMachine = 50;
    }
}
