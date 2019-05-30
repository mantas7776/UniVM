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
            Console.Write((char)b);
            return true;
        }

        public byte[] readLine()
        {
            return Encoding.ASCII.GetBytes(Console.ReadLine());
        }

        public bool writeLine(byte[] bytes)
        {
            Console.WriteLine(Encoding.ASCII.GetString(bytes));
            return true;
        }
    }
}
