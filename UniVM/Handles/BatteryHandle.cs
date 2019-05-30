using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Battery : Handle
    {
        private static byte[] info = new byte[4] { 0, 50, 0, 0 };
        public override byte read()
        {
            throw new NotImplementedException();
        }

        public override bool write(byte c)
        {
            throw new NotImplementedException();
        }

        public void setStatus(byte status)
        {
            info[0] = status;
        }

        public byte[] getStatus()
        {
            if (info[0] == 1)
            {
                info[1] = checked((byte)(info[1] + 1 % 100));
            }
            return info;
        }
    }
}
