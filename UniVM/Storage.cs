using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Storage
    {
        private byte[] storage;
        private int length;
        private string path;

        public Storage(string path, int size)
        {
            this.storage = new byte[size];
            this.length = size;
            this.path = path;

            BitConverter.GetBytes(size).CopyTo(storage, 0);
        }

        public byte[] getBytes()
        {
            return storage.ToArray();
        }

        public Storage(string path)
        {
            byte[] fileBytes = File.ReadAllBytes(path);
            length = BitConverter.ToInt32(fileBytes, 0);
            this.path = path;
            storage = new byte[length];
            fileBytes.CopyTo(storage, 0);
        }

        public int Length
        {
            get { return this.length; }
        }


        private void save()
        {
            File.WriteAllBytes(this.path, this.storage);
        }
        

        public byte this[int loc]
        {
            get
            {
                return this.storage[loc];
            }
            set
            {
                if (loc > 0 && loc < 4) throw new Exception("Writing to header is not allowed");
                this.storage[loc] = value;
                save();
            }
        }
    }
}
