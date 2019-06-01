using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class JobGovernor : BaseSystemProcess
    {
        private IntHandler intHandler;
        private VirtualMemory virtualMemory;
        private VMInfo programData;
        private double rowCount;
        private MemAccesser memAccesser;

        public VirtualMachine virtualMachine;
        public string programName { get; private set;  }

        public JobGovernor(string programName, KernelStorage kernelStorage, int creatorId) : base(ProcPriority.JobGovernor, kernelStorage, creatorId)
        {
            this.programName = programName;
            intHandler = new IntHandler(this.kernelStorage, this);
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
                    {
                        StorageFile file = StorageFile.Open(this.kernelStorage.codeStorage, programName);
                        programData = Util.readCodeFromFile(file);

                        this.rowCount = Math.Ceiling((programData.data.Length + programData.code.Length) / (double)Constants.BLOCK_SIZE);
                        this.IC++;
                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < Convert.ToInt32(rowCount); i++) this.resourceRequestor.request(ResType.Memory);
                        this.IC++;
                        break;
                    }
                case 2:
                    {
                        uint rowCount = this.getResourceTypeCount(ResType.Memory);
                        this.memAccesser = this.kernelStorage.virtualMemory.reserveMemory(rowCount);
                        this.IC++;
                        break;
                    }
                case 3:
                    {
                        //byte[] altcode = Util.getCode("MOVA 0\nMOVATOCX\nMOVB 1\nADD\nLOOP 3\nHALT\n");
                        //byte[] altdata = Util.getData("000000050000000166696C652E747874");

                        //byte[] altcode = Util.getCode("MOVB 4\nOPENFILEHANDLE\nSAVEB 12\nMOVA 20\nMOVATOCX\nMOVA 0\nWRITE\nHALT\n");
                        //byte[] altcode = Util.getCode("MOVB 4\nOPENFILEHANDLE\nSAVEB 12\nMOVA 20\nMOVATOCX\nMOVA 0\nREAD\nCLOSEHANDLE\nHALT\n");
                        //byte[] altcode = Util.getCode("MOUNT 0\nMOVA 0\nMOVATOCX\nMOVA 8\nWRITE\nMOVA 4\nREAD\nCLOSEHANDLE\nHALT\n");
                        //byte[] altcode = Util.getCode("MOVA 20\nMOVATOCX\nMOVA 4\nPRINTC\nHALT\n");
                        //byte[] altcode = Util.getCode("MOVA 20\nMOVATOCX\nMOVA 4\nREADC\nHALT\n");
                        //string t = "0000001000000008\"big\0\"00000000FFFFFFFF00000004";
                        //string t = "0000001000000008\"big\0\"00000000BBBBBBBB00000004";
                        //string t = "000000040000000100000004";
                        //byte[] altdata = Util.getData(t);

                        memAccesser.writeFromAddr(0, programData.code);
                        memAccesser.writeFromAddr((uint)programData.code.Length, programData.data);
                        this.IC++;
                        break;
                    }
                case 4:
                    {
                        Program program = new Program("a", memAccesser);

                        byte[] PTRIInfo = new byte[] { (byte)rowCount, (byte)Constants.MAX_BLOCK_COUNT, (byte)0, (byte)0 };
                        program.registers.PTRI = BitConverter.ToUInt32(PTRIInfo, 0);

                        program.registers.CS = 0;
                        program.registers.DS = 0 + (uint)programData.code.Length;

                        this.virtualMachine = new VirtualMachine(program, memAccesser, kernelStorage, this.id);
                        kernelStorage.processes.add(virtualMachine);
                        this.IC++;
                        break;
                    }
                case 5:
                    {
                        this.resourceRequestor.request(ResType.Any, this.id);
                        this.IC++;
                        break;
                    }
                case 6:
                    {
                        Resource resource = this.getFirstResource(ResType.Any, this.id);
                        Program program = this.virtualMachine.program;
                        if (resource.type == ResType.Interrupt && (program.registers.SI == SiInt.Halt || program.registers.PI == PiInt.InvalidCommand))
                        {
                            this.IC = 8;
                            break;
                        }
                        else
                        {
                            this.IC++;
                        }
                        break;
                    }
                case 7:
                    {
                        Resource resource = this.getFirstResource(ResType.Any, this.id);
                        if (resource.type == ResType.Interrupt)
                        {
                            this.intHandler.handleInt((Interrupt)resource);
                        }
                        else if (resource is BaseHandleResource) // we are only looking at responses. Should be impossible for request to get here.
                        {
                            this.intHandler.handleResponse(resource);
                            this.kernelStorage.resources.add(new Resource(ResType.FromInterrupt, this.id, false, virtualMachine.id));
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }

                        resource.release();
                        this.IC = 5;
                        break;
                    }
                case 8:
                    {
                        kernelStorage.processes.remove(this.virtualMachine);
                        this.IC++;
                        break;
                    }
                case 9:
                    {
                        kernelStorage.resources.add(new ProgramStartKill(this.id, true, this.programName));
                        this.IC++;
                        break;
                    }
                case 10:
                    {
                        this.resourceRequestor.request(ResType.NonExistent);
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        public void changeIC(uint IC)
        {
            this.IC = IC;
        }
    }
}
