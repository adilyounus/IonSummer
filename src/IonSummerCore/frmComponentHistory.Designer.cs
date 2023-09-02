
namespace IonSummer
{
    partial class frmComponentHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComponentHistory));
            this.dgvComponentHistory = new System.Windows.Forms.DataGridView();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRegressionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComponents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnView = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCombined = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvComponentHistory
            // 
            this.dgvComponentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSelect,
            this.txtID,
            this.txtRegressionType,
            this.txtComponents,
            this.txtCreatedOn,
            this.btnView,
            this.btnDelete});
            this.dgvComponentHistory.Location = new System.Drawing.Point(12, 41);
            this.dgvComponentHistory.Name = "dgvComponentHistory";
            this.dgvComponentHistory.Size = new System.Drawing.Size(1777, 734);
            this.dgvComponentHistory.TabIndex = 0;
            this.dgvComponentHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponentHistory_CellContentClick);
            // 
            // chkSelect
            // 
            this.chkSelect.HeaderText = "";
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Width = 50;
            // 
            // txtID
            // 
            this.txtID.DataPropertyName = "ID";
            this.txtID.HeaderText = "ID";
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Visible = false;
            // 
            // txtRegressionType
            // 
            this.txtRegressionType.DataPropertyName = "RegressionType";
            this.txtRegressionType.HeaderText = "Regression Type";
            this.txtRegressionType.Name = "txtRegressionType";
            this.txtRegressionType.ReadOnly = true;
            // 
            // txtComponents
            // 
            this.txtComponents.DataPropertyName = "Components";
            this.txtComponents.HeaderText = "Components";
            this.txtComponents.Name = "txtComponents";
            this.txtComponents.ReadOnly = true;
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.DataPropertyName = "CreatedOn";
            this.txtCreatedOn.HeaderText = "Created On";
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.ReadOnly = true;
            // 
            // btnView
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "View";
            this.btnView.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnView.HeaderText = "View";
            this.btnView.Name = "btnView";
            this.btnView.Text = "View";
            // 
            // btnDelete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "Delete";
            this.btnDelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.btnDelete.HeaderText = "Delete";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "Delete";
            // 
            // btnCombined
            // 
            this.btnCombined.Location = new System.Drawing.Point(12, 12);
            this.btnCombined.Name = "btnCombined";
            this.btnCombined.Size = new System.Drawing.Size(115, 23);
            this.btnCombined.TabIndex = 1;
            this.btnCombined.Text = "View Combined";
            this.btnCombined.UseVisualStyleBackColor = true;
            this.btnCombined.Click += new System.EventHandler(this.btnCombined_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(133, 12);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(188, 23);
            this.btnPDF.TabIndex = 2;
            this.btnPDF.Text = "Combined and Export To PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(327, 12);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteAll.TabIndex = 3;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // frmComponentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1801, 787);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnCombined);
            this.Controls.Add(this.dgvComponentHistory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmComponentHistory";
            this.Text = "Component History";
            this.Load += new System.EventHandler(this.frmComponentHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponentHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvComponentHistory;
        private System.Windows.Forms.Button btnCombined;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRegressionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtComponents;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCreatedOn;
        private System.Windows.Forms.DataGridViewButtonColumn btnView;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnDeleteAll;
    }
}