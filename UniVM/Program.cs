namespace UniVM
{
    class Program
    {
        public bool completed { get; private set; } = false;

        public Program(MemAccesser memAccesser)
        {

        }

        public void setDone()
        {
            completed = true;
        }
    }
}
