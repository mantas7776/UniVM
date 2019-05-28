using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM.Processes
{
    class MainProc: BaseSystemProcess
    {
        private KernelStorage kernelStorage;
        private List<JobGovernor> jobGovernors = new List<JobGovernor>();

        public MainProc(int priority, KernelStorage kernelStorage) : base(priority, kernelStorage)
        {
            this.kernelStorage = kernelStorage;
        }

        public override void run()
        {
            switch (this.IC)
            {
                case 0:
                    resourceHolder.request(ResType.ProgramStartKill);
                    this.IC++;
                    break;
                case 1:
                    ProgramStartKill programStartKill = (ProgramStartKill)resourceHolder.getFirst(ResType.ProgramStartKill);
                    if(!programStartKill.kill)
                    {
                        JobGovernor jobGovernor = new JobGovernor(programStartKill.programName, this.kernelStorage);
                        jobGovernors.Add(jobGovernor);
                        kernelStorage.processes.add(jobGovernor);
                    } else
                    {
                        JobGovernor toDelete = jobGovernors.Find(gov => gov.programName == programStartKill.programName);
                        kernelStorage.processes.remove(toDelete);
                    }
                    
                    break;              
            }

        }
    }
}
