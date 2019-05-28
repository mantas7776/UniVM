
namespace UniVM
{
    class ProgramStartKill: Resource
    {
        public string programName;
        public bool kill;

        public ProgramStartKill(int creatorId, string programName, bool kill, int messageid): base(ResType.ProgramStart, creatorId, true, messageid)
        {
            this.kill = kill;
            this.programName = programName;
        }
    }
}