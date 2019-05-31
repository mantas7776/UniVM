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
        public ProgramMain(Program program)
        {
            InitializeComponent();
            this.program = program;
            textBoxA.DataBindings.Add("Text", this.program.registers, "A", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxB.DataBindings.Add("Text", this.program.registers, "B", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCX.DataBindings.Add("Text", this.program.registers, "CX", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxPTR.DataBindings.Add("Text", this.program.registers, "PTR", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxPTRI.DataBindings.Add("Text", this.program.registers, "PTRI", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxIP.DataBindings.Add("Text", this.program.registers, "IP", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxFLAGS.DataBindings.Add("Text", this.program.registers, "FLAGS", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxCS.DataBindings.Add("Text", this.program.registers, "CS", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxTIMER.DataBindings.Add("Text", this.program.registers, "TIMER", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxDS.DataBindings.Add("Text", this.program.registers, "DS", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxSI.DataBindings.Add("Text", this.program.registers, "SI", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxPI.DataBindings.Add("Text", this.program.registers, "PI", false, DataSourceUpdateMode.OnPropertyChanged);
            nextCmdLabel.DataBindings.Add("Text", this.nextCmd, "", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private string nextCmd 
        {
            get
            {
                Registers regs = this.program.registers;
                uint codeSegByteCount = regs.DS - regs.CS;
                byte[] codeSegBytes = program.memAccesser.readFromAddr(regs.CS, codeSegByteCount);
                string codeString = Encoding.ASCII.GetString(codeSegBytes);
                string[] code = codeString.Split('\n');

                string instructionLine = code[regs.IP + 1];
                return "Sekanti komanda: " + instructionLine;
            }
        }

        private void TextBoxA_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.A = uint.Parse(textBoxA.Text);
        }

        private void TextBoxB_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.B = uint.Parse(textBoxB.Text);
        }

        private void TextBoxCX_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.CX = uint.Parse(textBoxCX.Text);
        }

        private void TextBoxPTR_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.PTR = uint.Parse(textBoxPTR.Text);
        }

        private void TextBoxPTRI_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.PTRI = uint.Parse(textBoxPTRI.Text);
        }

        private void TextBoxIP_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.IP = uint.Parse(textBoxIP.Text);
        }

        private void TextBoxFLAGS_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.FLAGS = uint.Parse(textBoxFLAGS.Text);
        }

        private void TextBoxCS_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.CS = uint.Parse(textBoxCS.Text);
        }

        private void TextBoxTIMER_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.TIMER = uint.Parse(textBoxTIMER.Text);
        }

        private void TextBoxDS_TextChanged(object sender, EventArgs e)
        {
            this.program.registers.DS = uint.Parse(textBoxDS.Text);
        }

        private void TextBoxPI_TextChanged(object sender, EventArgs e)
        {
            //this.program.registers.PI = (PiInt)Enum.Parse(typeof(PiInt),textBoxPI.Text);
        }

        private void TextBoxSI_TextChanged(object sender, EventArgs e)
        {
            //this.program.registers.SI = (SiInt)Enum.Parse(typeof(SiInt), textBoxPI.Text);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new VMMemGui(program.memAccesser).Show();
        }
    }
}
