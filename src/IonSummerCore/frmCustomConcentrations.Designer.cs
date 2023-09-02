
namespace IonSummer
{
    partial class frmCustomConcentrations
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCustomConcentration = new System.Windows.Forms.DataGridView();
            this.txtSampleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtConcentration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomConcentration)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomConcentration
            // 
            this.dgvCustomConcentration.AllowUserToAddRows = false;
            this.dgvCustomConcentration.AllowUserToDeleteRows = false;
            this.dgvCustomConcentration.AllowUserToResizeColumns = false;
            this.dgvCustomConcentration.AllowUserToResizeRows = false;
            this.dgvCustomConcentration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomConcentration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSampleName,
            this.txtConcentration});
            this.dgvCustomConcentration.Location = new System.Drawing.Point(12, 12);
            this.dgvCustomConcentration.Name = "dgvCustomConcentration";
            this.dgvCustomConcentration.Size = new System.Drawing.Size(322, 530);
            this.dgvCustomConcentration.TabIndex = 0;
            this.dgvCustomConcentration.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCustomConcentration_CellValidating);
            // 
            // txtSampleName
            // 
            this.txtSampleName.HeaderText = "Sample Name";
            this.txtSampleName.Name = "txtSampleName";
            this.txtSampleName.ReadOnly = true;
            this.txtSampleName.Width = 150;
            // 
            // txtConcentration
            // 
            dataGridViewCellStyle5.Format = "N6";
            dataGridViewCellStyle5.NullValue = null;
            this.txtConcentration.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtConcentration.HeaderText = "Concentration";
            this.txtConcentration.Name = "txtConcentration";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(97, 558);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(178, 558);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // frmCustomConcentrations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 596);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvCustomConcentration);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomConcentrations";
            this.Text = "Custom Concentration Values";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomConcentration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSampleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtConcentration;
        public System.Windows.Forms.DataGridView dgvCustomConcentration;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}