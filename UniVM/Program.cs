namespace UniVM
{
    class Program
    {
        private string fileName;
        private MemAccesser memAccesser;
        public Registers importantRegisters { get; set; }
        public bool completed { get; private set; } = false;

        public Program(MemAccesser memAccesser, string fileName)
        {
            this.fileName = fileName;
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

            memAccesser.writeFromAddr(0, info.data);
            memAccesser.writeFromAddr((uint)info.data.Length, info.code);

            this.importantRegisters.DS = 0;
            this.importantRegisters.CS = info.data.Length;
        }
    }
}
