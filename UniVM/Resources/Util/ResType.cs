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
        CreateHandleRequest,
        HandleOperationRequest,
        WriteHandleRequest,
        BaseHandleResource,
        CreateHandleResponse,
        ReadHandleResponse,
        WriteHandleResponse,
        CloseHandleResponse,
        DeleteHandleResponse,
        ProgramStartKill,
        Interrupt,
        NonExistent,
        InterruptRes,
        Any,
        FromInterrupt
    };


}
