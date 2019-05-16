namespace UniVM
{
    class Program
    {
        private string fileName;
        public MemAccesser memAccesser;
        public Registers importantRegisters { get; set; }
        public bool completed { get; private set; } = false;

        public Program(MemAccesser memAccesser, string fileName, Registers registers)
        {
            this.fileName = fileName;
            this.registers = registers;
            this.loadSelfToMem();
        }

        public void setDone()
        {
            completed = true;
        }

        private void loadSelfToMem()
        {
            var codeStorage = new Storage(this.fileName);
            VMInfo info = Util.readCodeFromHdd(codeStorage, 0);

            memAccesser.writeFromAddr(0, info.code);
            memAccesser.writeFromAddr((uint)info.code.Length, info.data);

            this.registers.DS = 0;
            this.registers.CS = info.data.Length;
        }
    }
}
