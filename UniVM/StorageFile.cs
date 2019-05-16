using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class StorageFile
    {
        static readonly int FileHeaderSize = 400;
        static readonly int FileHeaderStart = 5;

        int startLoc;
        int eof;

        public int size()
        {
            return eof - startLoc;
        }

        static List<FileInfo> getFileTable(byte[] storageBytes)
        {
            List<FileInfo> FileList = new List<FileInfo>();
            for (int i = checked((int)FileHeaderStart); i < FileHeaderStart + FileHeaderSize; i+=4)
            {
                int loc = BitConverter.ToInt32(storageBytes, i);
                
            }
            return FileList;
        }

        static string getFileName(byte[] storageBytes, int fileLoc)
        {
            int nameLoc = fileLoc + 4;
            return "";
        }

        static StorageFile open(Storage storage, string name)
        {
            byte[] storageBytes = storage.getBytes();
            byte[] fileNameBytes = Encoding.ASCII.GetBytes(name);
            ByteHelper.Locate(storageBytes, fileNameBytes);

            StorageFile file = new StorageFile();
            return file;
        }

        static StorageFile create(Storage storage, string name, uint size)
        {
            return new StorageFile();
        }
    }
}
