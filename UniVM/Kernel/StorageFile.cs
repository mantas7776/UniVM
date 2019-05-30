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
        static readonly int FileHeaderStart = 4;

        private Storage storage;
        private FileInfo fileInfo;
        private int dataStart;

        public int size()
        {
            return fileInfo.start + fileInfo.length - dataStart;
        }

        public string name()
        {
            return fileInfo.FileName;
        }


        private StorageFile(Storage storage, FileInfo fileInfo)
        {
            this.storage = storage;
            this.fileInfo = fileInfo;
            this.dataStart = fileInfo.start + Encoding.ASCII.GetByteCount(fileInfo.FileName + "\0") + sizeof(int) * 2; // start offset + 1 byte per char + null terminator + length;
        }

        

        private static List<FileInfo> getFileTable(byte[] storageBytes)
        {
            List<FileInfo> fileList = new List<FileInfo>();
            for (int i = checked((int)FileHeaderStart); i < FileHeaderStart + FileHeaderSize; i += 4)
            {
                int loc = BitConverter.ToInt32(storageBytes, i);
                if (loc == 0)
                {
                    FileInfo fileInfo = new FileInfo()
                    {
                        FileName = "",
                        length = 0,
                        start = 0,
                    };
                    fileList.Add(fileInfo);
                } else
                {
                    int length = BitConverter.ToInt32(storageBytes, loc);
                    string name = Util.AsciiBytesToString(storageBytes, loc + 4);
                    FileInfo fileInfo = new FileInfo()
                    {
                        FileName = name,
                        length = length,
                        start = loc
                    };

                    fileList.Add(fileInfo);
                }
                
            }

            return fileList;
        }

        private static List<FileInfo> getFileTableSorted(byte[] storageBytes)
        {
            List<FileInfo> fileList = getFileTable(storageBytes);


            return fileList.Where(o => o.start != 0).OrderBy(o => o.start).ToList();
        }

        private static int getFreeFileIndex(List<FileInfo> files)
        {
            int current = 0;
            while (current < files.Count)
            {
                if (files[current].start == 0) break;
                current++;
            }
            if (current >= files.Count)
            {
                throw new Exception("File header storage is full");
            }
            return current;
        }
        
        private static void ReserveFileInStorage(Storage storage, FileInfo fileInfo, int fileIndex)
        {
            byte[] storageBytes = storage.getBytes();
            byte[] start = BitConverter.GetBytes(fileInfo.start);
            byte[] name = Encoding.ASCII.GetBytes(fileInfo.FileName + "\0");
            byte[] length = BitConverter.GetBytes(fileInfo.length);
            if (start.Length + name.Length + length.Length > fileInfo.length)
                throw new Exception("File size is too small too create.");

            Buffer.BlockCopy(start, 0, storageBytes, FileHeaderStart + 4 * fileIndex, 4);
            Buffer.BlockCopy(length, 0, storageBytes, fileInfo.start, length.Length);
            Buffer.BlockCopy(name, 0, storageBytes, fileInfo.start + 4, name.Length);
            storage.setStorage(storageBytes);
        }

        public static void DeleteFile(Storage storage, string fileName)
        {
            byte[] storageBytes = storage.getBytes();
            List<FileInfo> fileInfo = getFileTable(storageBytes);
            int fileIndex = fileInfo.FindIndex(file => file.FileName == fileName);

            byte[] empty = new byte[4];
            Buffer.BlockCopy(empty, 0, storageBytes, FileHeaderStart + 4 * fileIndex, 4);
            storage.setStorage(storageBytes);
        }

        private static Boolean IsFileNameTaken(List<FileInfo> files, string name)
        {
            return files.Exists(o => o.FileName == name);
        }

        public static StorageFile createFile(Storage storage, string name, int requestedLength)
        {
            int overheadLength = Encoding.ASCII.GetByteCount(name + "\0") + sizeof(int) + sizeof(int); //fileinfo struct overhead
            int length = requestedLength + overheadLength;
            byte[] storageBytes = storage.getBytes();
            List<FileInfo> files = getFileTable(storageBytes);
            int available = getFreeFileIndex(files);

            List<FileInfo> filesSorted = getFileTableSorted(storageBytes);
            if (IsFileNameTaken(filesSorted, name))
                throw new Exception("File with name: " + name + " already exists");

            int newFileStart = -1; 
            if (filesSorted.Count == 0)
            {
                newFileStart = FileHeaderStart + FileHeaderSize;
            }
            else
            {
                FileInfo last = new FileInfo { length = 0, start = FileHeaderStart + FileHeaderSize };
                int endOfLastFile = FileHeaderStart + FileHeaderSize;

                foreach (FileInfo file in filesSorted)
                {
                     
                    if (file.start - endOfLastFile >= length)
                    {
                        newFileStart = endOfLastFile;
                        break;
                    }
                    last = file;
                    endOfLastFile = last.start + last.length;
                }

                //last file to end of storage
                if (storage.Length - endOfLastFile >= length)
                {
                    newFileStart = endOfLastFile;
                }
                
                if (newFileStart == -1)
                    throw new Exception("Not enough space for file or storage is too fragmented.");
            }


            FileInfo newFile = new FileInfo()
            {
                start = newFileStart,
                FileName = name,
                length = length
            };
            ReserveFileInStorage(storage, newFile, available);
            return new StorageFile(storage, newFile);
        }

        public static StorageFile Open(Storage storage, string name)
        {
            byte[] storageBytes = storage.getBytes();
            List<FileInfo> fileTable = getFileTableSorted(storageBytes);

            try
            {
                FileInfo file = fileTable.Find(o => o.FileName == name);
                StorageFile storageFile = new StorageFile(storage, file);
                return storageFile;
            }
            catch (ArgumentNullException e)
            {
                Console.Error.WriteLine(e);
                throw new Exception("File was not found");
            }

        }

        public byte[] getAllBytes()
        {
            byte[] fileBytes = new byte[size()];
            for (int i = 0; i < size(); i++)
            {
                fileBytes[i] = this[i];
            }
            return fileBytes;
        }


        public bool setBytes(byte[] bytes)
        {
            if (bytes.Length != size()) return false;
            for (int i = 0; i < size(); i++)
            {
                this[i] = bytes[i];
            }
            return true;
        }

        public byte this[int key]
        {
            get
            {
                int loc = dataStart + key;
                if (loc > fileInfo.start + fileInfo.length)
                    throw new Exception("Reading file out of bounds.");
                return storage[loc];
            }
            set
            {
                int loc = dataStart + key;
                if (loc > fileInfo.start + fileInfo.length)
                    throw new Exception("Writing file out of bounds.");
                storage[loc] = value;
            }
        }
    }
}
