
namespace UniVM
{
    class ProgramStartKill: Resource
    {
        public string programName;
        public bool kill;

        public ProgramStartKill(int creatorId, bool kill, string programName) : base(ResType.ProgramStartKill, creatorId, false)
        {
            this.kill = kill;
            this.programName = programName;
        }
    }
}