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
    public partial class ProgramMain : Form
    {
        private Program program;
        public ProgramMain()
        {
            InitializeComponent();
        }
        public ProgramMain(Program program)
        {
            InitializeComponent();
            this.program = program;
        }
    }
}
