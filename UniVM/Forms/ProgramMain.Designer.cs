namespace UniVM.Forms
{
    public partial class ProgramMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPTR = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPTRI = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxFLAGS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTIMER = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxDS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nextCmdLabel = new System.Windows.Forms.Label();
            this.textBoxPI = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxSI = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.registersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.registersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.registersBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "A:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(83, 70);
            this.textBoxA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(132, 22);
            this.textBoxA.TabIndex = 3;
            this.textBoxA.TextChanged += new System.EventHandler(this.TextBoxA_TextChanged);
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(83, 102);
            this.textBoxB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(132, 22);
            this.textBoxB.TabIndex = 5;
            this.textBoxB.TextChanged += new System.EventHandler(this.TextBoxB_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "B:";
            // 
            // textBoxCX
            // 
            this.textBoxCX.Location = new System.Drawing.Point(83, 134);
            this.textBoxCX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCX.Name = "textBoxCX";
            this.textBoxCX.Size = new System.Drawing.Size(132, 22);
            this.textBoxCX.TabIndex = 7;
            this.textBoxCX.TextChanged += new System.EventHandler(this.TextBoxCX_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "CX:";
            // 
            // textBoxPTR
            // 
            this.textBoxPTR.Location = new System.Drawing.Point(83, 166);
            this.textBoxPTR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPTR.Name = "textBoxPTR";
            this.textBoxPTR.Size = new System.Drawing.Size(132, 22);
            this.textBoxPTR.TabIndex = 9;
            this.textBoxPTR.TextChanged += new System.EventHandler(this.TextBoxPTR_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "PTR:";
            // 
            // textBoxPTRI
            // 
            this.textBoxPTRI.Location = new System.Drawing.Point(83, 198);
            this.textBoxPTRI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPTRI.Name = "textBoxPTRI";
            this.textBoxPTRI.Size = new System.Drawing.Size(132, 22);
            this.textBoxPTRI.TabIndex = 11;
            this.textBoxPTRI.TextChanged += new System.EventHandler(this.TextBoxPTRI_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 202);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "PTRI:";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(83, 230);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(132, 22);
            this.textBoxIP.TabIndex = 13;
            this.textBoxIP.TextChanged += new System.EventHandler(this.TextBoxIP_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 234);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "IP:";
            // 
            // textBoxFLAGS
            // 
            this.textBoxFLAGS.Location = new System.Drawing.Point(83, 262);
            this.textBoxFLAGS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFLAGS.Name = "textBoxFLAGS";
            this.textBoxFLAGS.Size = new System.Drawing.Size(132, 22);
            this.textBoxFLAGS.TabIndex = 15;
            this.textBoxFLAGS.TextChanged += new System.EventHandler(this.TextBoxFLAGS_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 266);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "FLAGS:";
            // 
            // textBoxCS
            // 
            this.textBoxCS.Location = new System.Drawing.Point(83, 294);
            this.textBoxCS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCS.Name = "textBoxCS";
            this.textBoxCS.Size = new System.Drawing.Size(132, 22);
            this.textBoxCS.TabIndex = 17;
            this.textBoxCS.TextChanged += new System.EventHandler(this.TextBoxCS_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 298);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "CS:";
            // 
            // textBoxTIMER
            // 
            this.textBoxTIMER.Location = new System.Drawing.Point(83, 326);
            this.textBoxTIMER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTIMER.Name = "textBoxTIMER";
            this.textBoxTIMER.Size = new System.Drawing.Size(132, 22);
            this.textBoxTIMER.TabIndex = 19;
            this.textBoxTIMER.TextChanged += new System.EventHandler(this.TextBoxTIMER_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 330);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "TIMER:";
            // 
            // textBoxDS
            // 
            this.textBoxDS.Location = new System.Drawing.Point(83, 358);
            this.textBoxDS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDS.Name = "textBoxDS";
            this.textBoxDS.Size = new System.Drawing.Size(132, 22);
            this.textBoxDS.TabIndex = 21;
            this.textBoxDS.TextChanged += new System.EventHandler(this.TextBoxDS_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 362);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "DS:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 32);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Registers:";
            // 
            // nextCmdLabel
            // 
            this.nextCmdLabel.AutoSize = true;
            this.nextCmdLabel.Location = new System.Drawing.Point(279, 32);
            this.nextCmdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nextCmdLabel.Name = "nextCmdLabel";
            this.nextCmdLabel.Size = new System.Drawing.Size(121, 17);
            this.nextCmdLabel.TabIndex = 23;
            this.nextCmdLabel.Text = "Sekanti komanda:";
            // 
            // textBoxPI
            // 
            this.textBoxPI.Location = new System.Drawing.Point(83, 390);
            this.textBoxPI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPI.Name = "textBoxPI";
            this.textBoxPI.Size = new System.Drawing.Size(132, 22);
            this.textBoxPI.TabIndex = 26;
            this.textBoxPI.TextChanged += new System.EventHandler(this.TextBoxPI_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 394);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 17);
            this.label12.TabIndex = 25;
            this.label12.Text = "PI:";
            // 
            // textBoxSI
            // 
            this.textBoxSI.Location = new System.Drawing.Point(83, 422);
            this.textBoxSI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSI.Name = "textBoxSI";
            this.textBoxSI.Size = new System.Drawing.Size(132, 22);
            this.textBoxSI.TabIndex = 28;
            this.textBoxSI.TextChanged += new System.EventHandler(this.TextBoxSI_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 426);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "SI:";
            // 
            // registersBindingSource1
            // 
            this.registersBindingSource1.DataSource = typeof(UniVM.Registers);
            // 
            // registersBindingSource
            // 
            this.registersBindingSource.DataSource = typeof(UniVM.Registers);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 64);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 29;
            this.button1.Text = "Programos virtuali atmintis";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ProgramMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 593);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSI);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxPI);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.nextCmdLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBoxDS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxTIMER);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxCS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxFLAGS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPTRI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPTR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProgramMain";
            this.Text = "ProgramMain";
            ((System.ComponentModel.ISupportInitialize)(this.registersBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource registersBindingSource;
        private System.Windows.Forms.BindingSource registersBindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPTR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPTRI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxFLAGS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTIMER;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxDS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label nextCmdLabel;
        private System.Windows.Forms.TextBox textBoxPI;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxSI;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button1;
    }
}