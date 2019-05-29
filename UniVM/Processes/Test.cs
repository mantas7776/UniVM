using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Test : BaseSystemProcess
    {
        public Test(KernelStorage kernelStorage) : base(30, kernelStorage) { }
        public override void run()
        {
            switch (this.IC)
            {
                case 0:
                    for (int i = 0; i < Constants.BLOCKS_AMOUNT; i++) kernelStorage.resources.add(new Resource(ResType.Memory, this.id));

                    this.kernelStorage.resources.add(new CreateHandleRequest(this.id, "testfile"));

                    this.resourceRequestor.request(ResType.CreateHandleResponse, this.id);
                    this.IC++;
                    break;
                case 1:
                    Resource res = this.getFirstResource(ResType.CreateHandleResponse, this.id);
                    //asd
                    break;
            }

        }
    }
}
