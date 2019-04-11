using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UniVM
{
    class Eval
    {
        private UInt32[] memory = new UInt32[Constants.BLOCK_SIZE * Constants.BLOCKS_AMOUNT];
        private Registers registers = new Registers();
        private bool running = false;


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

        public void run()
        {
            running = true;
            registers.IP = Constants.START;

            while (running)
            {
                string instructionLine = "asd";
                string[] args = getArgs(instructionLine);
                string instruction =
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
