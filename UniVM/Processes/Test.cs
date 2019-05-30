using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM
{
    class Test : BaseSystemProcess
    {
        CreateHandleResponse created;
        public Test(KernelStorage kernelStorage) : base(30, kernelStorage, -1) { }
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
                    created = this.getFirstResource(ResType.CreateHandleResponse, this.id) as CreateHandleResponse;
                    
                    this.kernelStorage.resources.add(new WriteHandleRequest(this.id, created.handle, 1));

                    this.resourceRequestor.request(ResType.WriteHandleResponse, this.id);
                    this.IC++;
                    break;
                case 2:
                    Resource response = this.getFirstResource(ResType.CreateHandleResponse);
                    break;
            }

        }
    }
}
