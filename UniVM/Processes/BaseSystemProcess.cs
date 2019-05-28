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
        public ResourceHolder resourceHolder { get; private set; } = new ResourceHolder();
        public int priority { get; set; }
        private bool running = false;
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

        protected BaseSystemProcess(int priority)
        {
            this.id = nextId++;
            this.priority = priority;
        }

        public void execute()
        {
            this.running = true;
            this.run();
            this.running = false;
            this.IC++;
        }

        public abstract void run();
    }
}
