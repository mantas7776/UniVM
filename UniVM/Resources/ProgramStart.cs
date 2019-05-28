
namespace UniVM
{
    class ProgramStart: Resource
    {
        public string programName;

        public ProgramStart(int creatorId, string programName): base(ResType.ProgramStart, creatorId, true)
        {
            this.programName = programName;
        }
    }
}