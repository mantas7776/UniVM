using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public enum ResType
    {
        FileManager,
        OSExit,
        Memory,
        Storage,
        CreateFileInt,
        BaseFileResource,
        FileHandleResponse,
        ProgramStartKill,
        Interrupt,
        NonExistent,
        InterruptRes
    };
}
