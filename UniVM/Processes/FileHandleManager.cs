using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVM.Processes
{
    class FileHandleManager : BaseSystemProcess
    {
        public FileHandleManager(KernelStorage kernelStorage) : base(50, kernelStorage) { }

        private void createHandle(CreateFileRequest request)
        {
            StorageFile file = StorageFile.Open(this.kernelStorage.virtualHdd, request.filename);
            FileHandle fh = new FileHandle(file);
            this.kernelStorage.handles.add(fh);

            Resource response = new FileHandleResponse(this.id, fh, request.createdByProcess);

            kernelStorage.resources.add(response);
        }

        public override void run()
        {
            switch(this.IC)
            {
                case 0:
                    this.resourceRequestor.request(ResType.FileCreateRequest);
                    break;
                case 1:
                    CreateFileRequest req = getFirstResource(ResType.FileCreateRequest) as CreateFileRequest;
                    createHandle(req);
                    break;
            }
        }
    }
}
