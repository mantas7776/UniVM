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
    public partial class ProcessTable : Form
    {
        public ProcessTable(KernelStorage kernelStorage)
        {
            InitializeComponent();
            dataGridView1.DataSource = kernelStorage.processes.Processes;
            dataGridView1.Update();
            this.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProcessTable_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
