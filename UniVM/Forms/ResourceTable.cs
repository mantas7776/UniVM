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
    public partial class ResourceTable : Form
    {
        //private BindingSource bindingSource1 = new BindingSource();

        public ResourceTable(List<Resource> resources)
        {   
            InitializeComponent();
            this.dataGridView1.DataSource = resources;
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ResourceBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
