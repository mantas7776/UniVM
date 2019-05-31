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
    public partial class OSMain : Form
    {
        private Kernel kernel;
        private ResourceTable resourceTable;

        public OSMain()
        {
            InitializeComponent();
            this.kernel = new Kernel();
        }

        private void resButtonClick(object sender, EventArgs e)
        {
            ResourceTable resourceTable = new ResourceTable(kernel.kernelStorage.resources.Resources);
        }
    }
}
