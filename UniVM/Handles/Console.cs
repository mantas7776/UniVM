using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class ConsoleDevice : Handle
    {

        public override byte read()
        {
            return (byte)Console.ReadKey().KeyChar;
        }

        public override bool write(byte b)
        {
            Console.Write(b);
            return true;
        }
    }
}
