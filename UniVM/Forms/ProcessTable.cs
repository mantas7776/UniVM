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
        public ProcessTable(List<BaseSystemProcess> processes)
        {
            InitializeComponent();
            dataGridView1.DataSource = processes;
            this.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProcessTable_Load(object sender, EventArgs e)
        {

        }
    }
}
