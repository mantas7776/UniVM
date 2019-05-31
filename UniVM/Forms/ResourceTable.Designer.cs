namespace UniVM.Forms
{
    partial class ResourceTable
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdByProcessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staticResDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.assignedToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiredDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.messageidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeDataGridViewTextBoxColumn,
            this.createdByProcessDataGridViewTextBoxColumn,
            this.staticResDataGridViewCheckBoxColumn,
            this.assignedToDataGridViewTextBoxColumn,
            this.expiredDataGridViewCheckBoxColumn,
            this.messageidDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.resourceBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(24, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(648, 380);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdByProcessDataGridViewTextBoxColumn
            // 
            this.createdByProcessDataGridViewTextBoxColumn.DataPropertyName = "createdByProcess";
            this.createdByProcessDataGridViewTextBoxColumn.HeaderText = "createdByProcess";
            this.createdByProcessDataGridViewTextBoxColumn.Name = "createdByProcessDataGridViewTextBoxColumn";
            this.createdByProcessDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // staticResDataGridViewCheckBoxColumn
            // 
            this.staticResDataGridViewCheckBoxColumn.DataPropertyName = "staticRes";
            this.staticResDataGridViewCheckBoxColumn.HeaderText = "staticRes";
            this.staticResDataGridViewCheckBoxColumn.Name = "staticResDataGridViewCheckBoxColumn";
            this.staticResDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // assignedToDataGridViewTextBoxColumn
            // 
            this.assignedToDataGridViewTextBoxColumn.DataPropertyName = "assignedTo";
            this.assignedToDataGridViewTextBoxColumn.HeaderText = "assignedTo";
            this.assignedToDataGridViewTextBoxColumn.Name = "assignedToDataGridViewTextBoxColumn";
            this.assignedToDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // expiredDataGridViewCheckBoxColumn
            // 
            this.expiredDataGridViewCheckBoxColumn.DataPropertyName = "expired";
            this.expiredDataGridViewCheckBoxColumn.HeaderText = "expired";
            this.expiredDataGridViewCheckBoxColumn.Name = "expiredDataGridViewCheckBoxColumn";
            this.expiredDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // messageidDataGridViewTextBoxColumn
            // 
            this.messageidDataGridViewTextBoxColumn.DataPropertyName = "Messageid";
            this.messageidDataGridViewTextBoxColumn.HeaderText = "Messageid";
            this.messageidDataGridViewTextBoxColumn.Name = "messageidDataGridViewTextBoxColumn";
            this.messageidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resourceBindingSource
            // 
            this.resourceBindingSource.DataSource = typeof(UniVM.Resource);
            this.resourceBindingSource.CurrentChanged += new System.EventHandler(this.ResourceBindingSource_CurrentChanged);
            // 
            // ResourceTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 525);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ResourceTable";
            this.Text = "ResourceTable";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdByProcessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn staticResDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignedToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn expiredDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageidDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource resourceBindingSource;
    }
}