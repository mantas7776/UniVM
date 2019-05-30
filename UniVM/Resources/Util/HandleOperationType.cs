using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public enum HandleOperationType
    {
        CreateHandle,
        Read,
        Write,
        Close,
        Delete
    }
}
