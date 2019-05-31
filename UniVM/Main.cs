using System.Windows.Forms;
using UniVM.Forms;

namespace UniVM
{
    class MainWrapper {
        public static void Main(string[] args) {

            //RealMachine realMachine = new RealMachine();
            //var randomStorage = new Storage("test.bin");
            //byte[] altcode = Util.getCode("MOVA 1\nMOVB 2\nADD\nSUB\nHALT\n");
            //byte[] altdata = Util.getData("FFFFFFFFAAAABBBB66696C652E74787400000000");
            //RealMachine realMachine = new RealMachine();
            //var randomStorage = new Storage("test.bin");
            //byte[] altcode = Util.getCode("MOVA 1\nMOVB 2\nADD\nSUB\nHALT\n");
            //byte[] altdata = Util.getData("FFFFFFFFAAAABBBB");
            //RealMachine realMachine = new RealMachine();
            var randomStorage = new Storage("test.bin");
            byte[] altcode = Util.getCode("MOVA 12\nnADD\nSUB\nHALT\n");
            byte[] altdata = Util.getData("FFFFFFFFAAAABBBB\"big\0\"00000000");

            //VMInfo codeInfo = new VMInfo() { code = altcode, data = altdata };
            //int size = Util.getProgramSizeInFile(codeInfo);
            //StorageFile.DeleteFile(randomStorage, "program1");
            //var file = StorageFile.createFile(randomStorage, "program1", Util.getProgramSizeInFile(codeInfo));
            //var codeFile = StorageFile.Open(randomStorage, "program1");
            //Util.saveCodeToFile(codeFile, codeInfo);
            //VMInfo info = Util.readCodeFromFile(codeFile);
            //realMachine.start();
            //var k = new Kernel();

            //var randomStorage = new Storage("test.bin");
            //byte[] altcode = Util.getCode("MOVA 1\nMOVB 2\nADD\nSUB\nHALT\n");
            //byte[] altdata = Util.getData("FFFFFFFFAAAABBBB66696C652E74787400000000");
            //VMInfo codeInfo = new VMInfo() { code = altcode, data = altdata };
            //var codeFile = StorageFile.Open(randomStorage, "program1");
            //Util.saveCodeToFile(codeFile, codeInfo);

            //Kernel kernel = new Kernel();
            Application.EnableVisualStyles();
            Application.Run(new OSMain());
        }
    }
}