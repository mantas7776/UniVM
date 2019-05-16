using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UniVM
{
    class Eval
    {
        private Storage storage;
        private Registers regs = new Registers();
        private bool running = false;
        private HandleStorage handles;

        public Registers registers
        {
            get
            {
                return regs;
            }
            set
            {
                regs = value;
            }
        }
        public Eval(Storage storage)
        {
            //TODO: cia perduoti is isores hanldlestorage kai bus daugiau evalu;
            this.storage = storage;
            this.handles = new HandleStorage();
            handles.add(new ConsoleDevice());
            //handles.add()
        }


        // 32bit - sign flag
        // 31bit - OF Flag
        // 30bit - zero Flag
        private void setFlag(int loc, bool val)
        {
            uint newFlag;
            newFlag = val ? (uint)1 : (uint)0;
            newFlag <<= loc;
        }

        private bool getFlagByName(string flagName)
        {
            switch(flagName)
            {
                    
                case "SF": return getFlagByLoc(32);
                case "ZF": return getFlagByLoc(31);
                case "OF": return getFlagByLoc(30);
                default: throw new Exception($"Provided flag: {flagName} does not exist");
            }
        }

        private bool getFlagByLoc(int loc)
        {
            return (regs.FLAGS >> loc) == 1;
        }

        private void updateOF(uint operator1, uint result)
        {
            bool OF = operator1 >> 31 != result >> 31;
            setFlag(29, OF);
        }
        private void updateFlags(uint number)
        {
            //ZF
            bool ZF = number == 0;
                setFlag(30, ZF);

            //SF
            bool SF = number < 0;
                setFlag(31, SF);
        }

        private string[] getArgs(string line)
        {
            return line.Split(' ');
        }

        public void run(Program program)
        {
            running = true;
            byte[] dataMemory = program.dataMemory;
            byte[] codeMemory = program.codeMemory;
            //byte[] dataMemory = memory.getMemRow(dataSegRow);
            //byte[] codeMemory = memory.getMemRow(codeSegRow);
            string codeString = Encoding.ASCII.GetString(codeMemory);
            string[] code = codeString.Split('\n');

            //while (running)
            //{
            string instructionLine = code[regs.IP++]; //cia reikia kodo kad isgauna eilute viena is codesego, vienas int32 laiko 4 simbolius atminty
            string[] args = getArgs(instructionLine);
            string instruction = args[0];


            uint res;
            switch (instruction)
            {
                case "HALT":
                    regs.SI = 1;
                    running = false;
                    break;
                case "ADD":
                    regs.A += regs.B;
                    updateFlags(regs.A);
                    break;
                case "SUB":
                    res = regs.A - regs.B;
                    updateFlags(res);
                    updateOF(regs.A, res);
                    regs.A = res;
                    break;
                case "MUL":
                    regs.A *= regs.B;
                    updateFlags(regs.A);
                    break;
                case "DIV":
                    regs.A /= regs.B;
                    updateFlags(regs.A);
                    break;
                case "CMP":
                    res = regs.A - regs.B;
                    updateFlags(res);
                    updateOF(regs.A, res);
                    break;
                case "JMP":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        regs.IP = lineNr;
                        break;
                    }
                case "JL":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        bool jump = getFlagByName("SF") != getFlagByName("OF");
                        if (jump) regs.IP = lineNr;
                        break;
                    }
                case "JE":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        bool jump = getFlagByName("ZF");
                        if (jump) regs.IP = lineNr;
                        break;
                    }
                case "MOVA":
                case "MOVB":
                    {
                        int location = int.Parse(args[1]);
                        uint value = BitConverter.ToUInt32(dataMemory, location);

                        if (instruction == "MOVA")
                            regs.A = value;
                        else if (instruction == "MOVB")
                            regs.B = value;

                        break;
                    }
                case "MOVD":
                    {
                        int location = int.Parse(args[1]);
                        byte[] converted = BitConverter.GetBytes(regs.A);
                        dataMemory.CopyTo(converted, location);
                        break;
                    }
                case "READ": // read from console
                    {
                        regs.A = handles[(int)regs.B].read();
                        break;
                    }
                case "WRITE": // write to console
                    {
                        handles[(int)regs.B].write((byte)regs.A);
                        break;
                    }
                case "OPENFILEHANDLE": 
                    {
                        int location = int.Parse(args[1]);
                        uint handleNr = (uint)handles.add(new HddDevice(this.storage, location));
                        regs.B = handleNr;
                        break;
                    }
                case "DELETEFILE":
                    {
                        int location = int.Parse(args[1]);
                        handles[(int)regs.B].delete(location);
                        break;
                    }
                case "CLOSEFILEHANDLE":
                    {
                        Handle handleToDelete = handles[(int)regs.B];
                        handles.remove(handleToDelete);
                        break;
                    }
                default:
                    Console.WriteLine("Bad opcode " + args[0]);
                    regs.PI = 2;
                    running = false;
                    break;
            }
            //}
        }
    }
}