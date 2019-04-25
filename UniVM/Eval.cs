using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UniVM
{
    class Eval
    {
        private Memory memory;
        private Registers regs = new Registers();
        private bool running = false;


        public Eval(Memory memory)
        {
            this.memory = memory;
        }
        //private void update_flags(uint16_t r)
        //{
        //    uint newFlags;
        //    if (reg[r] == 0)
        //    {
        //        reg[R_COND] = ZF;
        //    }

        //    if (reg[r] >> 15)
        //        reg[R_COND] = FL_NEG;
        //    else
        //        reg[R_COND] = FL_POS;
        //}

        private string[] getArgs(string line)
        {
            return line.Split(' ');
        }

        public void run(byte dataSegRow, byte codeSegRow)
        {

            running = true;
            regs.IP = 0;
            byte[] dataMemory = memory.getMemRow(dataSegRow);
            byte[] codeMemory = memory.getMemRow(codeSegRow);
            string codeString = Encoding.ASCII.GetString(codeMemory);
            string[] code = codeString.Split('\n');

            while (running)
            {
                string instructionLine = code[regs.IP++]; //cia reikia kodo kad isgauna eilute viena is codesego, vienas int32 laiko 4 simbolius atminty
                string[] args = getArgs(instructionLine);
                string instruction = args[0];
                switch (instruction)
                {

                    default:
                        Console.WriteLine("Bad opcode");
                        break;
                }
            }
        }

    }
}
