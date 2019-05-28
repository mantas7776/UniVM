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
        private HandleStorage handles;

        public Registers registers {
            get
            {
                return regs;
            }
            set {
                regs = value;
            }
        }

        public Eval(Storage storage)
        {
            //TODO: cia perduoti is isores hanldlestorage kai bus daugiau evalu;
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
                    
                case "SF": return getFlagByLoc(31);
                case "ZF": return getFlagByLoc(30);
                case "OF": return getFlagByLoc(29);
                case "CF": return getFlagByLoc(28);
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
        private void updateCF(uint operator1, uint operator2)
        {
            bool CF = operator2 > operator1;
            setFlag(28, CF);
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

            uint codeSegByteCount = this.regs.DS - this.regs.CS;
            byte[] codeSegBytes = program.memAccesser.readFromAddr(this.regs.CS, codeSegByteCount);
            string codeString = Encoding.ASCII.GetString(codeSegBytes);
            string[] code = codeString.Split('\n');

            string instructionLine = code[regs.IP++]; //cia reikia kodo kad isgauna eilute viena is codesego, vienas int32 laiko 4 simbolius atminty
            string[] args = getArgs(instructionLine);
            
            string instruction = args[0];

            uint res;
            switch (instruction)
            {
                case "HALT":
                    regs.SI = SiInt.Halt;
                    regs.TIMER--;
                    break;
                case "ADD":
                    res = regs.A - regs.B;
                    regs.A += regs.B;
                    updateFlags(regs.A);
                    regs.A = res;
                    regs.TIMER--;
                    break;
                case "SUB":
                    res = regs.A - regs.B;
                    updateFlags(res);
                    updateOF(regs.A, res);
                    updateCF(regs.A, regs.B);
                    regs.A = res;
                    regs.TIMER--;
                    break;
                case "MUL":
                    regs.A *= regs.B;
                    updateFlags(regs.A);
                    regs.TIMER--;
                    break;
                case "DIV":
                    regs.A /= regs.B;
                    updateFlags(regs.A);
                    regs.TIMER--;
                    break;
                case "CMP":
                    res = regs.A - regs.B;
                    updateFlags(res);
                    updateOF(regs.A, res);
                    updateCF(regs.A, regs.B);
                    regs.TIMER--;
                    break;
                case "XOR":
                    res = regs.A ^ regs.B;
                    updateFlags(res);
                    updateOF(0, 0);
                    regs.A = res;
                    regs.TIMER--;
                    break;
                case "AND":
                    res = regs.A & regs.B;
                    updateFlags(res);
                    updateOF(0, 0);
                    regs.A = res;
                    regs.TIMER--;
                    break;
                case "OR":
                    res = regs.A | regs.B;
                    updateFlags(res);
                    updateOF(0, 0);
                    regs.A = res;
                    regs.TIMER--;
                    break;
                case "JMP":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        regs.IP = lineNr;
                        regs.TIMER--;
                        break;
                    }
                case "JL":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        bool jump = getFlagByName("SF") != getFlagByName("OF");
                        if (jump) regs.IP = lineNr;
                        regs.TIMER--;
                        break;
                    }
                case "JE":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        bool jump = getFlagByName("ZF");
                        if (jump) regs.IP = lineNr;
                        regs.TIMER--;
                        break;
                    }
                case "JG":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        bool jump = (!getFlagByName("ZF") && getFlagByName("SF") == getFlagByName("OF"));
                        if (jump) regs.IP = lineNr;
                        regs.TIMER--;
                        break;
                    }
                case "JC":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        bool jump = getFlagByName("JC");
                        if (jump) regs.IP = lineNr;
                        regs.TIMER--;
                        break;
                    }
                case "JZ":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        bool jump = getFlagByName("ZF");
                        if (jump) regs.IP = lineNr;
                        regs.TIMER--;
                        break;
                    }
                case "JNZ":
                    {
                        uint lineNr = uint.Parse(args[1]);
                        bool jump = !getFlagByName("ZF");
                        if (jump) regs.IP = lineNr;
                        regs.TIMER--;
                        break;
                    }
                case "LOOP":
                    {
                        if (regs.CX <= 0)
                            break;
                        uint lineNr = uint.Parse(args[1]);
                        regs.CX--;
                        regs.IP = lineNr;
                        regs.TIMER--;
                        break;
                    }
                case "STOSW":
                    {
                        program.memAccesser.writeFromAddr(regs.B, BitConverter.GetBytes(regs.A));
                        regs.B += 4;
                        regs.TIMER--;
                        break;
                    }
                case "LODSW":
                    {
                        byte[] word = program.memAccesser.readFromAddr(regs.B, 4);
                        regs.A = BitConverter.ToUInt32(word, 0);
                        regs.B += 4;
                        regs.TIMER--;
                        break;
                    }
                case "MOVATOCX":
                    {
                        regs.CX = regs.A;
                        break;
                    }
                case "MOVA":
                case "MOVB":
                    {
                        uint location = uint.Parse(args[1]);
                        byte[] dataToTransfer = program.memAccesser.readFromAddr(regs.DS + location * 4, 4);
                        uint value = BitConverter.ToUInt32(dataToTransfer, 0);

                        if (instruction == "MOVA")
                            regs.A = value;
                        else if (instruction == "MOVB")
                            regs.B = value;
                        regs.TIMER--;
                        break;
                    }
                case "MOVD":
                    {
                        int location = int.Parse(args[1]);
                        byte[] converted = BitConverter.GetBytes(regs.A);
                        program.memAccesser.writeFromAddr((uint)location, converted);
                        regs.TIMER--;
                        break;
                    }
                case "READ": // read from console
                    {
                        regs.A = handles[(int)regs.B].read();
                        regs.TIMER--;
                        break;
                    }
                case "WRITE": // write to console
                    {
                        handles[(int)regs.B].write((byte)regs.A);
                        regs.TIMER--;
                        break;
                    }
                case "OPENFILEHANDLE": 
                    {
                        int location = int.Parse(args[1]);
                        uint handleNr = (uint)handles.add(new HddDevice(this.storage, location));
                        regs.B = handleNr;
                        regs.TIMER--;
                        break;
                    }
                case "DELETEFILE":
                    {
                        int location = int.Parse(args[1]);
                        handles[(int)regs.B].delete(location);
                        regs.TIMER--;
                        break;
                    }
                case "CLOSEFILEHANDLE":
                    {
                        Handle handleToDelete = handles[(int)regs.B];
                        handles.remove(handleToDelete);
                        regs.TIMER--;
                        break;
                    }
                default:
                    Console.WriteLine("Bad opcode " + args[0]);
                    regs.PI = PiInt.OPKUndefined;
                    regs.TIMER--;
                    break;
            }
        }
    }
}