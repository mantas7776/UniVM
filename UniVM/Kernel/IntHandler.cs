using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class IntHandler
    {

        public void handle(IntType intType)
        {
            if (Enum.IsDefined(typeof(SiInt), intType) == true)
                handleSiInt((SiInt)intType);
            else if (Enum.IsDefined(typeof(PiInt), intType) == true)
                handlePiInt((PiInt)intType);
            else
                throw new NotImplementedException("Invalid int type was provided");

        }

        public void handleSiInt(SiInt intType)
        {
            switch (intType)
            {
                case SiInt.Halt:
                    {
                        break;
                    }
            }

            return;
        }

        public void handlePiInt(PiInt intType)
        {
            switch (intType)
            {
                case PiInt.OperandUndefined:
                    {
                        break;
                    }
            }

            return;
        }
    }
}
