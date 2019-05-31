namespace UniVM
{
    public class Program
    {
        public string fileName { get; private set; }
        public Registers registers;
        public Registers Registers { get { return registers; } }
        public MemAccesser memAccesser { get; private set; }
        public bool completed { get; private set; }

        public Program(string fileName, MemAccesser memAccesser)
        {
            this.memAccesser = memAccesser;
            this.fileName = fileName;
            this.registers = new Registers();
        }

        public void setDone()
        {
            completed = true;
        }
    }
}
