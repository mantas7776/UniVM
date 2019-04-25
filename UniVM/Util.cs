using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    struct VMInfo
    {
        public byte[] data;
        public byte[] code;
    }
    class Util
    {
        //public static uint genRandomNum(uint min, uint max)
        //{
        //    Random random = new Random();
        //    return random.Next(min, max);
        //}

        static uint getUintFrom4Chars(string symbols)
        {
            if (symbols.Length != 4) throw new Exception("Symbols length is not 4");
            byte[] symbolArr = new byte[4];
            for (int j = 0; j < 4; j++) symbolArr[j] = (byte)symbols[j];
            return BitConverter.ToUInt32(symbolArr, 0);
        }

        public static byte[] getData(string str)
        {
            List<byte> memory = new List<byte>();
            int i = 0;
            while (i < str.Length)
            {
                if (str[i] == '"')
                {
                    if (str[i + 5] != '"') throw new Exception("Invalid symbol.");
                    string symbols = str.Substring(i, 4);
                    byte[] symbolArr = Encoding.ASCII.GetBytes(symbols);
                    memory.AddRange(symbolArr);
                    i += 6;
                }
                else
                {
                    string value = str.Substring(i, 8);
                    i += 8;
                    uint numericValue = Convert.ToUInt32(value, 16);
                    byte[] numberBytes = BitConverter.GetBytes(numericValue);
                    memory.AddRange(numberBytes);
                }
            }
            return memory.ToArray();
        }

        public static byte[] getCode(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        public static VMInfo readCodeFromHdd(Storage storage, int location)
        {
            byte[] storageBytes = storage.getBytes();
            int codeLength = BitConverter.ToInt32(storageBytes, 0);
            int dataLength = BitConverter.ToInt32(storageBytes, 0);
            byte[] code = new byte[codeLength];
            byte[] data = new byte[dataLength];
            Array.Copy(storageBytes, codeLength + 8, code, 0, codeLength);
            Array.Copy(storageBytes, codeLength + dataLength + 8, code, 0, codeLength);
            return new VMInfo
            {
                code = code,
                data = data
            };
        }

        public static int saveCodeToHdd(Storage storage, VMInfo info)
        {
            int totalLength = info.code.Length + info.data.Length + 8 + 1; // 8 bytes for code and data size + eof
            byte[] codeLength = BitConverter.GetBytes(info.code.Length);
            byte[] dataLength = BitConverter.GetBytes(info.data.Length);
            return totalLength;
        }

    }
}
