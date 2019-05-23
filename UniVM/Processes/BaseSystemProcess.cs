using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    abstract class BaseSystemProcess
    {
        private static int nextId = 0;
        public readonly int id;
        public ResourceHolder resourceHolder { get; private set; } = new ResourceHolder();
        public int priority { get; set; }
        public KernelStorage kernelStorage = new KernelStorage();

        protected BaseSystemProcess(int priority)
        {
            this.id = nextId++;
            this.priority = priority;
        }

        public abstract void run();
    }
}
