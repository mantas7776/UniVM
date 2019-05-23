namespace UniVM
{
    class Program
    {
        private string fileName;
        public MemAccesser memAccesser;
        public Registers registers;
        public bool completed { get; private set; } = false;
        public Storage storage;

        public Program(MemAccesser memAccesser, string fileName, Storage storage)
        {
            this.memAccesser = memAccesser;
            this.fileName = fileName;
            this.registers = new Registers();
            this.storage = storage;
            this.loadSelfToMem();
        }

        public void setDone()
        {
            completed = true;
        }

        private void loadSelfToMem()
        {
            //var codeStorage = new Storage(this.fileName);
            //VMInfo info = Util.readCodeFromHdd(storage, 0);

            byte[] altcode = Util.getCode("MOVA 1\nMOVB 2\nADD\nSUB\nHALT\n");
            byte[] altdata = Util.getData("FFFFFFFFAAAABBBB");

            memAccesser.writeFromAddr(0, altcode);
            memAccesser.writeFromAddr((uint)altcode.Length, altdata);


            //memAccesser.writeFromAddr(0, info.code);
            //memAccesser.writeFromAddr(0, info.data);

            this.registers.PTR = memAccesser.PTR;
            this.registers.DS = (uint)altcode.Length;
            this.registers.CS = 0;
            //this.registers.CS = (uint)info.data.Length;
        }
    }
}
