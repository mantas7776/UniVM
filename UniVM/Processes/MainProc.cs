using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class MainProc: BaseSystemProcess
    {
        private List<JobGovernor> jobGovernors = new List<JobGovernor>();

        public MainProc(KernelStorage kernelStorage, int creatorId) : base(ProcPriority.MainProc, kernelStorage, creatorId)
        {
        }

        public override void run()
        {
            switch (this.IC)
            {
                case 0:
                    resourceRequestor.request(ResType.ProgramStartKill);
                    this.IC++;
                    break;
                case 1:
                    ProgramStartKill programStartKill = (ProgramStartKill)this.getFirstResource(ResType.ProgramStartKill);
                    if(!programStartKill.kill)
                    {
                        JobGovernor jobGovernor = new JobGovernor(programStartKill.programName, this.kernelStorage, this.id);
                        jobGovernors.Add(jobGovernor);
                        kernelStorage.processes.add(jobGovernor);
                    } else
                    {
                        JobGovernor toDelete = jobGovernors.Find(gov => gov.programName == programStartKill.programName);
                        kernelStorage.processes.remove(toDelete);
                    }

                    programStartKill.release();
                    this.IC = 0;
                    break;              
            }

        }
    }
}
