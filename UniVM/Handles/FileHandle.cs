using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class FileHandle : Handle
    {
        private StorageFile file;

        private int seek = 0;

        public int Seek
        {
            get
            {
                return seek;
            }
            set
            {
                seek = value;
            }
        }

        public string fileName 
        {
            get
            {
                return file.name();
            }
        }

        public FileHandle(StorageFile file)
        {
            this.file = file;
        }

        public override byte read()
        {
            return file[seek++];
        }

        public override bool write(byte c)
        {
            file[seek++] = c;
            return true;
        }

    }
}
