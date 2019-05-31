using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public abstract class BaseSystemProcess
    {
        private static int nextId = 0;
        protected uint IC = 0;
        public int id { get; }
        public ResourceRequestor resourceRequestor { get; private set; }
        public int priority { get; set; }
        public string procName { get; set; }
        public readonly int creatorId;
        private bool running = false;
        protected KernelStorage kernelStorage;
        public ProcState state {
            get
            {
                if (this.running)
                    return ProcState.running;
                else if (resourceRequestor.blocked)
                    return ProcState.blocked;
                else
                    return ProcState.idle;

                throw new NotImplementedException();
            }
        }

        protected BaseSystemProcess(int priority, KernelStorage kernelStorage, int creatorId)
        {
            this.procName = this.GetType().Name;
            this.id = nextId++;
            this.creatorId = creatorId;
            this.priority = priority;
            this.kernelStorage = kernelStorage;
            this.resourceRequestor = new ResourceRequestor(this.id);
        }

        public void execute()
        {
            this.running = true;
            this.run();
            this.running = false;
        }

        public abstract void run();

        protected List<Resource> getResources()
        {
            return kernelStorage
                .resources
                .getProcessResources(this);
        }

        protected Resource getFirstResource(ResType resType, int messageid = -1)
        {
            Resource resFound = getResources()
                .Where(res => ((res.type == resType || resType == ResType.Any) && res.Messageid == messageid))
                .First();

            if (resFound == null) throw new Exception("The required resource with type: " + resType + " was not found!");
            return resFound;
        }

        protected List<Resource> getAllResources(ResType resType, int messageid = -1)
        {
            List<Resource> resFound = getResources()
                .Where(res => ((res.type == resType || resType == ResType.Any) && res.Messageid == messageid))
                .ToList();

            if (resFound == null) throw new Exception("The required resource with type: " + resType + " was not found!");
            return resFound;
        }

        public void kill()
        {
            this.getResources().ForEach(res => res.release());
        }

        public uint getResourceTypeCount(ResType resType)
        {
            uint resCount = (uint)kernelStorage
                .resources
                .getProcessResources(this)
                .Count(res => res.type == resType);

            return resCount;
        }
    }
}
