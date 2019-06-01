using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class KernelStorage
    {
        public ProcessList processes { get; private set; } 
        public ResourceList resources { get; private set; }
        public Memory memory { get; private set; }
        public HandleStorage handles { get; private set; }
        public Storage virtualHdd { get; private set; }
        public Storage codeStorage { get; private set; }
        public ChannelDevice channelDevice { get; private set; }
        public VirtualMemory virtualMemory { get; private set; }

        public KernelStorage()
        {
            processes = new ProcessList();
            resources = new ResourceList(processes);
            memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCK_SIZE);
            handles = new HandleStorage();
            virtualHdd = new Storage("main.bin", 65535);
            codeStorage = new Storage("code.bin", 65535);
            channelDevice = new ChannelDevice();
            virtualMemory = new VirtualMemory(Constants.PTR, this.memory);
            handles.add(new ConsoleDevice());
            loadProgramsToStorage();
        }


        private void loadProgramsToStorage()
        {
            //write.prog
            VMInfo vminfo = new VMInfo()
            {
                code = Util.getCode("SETB 12\nOPENFILEHANDLE\nSAVEB 8\nSETCX 4\nSETA 4\nREAD\nMOVA 4\nSETB 1\nADD\nSAVEA 0\nSETA 0\nMOVB 8\nSETA 0\nSEEK 0\nSETCX 4\nWRITE\nCLOSEHANDLE\nJMP 0\nHALT\n"),
                data = Util.getData("000000010000000200000003\"file\"\"name\"\"lon\0\"")
            };
            int sz = Util.getProgramSizeInFile(vminfo);
            StorageFile program = StorageFile.createFile(codeStorage, "write.prog", sz);
            Util.saveCodeToFile(program, vminfo);
           
            //read.prog
            vminfo = new VMInfo()
            {
                code = Util.getCode("SETB 4\nOPENFILEHANDLE\nSETCX 4\nSETA 0\nREAD\nCLOSEHANDLE\nMOVA 0\nPRINTA\nHALT\n"),
                data = Util.getData("FFFFFFFF\"file\"\"name\"\"lon\0\"")
            };
            sz = Util.getProgramSizeInFile(vminfo);
            program = StorageFile.createFile(codeStorage, "read.prog", sz);
            Util.saveCodeToFile(program, vminfo);
            
            //inf.prog
            vminfo = new VMInfo()
            {
                code = Util.getCode("MOVA 0\nMOVATOCX\nLOOP 0\nHALT\n"),
                data = Util.getData("00000004")
            };
            sz = Util.getProgramSizeInFile(vminfo);
            program = StorageFile.createFile(codeStorage, "inf.prog", sz);
            Util.saveCodeToFile(program, vminfo);

        }
    }
}
