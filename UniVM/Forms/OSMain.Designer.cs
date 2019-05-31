namespace UniVM.Forms
{
    partial class OSMain
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
            this.ProcTableBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.StartProgramBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProcTableBtn
            // 
            this.ProcTableBtn.Location = new System.Drawing.Point(13, 13);
            this.ProcTableBtn.Name = "ProcTableBtn";
            this.ProcTableBtn.Size = new System.Drawing.Size(75, 23);
            this.ProcTableBtn.TabIndex = 0;
            this.ProcTableBtn.Text = "Processes";
            this.ProcTableBtn.UseVisualStyleBackColor = true;
            this.ProcTableBtn.Click += new System.EventHandler(this.ProcTableBtnClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Resources";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.resButtonClick);
            // 
            // StartProgramBtn
            // 
            this.StartProgramBtn.Location = new System.Drawing.Point(329, 13);
            this.StartProgramBtn.Name = "StartProgramBtn";
            this.StartProgramBtn.Size = new System.Drawing.Size(94, 23);
            this.StartProgramBtn.TabIndex = 2;
            this.StartProgramBtn.Text = "Start Program";
            this.StartProgramBtn.UseVisualStyleBackColor = true;
            this.StartProgramBtn.Click += new System.EventHandler(this.StartProgram);
            // 
            // OSMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 401);
            this.Controls.Add(this.StartProgramBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ProcTableBtn);
            this.Name = "OSMain";
            this.Text = "OSMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ProcTableBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button StartProgramBtn;
    }
}