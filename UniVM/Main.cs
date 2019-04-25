using System;

namespace UniVM {
    class MainWrapper {
        public static void Main(string[] args) {
            RealMachine realMachine = new RealMachine();
            realMachine.start();
        }
    }
}