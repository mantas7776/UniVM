namespace UniVM.Forms
{
    partial class ProgramStart
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
            this.label1 = new System.Windows.Forms.Label();
            this.programNameInp = new System.Windows.Forms.TextBox();
            this.StartProgramBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Program name: ";
            // 
            // programNameInp
            // 
            this.programNameInp.Location = new System.Drawing.Point(113, 26);
            this.programNameInp.Name = "programNameInp";
            this.programNameInp.Size = new System.Drawing.Size(169, 20);
            this.programNameInp.TabIndex = 1;
            // 
            // StartProgramBtn
            // 
            this.StartProgramBtn.Location = new System.Drawing.Point(299, 23);
            this.StartProgramBtn.Name = "StartProgramBtn";
            this.StartProgramBtn.Size = new System.Drawing.Size(69, 51);
            this.StartProgramBtn.TabIndex = 2;
            this.StartProgramBtn.Text = "Start program";
            this.StartProgramBtn.UseVisualStyleBackColor = true;
            this.StartProgramBtn.Click += new System.EventHandler(this.StartProgram);
            // 
            // ProgramStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 86);
            this.Controls.Add(this.StartProgramBtn);
            this.Controls.Add(this.programNameInp);
            this.Controls.Add(this.label1);
            this.Name = "ProgramStart";
            this.Text = "ProgramStart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox programNameInp;
        private System.Windows.Forms.Button StartProgramBtn;
    }
}