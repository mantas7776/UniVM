using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class Memval
    {
        public int Index { get; set; }
        public byte Value { get; set; }

        public Memval(int Index, Byte value)
        {
            this.Index = Index;
            this.Value = value;
        }
    }
}
