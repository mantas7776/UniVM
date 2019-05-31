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
            this.label1.Location = new System.Drawing.Point(35, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Program name: ";
            // 
            // programNameInp
            // 
            this.programNameInp.Location = new System.Drawing.Point(151, 32);
            this.programNameInp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.programNameInp.Name = "programNameInp";
            this.programNameInp.Size = new System.Drawing.Size(224, 22);
            this.programNameInp.TabIndex = 1;
            // 
            // StartProgramBtn
            // 
            this.StartProgramBtn.Location = new System.Drawing.Point(399, 28);
            this.StartProgramBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartProgramBtn.Name = "StartProgramBtn";
            this.StartProgramBtn.Size = new System.Drawing.Size(100, 28);
            this.StartProgramBtn.TabIndex = 2;
            this.StartProgramBtn.Text = "Start program";
            this.StartProgramBtn.UseVisualStyleBackColor = true;
            this.StartProgramBtn.Click += new System.EventHandler(this.StartProgram);
            // 
            // ProgramStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 106);
            this.Controls.Add(this.StartProgramBtn);
            this.Controls.Add(this.programNameInp);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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