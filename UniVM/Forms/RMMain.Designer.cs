namespace UniVM.Forms
{
    partial class RMMain
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.VmList = new System.Windows.Forms.ListBox();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Registers";
            this.dataGridViewTextBoxColumn1.HeaderText = "Registers";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Atmintis";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // VmList
            // 
            this.VmList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.VmList.FormattingEnabled = true;
            this.VmList.Location = new System.Drawing.Point(13, 13);
            this.VmList.Name = "VmList";
            this.VmList.Size = new System.Drawing.Size(286, 329);
            this.VmList.TabIndex = 4;
            this.VmList.DoubleClick += new System.EventHandler(this.VmList_DoubleClick);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(UniVM.Program);
            // 
            // registersBindingSource
            // 
            this.registersBindingSource.DataSource = typeof(UniVM.Registers);
            // 
            // RMMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(419, 358);
            this.Controls.Add(this.VmList);
            this.Controls.Add(this.button1);
            this.Name = "RMMain";
            this.Text = "RMMain";
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.BindingSource registersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox VmList;
    }
}