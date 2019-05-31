using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    public enum SiInt
    {
        None,
        Halt,
        CreateFileHandle,
        ReadFromHandle,
        WriteToHandle,
        OpenFileHandle,
        DeleteFile,
        CloseFileHandle,
        PrintConsole,
        ReadConsole,
        MountBattery,
        SeekHandle,
        PrintConsoleRegA,
    }
    public enum PiInt
    {
        None,
        InvalidCommand,
    }
    //public enum IntType
    //{
    //    Halt = SiInt.Halt,
    //    InvalidCommand = PiInt.InvalidCommand,
    //    CreateFileHandle = SiInt.CreateFileHandle,
    //    ReadFromHandle = SiInt.ReadFromHandle,
    //    WriteToHandle = SiInt.WriteToHandle,
    //    OpenFileHandle = SiInt.OpenFileHandle,
    //    DeleteFile = SiInt.DeleteFile,
    //    CloseFileHandle = SiInt.CloseFileHandle,
    //}
}
