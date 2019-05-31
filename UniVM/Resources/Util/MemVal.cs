using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public class MemVal
    {
        public int Index { get; set; }
        public byte Value { get; set; }

        public MemVal(int Index, Byte value)
        {
            this.Index = Index;
            this.Value = value;
        }
    }
}
