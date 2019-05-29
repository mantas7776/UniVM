using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM.Processes
{
    class HandleManager : BaseSystemProcess
    {
        public HandleManager(KernelStorage kernelStorage) : base(50, kernelStorage) { }

        private void createHandle(CreateHandleRequest request)
        {
            StorageFile file = StorageFile.Open(this.kernelStorage.virtualHdd, request.fileName);
            FileHandle fh = new FileHandle(file);
            this.kernelStorage.handles.add(fh);

            Resource response = new CreateHandleResponse(this.id, fh, request.createdByProcess);

            kernelStorage.resources.add(response);
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
                    this.resourceRequestor.request(ResType.BaseHandleResource);
                    this.IC++;
                    break;
                case 1:
                    CreateHandleRequest req = getFirstResource(ResType.BaseHandleResource) as CreateHandleRequest;
                    createHandle(req);
                    this.IC = 0;
                    break;
            }
        }
    }
}
