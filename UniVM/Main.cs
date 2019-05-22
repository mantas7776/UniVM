using System;

namespace UniVM {
    class MainWrapper {
        public static void Main(string[] args) {
            RealMachine realMachine = new RealMachine();
            var randomStorage = new Storage("test.bin", 2000);
            var file = StorageFile.createFile(randomStorage, "ayylmao", 50);
            //realMachine.start();
        }
    }
}