using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public abstract class Handle
    {
        abstract public byte read();
        abstract public bool write(byte c);
        public void delete(int location) { }
        public void close() { }
    }
}
