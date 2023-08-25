namespace IonSummer
{
    partial class frmIonSummer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIonSummer));
            this.btnCalculate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk1xsquare = new System.Windows.Forms.CheckBox();
            this.chk1x = new System.Windows.Forms.CheckBox();
            this.chkCustom = new System.Windows.Forms.CheckBox();
            this.dgvComponents = new System.Windows.Forms.DataGridView();
            this.gvrbtnCName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gvchkCName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gvtxtComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbISName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.chkNonAverage = new System.Windows.Forms.CheckBox();
            this.chkCName111 = new System.Windows.Forms.CheckedListBox();
            this.cmbRegT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grp2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEquation = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFormToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDefaultFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPDFDefaultFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.btnCalculate.Enabled = false;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(410, 75);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(119, 27);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk1xsquare);
            this.groupBox1.Controls.Add(this.chk1x);
            this.groupBox1.Controls.Add(this.chkCustom);
            this.groupBox1.Controls.Add(this.dgvComponents);
            this.groupBox1.Controls.Add(this.chkNonAverage);
            this.groupBox1.Controls.Add(this.chkCName111);
            this.groupBox1.Controls.Add(this.btnCalculate);
            this.groupBox1.Controls.Add(this.cmbRegT);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(534, 939);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibration Defaults";
            // 
            // chk1xsquare
            // 
            this.chk1xsquare.AutoSize = true;
            this.chk1xsquare.Location = new System.Drawing.Point(417, 29);
            this.chk1xsquare.Name = "chk1xsquare";
            this.chk1xsquare.Size = new System.Drawing.Size(64, 24);
            this.chk1xsquare.TabIndex = 15;
            this.chk1xsquare.Text = "1/x^2";
            this.chk1xsquare.UseVisualStyleBackColor = true;
            this.chk1xsquare.Visible = false;
            this.chk1xsquare.CheckedChanged += new System.EventHandler(this.chk1xsquare_CheckedChanged);
            // 
            // chk1x
            // 
            this.chk1x.AutoSize = true;
            this.chk1x.Location = new System.Drawing.Point(363, 28);
            this.chk1x.Name = "chk1x";
            this.chk1x.Size = new System.Drawing.Size(48, 24);
            this.chk1x.TabIndex = 14;
            this.chk1x.Text = "1/x";
            this.chk1x.UseVisualStyleBackColor = true;
            this.chk1x.Visible = false;
            this.chk1x.CheckedChanged += new System.EventHandler(this.chk1x_CheckedChanged);
            // 
            // chkCustom
            // 
            this.chkCustom.AutoSize = true;
            this.chkCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCustom.Location = new System.Drawing.Point(18, 83);
            this.chkCustom.Name = "chkCustom";
            this.chkCustom.Size = new System.Drawing.Size(213, 21);
            this.chkCustom.TabIndex = 13;
            this.chkCustom.Text = "Custom Concentration Values";
            this.chkCustom.UseVisualStyleBackColor = true;
            this.chkCustom.CheckedChanged += new System.EventHandler(this.chkCustom_CheckedChanged);
            // 
            // dgvComponents
            // 
            this.dgvComponents.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.dgvComponents.AllowUserToAddRows = false;
            this.dgvComponents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComponents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvrbtnCName,
            this.gvchkCName,
            this.gvtxtComponentName,
            this.cmbISName});
            this.dgvComponents.Location = new System.Drawing.Point(15, 107);
            this.dgvComponents.Name = "dgvComponents";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComponents.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComponents.Size = new System.Drawing.Size(514, 814);
            this.dgvComponents.TabIndex = 12;
            this.dgvComponents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponents_CellContentClick);
            this.dgvComponents.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComponents_CellValueChanged);
            // 
            // gvrbtnCName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.NullValue = false;
            this.gvrbtnCName.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvrbtnCName.HeaderText = "";
            this.gvrbtnCName.Name = "gvrbtnCName";
            this.gvrbtnCName.ReadOnly = true;
            this.gvrbtnCName.Visible = false;
            this.gvrbtnCName.Width = 30;
            // 
            // gvchkCName
            // 
            this.gvchkCName.HeaderText = "";
            this.gvchkCName.Name = "gvchkCName";
            this.gvchkCName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gvchkCName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gvchkCName.Width = 30;
            // 
            // gvtxtComponentName
            // 
            this.gvtxtComponentName.DataPropertyName = "ComponentName";
            this.gvtxtComponentName.HeaderText = "Component Name";
            this.gvtxtComponentName.Name = "gvtxtComponentName";
            this.gvtxtComponentName.ReadOnly = true;
            this.gvtxtComponentName.Width = 210;
            // 
            // cmbISName
            // 
            this.cmbISName.HeaderText = "Internal Standard";
            this.cmbISName.Name = "cmbISName";
            this.cmbISName.Width = 180;
            // 
            // chkNonAverage
            // 
            this.chkNonAverage.AutoSize = true;
            this.chkNonAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNonAverage.Location = new System.Drawing.Point(18, 60);
            this.chkNonAverage.Name = "chkNonAverage";
            this.chkNonAverage.Size = new System.Drawing.Size(200, 21);
            this.chkNonAverage.TabIndex = 10;
            this.chkNonAverage.Text = "Show Non-Average Plotting";
            this.chkNonAverage.UseVisualStyleBackColor = true;
            // 
            // chkCName111
            // 
            this.chkCName111.CheckOnClick = true;
            this.chkCName111.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCName111.FormattingEnabled = true;
            this.chkCName111.Location = new System.Drawing.Point(34, 659);
            this.chkCName111.Margin = new System.Windows.Forms.Padding(2);
            this.chkCName111.Name = "chkCName111";
            this.chkCName111.Size = new System.Drawing.Size(324, 850);
            this.chkCName111.TabIndex = 8;
            this.chkCName111.Visible = false;
            // 
            // cmbRegT
            // 
            this.cmbRegT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRegT.FormattingEnabled = true;
            this.cmbRegT.Items.AddRange(new object[] {
            "Linear",
            "Linear Through Zero",
            "Quadratic"});
            this.cmbRegT.Location = new System.Drawing.Point(132, 29);
            this.cmbRegT.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRegT.Name = "cmbRegT";
            this.cmbRegT.Size = new System.Drawing.Size(226, 24);
            this.cmbRegT.TabIndex = 4;
            this.cmbRegT.SelectedIndexChanged += new System.EventHandler(this.cmbRegT_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Regression Type";
            // 
            // grp2
            // 
            this.grp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp2.Location = new System.Drawing.Point(551, 26);
            this.grp2.Margin = new System.Windows.Forms.Padding(2);
            this.grp2.Name = "grp2";
            this.grp2.Padding = new System.Windows.Forms.Padding(2);
            this.grp2.Size = new System.Drawing.Size(1251, 874);
            this.grp2.TabIndex = 2;
            this.grp2.TabStop = false;
            this.grp2.Text = "Graph";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(554, 912);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Equation:";
            // 
            // txtEquation
            // 
            this.txtEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquation.Location = new System.Drawing.Point(640, 908);
            this.txtEquation.Margin = new System.Windows.Forms.Padding(2);
            this.txtEquation.Name = "txtEquation";
            this.txtEquation.Size = new System.Drawing.Size(446, 54);
            this.txtEquation.TabIndex = 6;
            this.txtEquation.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1823, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importDataToolStripMenuItem,
            this.viewHistoryToolStripMenuItem,
            this.saveSelectedComponentToolStripMenuItem,
            this.saveFormToPDFToolStripMenuItem,
            this.setDefaultFolderToolStripMenuItem,
            this.setPDFDefaultFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importDataToolStripMenuItem
            // 
            this.importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            this.importDataToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.importDataToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.importDataToolStripMenuItem.Text = "&Load Data";
            this.importDataToolStripMenuItem.Click += new System.EventHandler(this.importDataToolStripMenuItem_Click);
            // 
            // viewHistoryToolStripMenuItem
            // 
            this.viewHistoryToolStripMenuItem.Name = "viewHistoryToolStripMenuItem";
            this.viewHistoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.viewHistoryToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.viewHistoryToolStripMenuItem.Text = "View &History";
            this.viewHistoryToolStripMenuItem.Click += new System.EventHandler(this.viewHistoryToolStripMenuItem_Click);
            // 
            // saveSelectedComponentToolStripMenuItem
            // 
            this.saveSelectedComponentToolStripMenuItem.Name = "saveSelectedComponentToolStripMenuItem";
            this.saveSelectedComponentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveSelectedComponentToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.saveSelectedComponentToolStripMenuItem.Text = "&Save Selected Component";
            this.saveSelectedComponentToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedComponentToolStripMenuItem_Click_1);
            // 
            // saveFormToPDFToolStripMenuItem
            // 
            this.saveFormToPDFToolStripMenuItem.Name = "saveFormToPDFToolStripMenuItem";
            this.saveFormToPDFToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.saveFormToPDFToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.saveFormToPDFToolStripMenuItem.Text = "&Export To PDF";
            this.saveFormToPDFToolStripMenuItem.Click += new System.EventHandler(this.saveFormToPDFToolStripMenuItem_Click);
            // 
            // setDefaultFolderToolStripMenuItem
            // 
            this.setDefaultFolderToolStripMenuItem.Name = "setDefaultFolderToolStripMenuItem";
            this.setDefaultFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.setDefaultFolderToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.setDefaultFolderToolStripMenuItem.Text = "Set Default &Folder";
            this.setDefaultFolderToolStripMenuItem.Click += new System.EventHandler(this.setDefaultFolderToolStripMenuItem_Click);
            // 
            // setPDFDefaultFolderToolStripMenuItem
            // 
            this.setPDFDefaultFolderToolStripMenuItem.Name = "setPDFDefaultFolderToolStripMenuItem";
            this.setPDFDefaultFolderToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.setPDFDefaultFolderToolStripMenuItem.Text = "Set PDF Default Folder";
            this.setPDFDefaultFolderToolStripMenuItem.Click += new System.EventHandler(this.setPDFDefaultFolderToolStripMenuItem_Click);
            // 
            // frmIonSummer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1823, 976);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEquation);
            this.Controls.Add(this.grp2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmIonSummer";
            this.Text = "IonSummer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComponents)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbRegT;
        private System.Windows.Forms.GroupBox grp2;
        private System.Windows.Forms.CheckedListBox chkCName111;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox txtEquation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFormToPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDataToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkNonAverage;
        private System.Windows.Forms.ToolStripMenuItem setDefaultFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedComponentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPDFDefaultFolderToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvComponents;
        private System.Windows.Forms.CheckBox chkCustom;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gvrbtnCName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gvchkCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gvtxtComponentName;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbISName;
        private System.Windows.Forms.CheckBox chk1x;
        private System.Windows.Forms.CheckBox chk1xsquare;
    }
}

