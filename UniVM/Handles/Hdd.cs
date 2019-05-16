using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class HddDevice : Handle
    {
        private Storage storage;
        private int seek;

        public HddDevice(Storage storage, int memPos) {
            this.storage = storage;
            this.seek = memPos;
        }

        public override byte read()
        {
            return this.storage[this.seek++];
        }

        public override bool write(byte data)
        {
            this.storage[this.seek++] = data;
            return true;
        }

        public bool delete() // delete everything from seek to EoF.
        {
            //return storage.delete(this.seek);
            return true;
        }

        public void changeLocation(int location) {
            this.seek = location;
        }
    }
}
