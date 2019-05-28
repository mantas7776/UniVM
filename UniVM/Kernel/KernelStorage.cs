using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class KernelStorage
    {
        public ProcessList processes { get; private set; } 
        public ResourceList resources { get; private set; }
        public Memory memory { get; private set; }
        public HandleStorage handles { get; private set; }
        public Storage virtualHdd { get; private set; }

        public KernelStorage()
        {
            processes = new ProcessList();
            resources = new ResourceList(processes);
            memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCK_SIZE);
            handles = new HandleStorage();
            virtualHdd = new Storage("main.bin", 65535);
        }
    }
}
