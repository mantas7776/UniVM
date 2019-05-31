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
    public partial class MemoryGUI : Form
    {
        private Memory mem; 
        public MemoryGUI(Memory mem)
        {
            InitializeComponent();
            this.mem = mem;
            dataGridView1.DataSource = this.data;
        }

        public List<Memval> data
        {
            get
            {
                List<Memval> list = new List<Memval>(); 
                for (int i = 0; i < mem.PhysicalMemory.Count; i++)
                {
                    list.Add(new Memval(i, mem.PhysicalMemory[i]));
                }
                return list;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = data[e.RowIndex].Index;
            mem.set((uint)index,byte.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()));
        }
    }
}
