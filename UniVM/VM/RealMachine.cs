using System;
using System.Collections.Generic;

namespace UniVM {
    class RealMachine
    {
        private List<Program> programs = new List<Program>();
        private Storage storage = new Storage("HDD.txt", 3000);
        private Memory memory;
        private HandleStorage handles = new HandleStorage();
        private VirtualMemory virtualMemory;
        private ChannelDevice channelDevice = new ChannelDevice();
        private Eval eval;

        public RealMachine()
        {
            this.memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCK_SIZE);
            this.eval = new Eval();
            this.virtualMemory = new VirtualMemory(eval.registers.PTR, memory);
            handles.add(new ConsoleDevice());
        }

        public void handleSiInt(Program program, SiInt siNr)
        {
            switch(siNr)
            {
                case SiInt.Halt:
                    program.setDone();
                    break;
                case SiInt.OpenFileHandle:
                    {
                        byte[] memoryBytes = program.memAccesser.getAllBytes();
                        string fileName = Util.AsciiBytesToString(memoryBytes, checked((int)(program.registers.B + program.registers.DS)));
                        channelDevice.storage = 1;
                        StorageFile file = StorageFile.OpenOrCreate(storage, fileName);
                        FileHandle fh = new FileHandle(file);

                        int hndl = handles.add(fh);
                        channelDevice.storage = 0;
                        program.registers.B = checked((uint)hndl);
                        program.registers.SI = SiInt.None;
                        break;
                    }
                case SiInt.ReadFromHandle:
                    {
                        int bytesToReadAmount = checked((int)program.registers.CX);
                        Handle handle = handles[checked((int)program.registers.B)];
                        //handle battery, special case
                        if (handle is Battery)
                        {
                            byte[] batStatus = ((Battery)handle).getStatus();
                            program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, batStatus);
                        }
                        else
                        {
                            //else handle other
                            FileHandle hndl = (FileHandle)handles[checked((int)program.registers.B)];

                            channelDevice.storage = 1;
                            byte[] readBytes = new byte[program.registers.CX];

                            uint amountRead = 0;
                            try
                            {
                                for (uint i = 0; i < program.registers.CX; i++)
                                {
                                    amountRead++;
                                    readBytes[i] = hndl.read();
                                }
                                program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, readBytes);
                                program.registers.A = 0;
                            }
                            catch (Exception e)
                            {
                                if (!e.Message.Contains("Reading file out of bounds"))
                                    throw e;
                                program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, readBytes);
                                program.registers.A = 1;
                                break;
                            }
                            program.registers.CX = amountRead;
                            channelDevice.storage = 0;
                        }
                        
                        
                        program.registers.SI = SiInt.None;
                        break;
                    }
                case SiInt.ReadConsole:
                    {
                        this.channelDevice.console = 1;
                        ConsoleDevice hndl = (ConsoleDevice)handles[checked((int)program.registers.B)];
                        byte[] readBytes = hndl.readLine();
                        if (readBytes.Length > program.registers.CX)
                        {
                            program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, readBytes, program.registers.CX);
                            program.registers.A = 1;
                        }
                        else
                        {
                            uint len = checked((uint)readBytes.Length);
                            program.memAccesser.writeFromAddr(program.registers.DS + program.registers.A, readBytes, len);
                            program.registers.CX = len;
                            program.registers.A = 0;
                        }
                        
                        this.channelDevice.console = 0;
                        program.registers.A = 0;
                        program.registers.SI = SiInt.None;
                        break;
                    }
                case SiInt.PrintConsole:
                case SiInt.WriteToHandle:
                    {
                        uint bytesToWriteAmount = program.registers.CX;
                        Handle hndl = handles[checked((int)program.registers.B)];
                        //handle battery, special case
                        if (hndl is Battery)
                        {
                            ((Battery)hndl).setStatus((byte)program.registers.A);
                            program.registers.SI = SiInt.None;
                            return;
                        }
                        //handle others else

                        channelDevice.storage = 1;
                        byte[] bytesToWrite = program.memAccesser.readFromAddr(program.registers.DS + program.registers.A, bytesToWriteAmount);

                        uint amountWritten = 0;
                        try
                        {
                            for (uint i = 0; i < bytesToWriteAmount; i++)
                            {
                                amountWritten++;
                                hndl.write(bytesToWrite[i]);
                            }
                            
                            program.registers.A = 0;
                        }
                        catch (Exception e)
                        {
                            if (!e.Message.Contains("Writing file out of bounds."))
                                throw e;
                            program.registers.A = 1;
                            break;
                        }


                        channelDevice.storage = 0;
                        program.registers.CX = amountWritten;
                        program.registers.SI = SiInt.None;
                        break;
                    }
                case SiInt.CloseFileHandle:
                    {
                        if (program.registers.B == 0)
                            throw new Exception("Default handle closing is not allowed!");
                        Handle handle = handles[checked((int)program.registers.B)];
                        if (handle is Battery)
                            this.channelDevice.battery = 0;
                        this.handles.remove(handle);
                        program.registers.SI = SiInt.None;
                        break;
                    }
                case SiInt.DeleteFile:
                    {
                        channelDevice.storage = 1;
                        Handle handle = handles[checked((int)program.registers.B)];
                        if (handle.GetType() != typeof(FileHandle))
                            throw new Exception("Only file handles can be deleted");
                        FileHandle file = (FileHandle)handle;
                        string fileName = file.fileName;
                        this.handles.remove(handle);

                        StorageFile.DeleteFile(storage, fileName);
                        channelDevice.storage = 0;
                        program.registers.SI = SiInt.None;
                        break;
                    }
                case SiInt.MountBattery:
                    {
                        //wait till free
                        if (channelDevice.battery == 1)
                                break;
                        channelDevice.battery = 1;          
                        int hndl = handles.add(new Battery());
                        program.registers.B = checked((uint)hndl);
                        program.registers.SI = SiInt.None;
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }

            return;
        }

        public void handlePiInt(Program program, PiInt PiNr)
        {
            switch (PiNr)
            {
                case PiInt.InvalidCommand:
                    {
                        program.setDone();
                        break;
                    }
            }

            return;
        }

        public void addProgramFromFile()
        {
            //var codeStorage = new Storage(fileName);

            byte[] altcode = Util.getCode("MOVB 4\nOPENFILEHANDLE\nSAVEB 12\nMOVA 20\nMOVATOCX\nMOVA 0\nWRITE\nHALT\n");3
            //byte[] altcode = Util.getCode("MOVB 4\nOPENFILEHANDLE\nSAVEB 12\nMOVA 20\nMOVATOCX\nMOVA 0\nREAD\nCLOSEHANDLE\nHALT\n");
            //byte[] altcode = Util.getCode("MOVA 20\nMOVATOCX\nMOVA 4\nPRINTC\nHALT\n");
            //byte[] altcode = Util.getCode("MOVA 20\nMOVATOCX\nMOVA 4\nREADC\nHALT\n");
            //byte[] altcode = Util.getCode("MOUNT 0\nMOVA 0\nMOVATOCX\nMOVA 8\nWRITE\nMOVA 4\nREAD\nHALT\n");
            string t = "0000001000000008\"big\0\"00000000FFFFFFFF00000004";
            //string t2 = "0000001000000008\"big\0\"00000000BBBBBBBB00000004";
            //string t = "0000000C00000008\"big\0\"00000000BBBBBBBB00000004";
            //string t = "000000040000000100000004";
            byte[] altdata = Util.getData(t);
            //Util.saveCodeToHdd(codeStorage, 10, new VMInfo { code = altcode, data = altdata });
            //uint rowCount = (uint)(codeStorage.getBytes().Length / Constants.BLOCK_SIZE);
            //uint rowCount = 10;
            MemAccesser memAccesser = virtualMemory.reserveMemory(8);
            memAccesser.writeFromAddr(0, altcode);
            memAccesser.writeFromAddr((uint)altcode.Length, altdata);
            Program program = new Program("a", memAccesser);
            program.registers.CS = 0;
            program.registers.DS = 0 + (uint)altcode.Length;

            programs.Add(program);
        }

        public void start()
        {
            //DEBUG
            addProgramFromFile();
            var regs = new Registers();
            regs.PTR = Constants.PTR;
            eval.registers = regs;

            while (true)
            {
                bool ranAnything = false;
                foreach (var program in programs)
                {
                    if (program.completed)
                        continue;

                    ranAnything = true;
                    program.registers.TIMER = Constants.TIMER_VALUE;
                    eval.registers = program.registers;
                    while (eval.registers.TIMER > 0 && eval.registers.SI == SiInt.None && eval.registers.PI == PiInt.None)
                    {
                        eval.run(program);
                    }
                    program.registers = eval.registers;

                    if (eval.registers.SI != SiInt.None)
                        handleSiInt(program, eval.registers.SI);
                    if (eval.registers.PI != PiInt.None)
                        handlePiInt(program, eval.registers.PI);

                    
                }

                if (!ranAnything)
                    break;
            }

        }
    }
}