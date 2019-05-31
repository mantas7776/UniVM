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
        public ChannelDevice channelDevice { get; private set; }

        public KernelStorage()
        {
            processes = new ProcessList();
            resources = new ResourceList(processes);
            memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCK_SIZE);
            handles = new HandleStorage();
            virtualHdd = new Storage("main.bin", 65535);
            channelDevice = new ChannelDevice();
            handles.add(new ConsoleDevice());
        }


        private void loadProgramsToStorage()
        {
            //write.prog
            VMInfo vminfo = new VMInfo()
            {
                code = Util.getCode("MOVB 4\nOPENFILEHANDLE\nSAVEB 12\nMOVA 20\nMOVATOCX\nMOVA 0\nWRITE\nCLOSEHANDLE\nHALT\n"),
                data = Util.getData("0000001000000008\"big\0\"00000000FFFFFFFF00000004")
            };
            int sz = Util.getProgramSizeInFile(vminfo);
            StorageFile program = StorageFile.createFile(virtualHdd, "write.prog", sz);
            Util.saveCodeToFile(program, vminfo);
            //read.prog
            vminfo = new VMInfo()
            {
                code = Util.getCode("MOVB 4\nOPENFILEHANDLE\nSAVEB 12\nMOVA 20\nMOVATOCX\nMOVA 0\nREAD\nCLOSEHANDLE\nHALT\n"),
                data = Util.getData("0000001000000008\"big\0\"00000000BBBBBBBB00000004")
            };
            sz = Util.getProgramSizeInFile(vminfo);
            program = StorageFile.createFile(virtualHdd, "read.prog", sz);
            Util.saveCodeToFile(program, vminfo);
            //print.prog
            vminfo = new VMInfo()
            {
                code = Util.getCode("MOVA 20\nMOVATOCX\nMOVA 4\nPRINTC\nHALT\n"),
                data = Util.getData("0000001000000008\"big\0\"00000000FFFFFFFF00000004")
            };
            sz = Util.getProgramSizeInFile(vminfo);
            program = StorageFile.createFile(virtualHdd, "print.prog", sz);
            Util.saveCodeToFile(program, vminfo);
            //printc.prog
            vminfo = new VMInfo()
            {
                code = Util.getCode("MOVA 20\nMOVATOCX\nMOVA 4\nPRINTC\nHALT\n"),
                data = Util.getData("0000001000000008\"big\0\"00000000FFFFFFFF00000004")
            };
            sz = Util.getProgramSizeInFile(vminfo);
            program = StorageFile.createFile(virtualHdd, "printc.prog", sz);
            Util.saveCodeToFile(program, vminfo);
            //readc.prog
            vminfo = new VMInfo()
            {
                code = Util.getCode("MOVA 20\nMOVATOCX\nMOVA 4\nREADC\nHALT\n"),
                data = Util.getData("0000001000000008\"big\0\"00000000BBBBBBBB00000004")
            };
            sz = Util.getProgramSizeInFile(vminfo);
            program = StorageFile.createFile(virtualHdd, "printc.prog", sz);
            Util.saveCodeToFile(program, vminfo);
            //battery.prog
            vminfo = new VMInfo()
            {
                code = Util.getCode("MOUNT 0\nMOVA 0\nMOVATOCX\nMOVA 8\nWRITE\nMOVA 4\nREAD\nCLOSEHANDLE\nHALT\n"),
                data = Util.getData("000000040000000100000004")
            };
            sz = Util.getProgramSizeInFile(vminfo);
            program = StorageFile.createFile(virtualHdd, "battery.prog", sz);
            Util.saveCodeToFile(program, vminfo);
            //inf.prog
            vminfo = new VMInfo()
            {
                code = Util.getCode("MOVA 0\nMOVATOCX\nLOOP 0\nHALT\n"),
                data = Util.getData("00000004")
            };
            sz = Util.getProgramSizeInFile(vminfo);
            program = StorageFile.createFile(virtualHdd, "inf.prog", sz);
            Util.saveCodeToFile(program, vminfo);

        }
    }
}
