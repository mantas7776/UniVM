using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public enum ResType
    {
        OSExit,
        Memory,
        BaseHandleResource,
        CreateHandleResponse,
        ReadHandleResponse,
        WriteHandleResponse,
        CloseHandleResponse,
        DeleteHandleResponse,
        ProgramStartKill,
        Interrupt,
        NonExistent,
        FromInterrupt,
        Any,
    };


}
