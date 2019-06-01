using System.Collections.Generic;
using System.Windows.Forms;
using UniVM.Forms;

namespace UniVM
{
    class MainWrapper {
        public static void Main(string[] args) {

            Application.EnableVisualStyles();
            Application.Run(new RMMain());
            
            //Application.Run(new OSMain());
            //Kernel kernel = new Kernel();
            //while (true)
            //{
            //    kernel.startScheduler();
            //    System.Threading.Thread.Sleep(200);
            //}
        }
    }
}