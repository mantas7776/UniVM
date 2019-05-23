using System;

namespace UniVM {
    class MainWrapper {
        public static void Main(string[] args) {
            RealMachine realMachine = new RealMachine();
            var randomStorage = new Storage("test.bin");
            var file = StorageFile.createFile(randomStorage, "ayylmao3", 50);
            var file2 = StorageFile.Open(randomStorage, "ayylmao");
            //realMachine.start();
        }
    }
}