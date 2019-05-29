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

        private void createHandle(FileHandleRequest request)
        {
            StorageFile file = StorageFile.Open(this.kernelStorage.virtualHdd, request.fileName);
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
                    this.resourceRequestor.request(ResType.BaseFileResource);
                    this.IC++;
                    break;
                case 1:
                    FileHandleRequest req = getFirstResource(ResType.BaseFileResource) as FileHandleRequest;
                    createHandle(req);
                    this.IC = 0;
                    break;
            }
        }
    }
}
