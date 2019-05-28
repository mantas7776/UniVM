namespace UniVM
{
    class ProgramLoader : BaseSystemProcess
    {

        public ProgramLoader(int priority) : base(priority)
        {
            resourceHolder.request(ResType.ProgramStart);
            resourceHolder.request(ResType.Memory);
        }

        public override void run()
        {


        }
    }
}