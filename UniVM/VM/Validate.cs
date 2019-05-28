using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Validate
    {
        public void run(Program program)
        {
            string codeString = Encoding.ASCII.GetString(codeSegBytes);
            string[] code = codeString.Split('\n');

            string instructionLine = code[regs.IP++]; //cia reikia kodo kad isgauna eilute viena is codesego, vienas int32 laiko 4 simbolius atminty
            string[] args = getArgs(instructionLine);
            string instruction = args[0];

            uint res;
            switch (instruction)
            {
                case "HALT":
                    regs.SI = 1;
                    regs.TIMER--;
                    break;
                case "ADD":
                    regs.A += regs.B;
                    updateFlags(regs.A);
                    regs.TIMER--;
                    break;
                case "SUB":
                    res = regs.A - regs.B;
                    updateFlags(res);
                    updateOF(regs.A, res);
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
                case "MOVA":
                case "MOVB":
                    {
                        uint location = uint.Parse(args[1]);
                        byte[] dataToTransfer = program.memAccesser.readFromAddr(location, 4);
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
                    regs.PI = 2;
                    regs.TIMER--;
                    break;
            }
        }
    }
}
