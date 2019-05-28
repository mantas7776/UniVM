using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Validate
    {

        public static Boolean valid(String allCode)
        {
            string[] code = allCode.Split('\n');
            int codeLine = 0;
            
            while (true)
            {
                string instructionLine = code[codeLine++]; //cia reikia kodo kad isgauna eilute viena is codesego, vienas int32 laiko 4 simbolius atminty
                string[] args = getArgs(instructionLine);
                string instruction = args[0];
                switch (instruction)
                {
                    //no args
                    case "HALT":
                        return true;
                    //single arg int
                    case "ADD":
                    case "SUB":
                    case "MUL":
                    case "DIV":
                    case "CMP":
                        break;
                    case "JMP":
                    case "JL":
                    case "JE":
                    case "MOVA":
                    case "MOVB":
                    case "MOVD":
                        {
                            int parseResult;
                            bool success = int.TryParse(args[1], out parseResult);
                            if (!success) return false;
                            break;
                        }
                    //no idea
                    case "READ":
                    case "WRITE":
                    case "OPENFILEHANDLE":
                    case "DELETEFILE":
                    case "CLOSEFILEHANDLE":
                        break;
                    default:
                        Console.WriteLine("Bad opcode " + args[0]);
                        return false;
                }
                
            }
        }

        private static string[] getArgs(string instructionLine)
        {
            return instructionLine.Split(' ');
        }
    }
}
