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
        public static string AsciiBytesToString(byte[] buffer, int offset)
        {
            List<byte> list = new List<byte>();
            int end = offset;
            while (end < buffer.Length && buffer[end] != 0)
            {
                list.Add(buffer[end]);
                end++;
            }


            return Encoding.ASCII.GetString(list.ToArray());
        }
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
            int codeLength = BitConverter.ToInt32(storageBytes, location);
            int dataLength = BitConverter.ToInt32(storageBytes, location + 4);
            byte[] code = new byte[codeLength];
            byte[] data = new byte[dataLength];
            Array.Copy(storageBytes, location + 8, code, 0, codeLength);
            Array.Copy(storageBytes, location + 8 + codeLength, data, 0, dataLength);
            return new VMInfo
            {
                code = code,
                data = data
            };
        }

        public static int saveCodeToHdd(Storage storage, int location, VMInfo info)
        {
            byte[] codeLengthBytes = BitConverter.GetBytes(info.code.Length);
            byte[] dataLengthBytes = BitConverter.GetBytes(info.data.Length);

            int totalLength = info.code.Length + info.data.Length + codeLengthBytes.Length + dataLengthBytes.Length; // 8 bytes for code and data size + eof
            byte[] dataToWrite = new byte[totalLength];
            int used = 0;

            codeLengthBytes.CopyTo(dataToWrite, used);
            used += codeLengthBytes.Length;
            dataLengthBytes.CopyTo(dataToWrite, used);
            used += dataLengthBytes.Length;

            info.code.CopyTo(dataToWrite, used);
            used += info.code.Length;

            info.data.CopyTo(dataToWrite, used);
            used += info.data.Length;
            
            for (int i = 0; i < totalLength; i++)
            {
                storage[location + i] = dataToWrite[i];
            }
            return totalLength;
        }

        public static Boolean saveCodeToFile(StorageFile file, VMInfo info)
        {
            byte[] codeLengthBytes = BitConverter.GetBytes(info.code.Length);
            byte[] dataLengthBytes = BitConverter.GetBytes(info.data.Length);

            int totalLength = info.code.Length + info.data.Length + codeLengthBytes.Length + dataLengthBytes.Length; // 8 bytes for code and data size + eof
            if (file.size() < totalLength) throw new Exception("File is too small to store code and data");

            byte[] dataToWrite = new byte[totalLength];
            int used = 0;

            codeLengthBytes.CopyTo(dataToWrite, used);
            used += codeLengthBytes.Length;
            dataLengthBytes.CopyTo(dataToWrite, used);
            used += dataLengthBytes.Length;

            info.code.CopyTo(dataToWrite, used);
            used += info.code.Length;

            info.data.CopyTo(dataToWrite, used);
            used += info.data.Length;

            file.setBytes(dataToWrite);
            return true;
        }

        public static int getProgramSizeInFile(VMInfo info)
        {
            byte[] codeLengthBytes = BitConverter.GetBytes(info.code.Length);
            byte[] dataLengthBytes = BitConverter.GetBytes(info.data.Length);

            return info.code.Length + info.data.Length + codeLengthBytes.Length + dataLengthBytes.Length; // 8 bytes for code and data size + eof
        }

        public static VMInfo readCodeFromFile(StorageFile file)
        {
            byte[] storageBytes = file.getAllBytes();
            int codeLength = BitConverter.ToInt32(storageBytes, 0);
            int dataLength = BitConverter.ToInt32(storageBytes, 4);
            byte[] code = new byte[codeLength];
            byte[] data = new byte[dataLength];
            Array.Copy(storageBytes, 8, code, 0, codeLength);
            Array.Copy(storageBytes, 8 + codeLength, data, 0, dataLength);
            return new VMInfo
            {
                code = code,
                data = data
            };
        }

    }
}
