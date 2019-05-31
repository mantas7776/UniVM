using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniVM.Forms
{
    public partial class ProgramStart : Form
    {
        private Kernel kernel;
        public ProgramStart(Kernel kernel)
        {
            this.kernel = kernel;
            InitializeComponent();
            this.Show();
        }

        private void StartProgram(object sender, EventArgs e)
        {
            string programName = programNameInp.Text;
            this.kernel.kernelStorage.resources.add(new ProgramStartKill(-1, false, programName));
        }
    }
}
