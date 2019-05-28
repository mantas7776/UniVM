namespace UniVM
{
    class ProgramLoader : BaseSystemProcess
    {

        public ProgramLoader(int priority, KernelStorage kernelStorage) : base(priority, kernelStorage)
        {
            resourceHolder.request(ResType.ProgramStart);
            resourceHolder.request(ResType.Memory);
        }

        public override void run()
        {


        }
    }
}