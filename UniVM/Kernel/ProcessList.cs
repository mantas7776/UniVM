using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ProcessList
    {
        private List<BaseSystemProcess> processes = new List<BaseSystemProcess>();
        public BaseSystemProcess idle { get; set; }
        public List<BaseSystemProcess> Processes
        {
            get
            {
                return new List<BaseSystemProcess>(processes);
            }
        }
        public void add(BaseSystemProcess proc)
        {
            processes.Add(proc);
        }

        public void remove(BaseSystemProcess proc)
        {
            proc.kill();
            processes.Remove(proc);
        }

        public void killAll()
        {
            processes.Clear();
        }
    }

    
}
