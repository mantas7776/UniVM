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
        public uint IC = 0;
        public readonly int id;
        public ResourceRequestor resourceHolder { get; private set; } = new ResourceRequestor();
        public int priority { get; set; }
        private bool running = false;
        private KernelStorage kernelStorage;
        public ProcState state {
            get
            {
                if (this.running)
                    return ProcState.running;
                else if (resourceHolder.blocked)
                    return ProcState.blocked;
                else
                    return ProcState.idle;

                throw new NotImplementedException();
            }
        }

        protected BaseSystemProcess(int priority, KernelStorage kernelStorage)
        {
            this.id = nextId++;
            this.priority = priority;
            this.kernelStorage = kernelStorage;
        }

        public void execute()
        {
            this.running = true;
            this.run();
            this.running = false;
        }

        public abstract void run();

        public Resource getFirstResource(ResType resType, int messageid = -1)
        {
            Resource resFound = kernelStorage
                .resources
                .getProcessResources(this)
                .Where(res => res.type == resType)
                .First();

            if (resFound == null) throw new Exception("The required resource with type: " + resType + " was not found!");
            return resFound;
        }
    }
}
