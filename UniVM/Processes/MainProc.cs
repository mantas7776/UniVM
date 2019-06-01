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
                    {
                        ProgramStartKill programStartKill = (ProgramStartKill)this.getFirstResource(ResType.ProgramStartKill);
                        if (!programStartKill.kill)
                        {
                            this.IC = 2;
                        }
                        else
                        {
                            this.IC = 3;
                        }

                        break;
                    }
                case 2:
                    {
                        ProgramStartKill programStartKill = (ProgramStartKill)this.getFirstResource(ResType.ProgramStartKill);
                        JobGovernor jobGovernor = new JobGovernor(programStartKill.programName, this.kernelStorage, this.id);
                        jobGovernors.Add(jobGovernor);
                        kernelStorage.processes.add(jobGovernor);
                        
                        this.IC = 4;
                        break;
                    }
                case 3:
                    {
                        ProgramStartKill programStartKill = (ProgramStartKill)this.getFirstResource(ResType.ProgramStartKill);
                        JobGovernor toDelete = jobGovernors.Find(gov => gov.programName == programStartKill.programName);
                        kernelStorage.processes.remove(toDelete);
                        this.IC = 4;
                        break;
                    }
                case 4:
                    {
                        ProgramStartKill programStartKill = (ProgramStartKill)this.getFirstResource(ResType.ProgramStartKill);
                        programStartKill.release();
                        this.IC = 0;
                        break;
                    }
            }

        }
    }
}
