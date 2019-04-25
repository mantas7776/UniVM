using System.Collections.Generic;

namespace UniVM {

    struct ProgramInfo
    {
        byte[] code;
        byte[] data;
        Storage storage;
    }

    class RealMachine
    {
        private List<ProgramInfo> programs = new List<ProgramInfo>();
        public RealMachine()
        {

        }

        public void addProgram(string fileName)
        {
            
            //programs.add(fileName);
        }

        public void startProgram(int progNr) {

        }

        //get avail
        //finds any avial program in programs
        //runs until timer interupt
        //nzn 

        public void start() {
            /*
            
                            Memory memory = new Memory(Constants.BLOCKS_AMOUNT, Constants.BLOCKS_AMOUNT);
            Storage storage = new Storage("PATH", 1024);
            Eval eval = new Eval(memory, storage);
             */
            //pasimi kita nevykdoma programa, pradedi ja vykdyt
            //string fileName = "program.txt";
            //addProgram(fileName);

            //for (var program : programs)
            //{
              //  startProgram();
                //VM.loadImportantRegister(Register register);
                //VM.run(data blokas, storage blokas);
                //kai baigiasi runas = timer interupt 
                //Register VM.getImportantRegister();
                //atiduodi kazkam kitam darba jei kazkas yra in qeueu
            //}
            // throw cmd to enter programname to execute.
            
        }
    }
}
