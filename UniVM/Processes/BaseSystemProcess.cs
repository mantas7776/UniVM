using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    abstract class BaseSystemProcess
    {
        public readonly int id;
        public ResourceHolder resourceHolder { get; private set; }
        public int priority { get; set; }



        protected BaseSystemProcess(int id, int priority)
        {
            this.id = id;
            this.priority = priority;
        }

        public abstract void Run();
    }
}
