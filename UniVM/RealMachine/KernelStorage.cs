using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class KernelStorage
    {
        public ProcessList processes { get; private set; } 
        public ResourceList resources { get; private set; }

        public KernelStorage()
        {
            processes = new ProcessList();
            resources = new ResourceList(processes);
        }
    }
}
