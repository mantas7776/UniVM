using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM.Processes
{
    class FileManager : BaseSystemProcess
    {
        public FileManager(KernelStorage kernelStorage) : base(50, kernelStorage)
        {

        }

        public override void run()
        {
            throw new NotImplementedException();
        }
    }
}
