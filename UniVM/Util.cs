using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Util
    {
        public static uint genRandomNum(uint min, uint max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static uint getUintFrom4Chars(string symbols)
        {
            if (symbols.Length != 4) throw new Exception("Symbols length is not 4");
            byte[] symbolArr = new byte[4];
            for (int j = 0; j < 4; j++) symbolArr[j] = (byte)symbols[j];
            return BitConverter.ToUInt32(symbolArr, 0);
        }

        static uint[] getData(string str)
        {
            List<uint> memory = new List<uint>();
            int i = 0;
            while (i < str.Length)
            {
                if (str[i] == '"')
                {
                    if (str[i + 5] != '"') throw new Exception("Invalid symbol.");
                    string symbols = str.Substring(i, 4);
                    byte[] symbolArr = new byte[4];
                    for (int j = 0; j < 4; j++) symbolArr[j] = (byte)symbols[j];
                    memory.Add(BitConverter.ToUInt32(symbolArr, 0));
                    i += 6;
                }
                else
                {
                    string value = str.Substring(i, 8);
                    i += 8;
                    uint numericValue = Convert.ToUInt32(value, 16);
                    memory.Add(numericValue);
                }
            }
            return memory.ToArray();
        }

        static uint[] getCode(string str)
        {
            List<uint> memory = new List<uint>();
            int i = 0;
            while (i < str.Length)
            {
                //last case
                if (i + 4 >= str.Length && str.Length % 4 != 0)
                {
                    str
                    break;
                }


            }
        }
    }
}
