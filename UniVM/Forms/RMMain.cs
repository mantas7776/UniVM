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

            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timerTick);
        }

        private void timerTick(object Sender, EventArgs e)
        {
            this.rm.start();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            var gui = new MemoryGUI(rm.memory);
            gui.Show();
        }

        private void VmList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
