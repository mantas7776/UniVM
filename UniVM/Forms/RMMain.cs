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
    public partial class RMMain : Form
    {
        RealMachine rm = new RealMachine();
        public RMMain()
        {
            InitializeComponent();
            
            VmList.DataSource = rm.Programs;
            VmList.DisplayMember = "fileName";

        }



        private void VmList_DoubleClick(object sender, EventArgs e)
        {
            if (VmList.SelectedItem != null)
            {
                Program p = VmList.SelectedItem as Program;
                ProgramMain programGui = new ProgramMain(p);
                programGui.Show();
            }
        }
    }
}
