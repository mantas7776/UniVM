namespace UniVM
{
    class ProgramLoader : BaseSystemProcess
    {

        public ProgramLoader(int priority) : base(priority)
        {
            resourceHolder.request(ResTypes.ProgramStart);
            resourceHolder.request(ResTypes.Memory);
        }

        public override void run()
        {


        }
    }
}