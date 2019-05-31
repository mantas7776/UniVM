using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UniVM.Forms
{
    public partial class OSMain : Form
    {
        private Kernel kernel;

        public OSMain()
        {
            InitializeComponent();
            this.kernel = new Kernel();
        }

        private void resButtonClick(object sender, EventArgs e)
        {
            ResourceTable resourceTable = new ResourceTable(kernel.kernelStorage.resources.Resources);
            resourceTable.Show();
        }

        private void ProcTableBtnClick(object sender, EventArgs e)
        {
            ProcessTable processTable = new ProcessTable(kernel.kernelStorage.processes.Processes);
            processTable.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void StartProgram(object sender, EventArgs e)
        {
            ProgramStart programStart = new ProgramStart(kernel);
        }
    }
}
