namespace UniVM
{
    class ProgramLoader : BaseSystemProcess
    {

        public ProgramLoader(int priority, KernelStorage kernelStorage) : base(priority, kernelStorage)
        {
            resourceRequestor.request(ResType.ProgramStart);
            resourceRequestor.request(ResType.Memory);
        }

        public override void run()
        {


        }
    }
}