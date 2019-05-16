using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class SegsVNrsContainer
    {
        private uint[] dataSeg;
        private uint[] codeSeg;

        public uint[] getDataSeg()
        {
            return dataSeg;
        }
        public uint[] getCodeSeg()
        {
            return codeSeg;
        }
    }
}
