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
            btnCalculate = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            chk1xsquare = new System.Windows.Forms.CheckBox();
            chk1x = new System.Windows.Forms.CheckBox();
            chkCustom = new System.Windows.Forms.CheckBox();
            dgvComponents = new System.Windows.Forms.DataGridView();
            gvrbtnCName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            gvchkCName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            gvtxtComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cmbISName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            chkNonAverage = new System.Windows.Forms.CheckBox();
            chkCName111 = new System.Windows.Forms.CheckedListBox();
            cmbRegT = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            grp2 = new System.Windows.Forms.GroupBox();
            label6 = new System.Windows.Forms.Label();
            txtEquation = new System.Windows.Forms.RichTextBox();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveSelectedComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveFormToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            setDefaultFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            setPDFDefaultFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComponents).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCalculate
            // 
            btnCalculate.Enabled = false;
            btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnCalculate.Location = new System.Drawing.Point(470, 86);
            btnCalculate.Margin = new System.Windows.Forms.Padding(2);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new System.Drawing.Size(139, 31);
            btnCalculate.TabIndex = 0;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chk1xsquare);
            groupBox1.Controls.Add(chk1x);
            groupBox1.Controls.Add(chkCustom);
            groupBox1.Controls.Add(dgvComponents);
            groupBox1.Controls.Add(chkNonAverage);
            groupBox1.Controls.Add(chkCName111);
            groupBox1.Controls.Add(btnCalculate);
            groupBox1.Controls.Add(cmbRegT);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            groupBox1.Location = new System.Drawing.Point(9, 30);
            groupBox1.Margin = new System.Windows.Forms.Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(2);
            groupBox1.Size = new System.Drawing.Size(623, 981);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Calibration Defaults";
            // 
            // chk1xsquare
            // 
            chk1xsquare.AutoSize = true;
            chk1xsquare.Location = new System.Drawing.Point(486, 33);
            chk1xsquare.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk1xsquare.Name = "chk1xsquare";
            chk1xsquare.Size = new System.Drawing.Size(64, 24);
            chk1xsquare.TabIndex = 15;
            chk1xsquare.Text = "1/x^2";
            chk1xsquare.UseVisualStyleBackColor = true;
            chk1xsquare.Visible = false;
            chk1xsquare.CheckedChanged += chk1xsquare_CheckedChanged;
            // 
            // chk1x
            // 
            chk1x.AutoSize = true;
            chk1x.Location = new System.Drawing.Point(424, 32);
            chk1x.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk1x.Name = "chk1x";
            chk1x.Size = new System.Drawing.Size(48, 24);
            chk1x.TabIndex = 14;
            chk1x.Text = "1/x";
            chk1x.UseVisualStyleBackColor = true;
            chk1x.Visible = false;
            chk1x.CheckedChanged += chk1x_CheckedChanged;
            // 
            // chkCustom
            // 
            chkCustom.AutoSize = true;
            chkCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chkCustom.Location = new System.Drawing.Point(21, 96);
            chkCustom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkCustom.Name = "chkCustom";
            chkCustom.Size = new System.Drawing.Size(213, 21);
            chkCustom.TabIndex = 13;
            chkCustom.Text = "Custom Concentration Values";
            chkCustom.UseVisualStyleBackColor = true;
            chkCustom.CheckedChanged += chkCustom_CheckedChanged;
            // 
            // dgvComponents
            // 
            dgvComponents.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            dgvComponents.AllowUserToAddRows = false;
            dgvComponents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvComponents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvComponents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { gvrbtnCName, gvchkCName, gvtxtComponentName, cmbISName });
            dgvComponents.Location = new System.Drawing.Point(18, 127);
            dgvComponents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvComponents.Name = "dgvComponents";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvComponents.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvComponents.Size = new System.Drawing.Size(591, 841);
            dgvComponents.TabIndex = 12;
            dgvComponents.CellContentClick += dgvComponents_CellContentClick;
            dgvComponents.CellValueChanged += dgvComponents_CellValueChanged;
            // 
            // gvrbtnCName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.NullValue = false;
            gvrbtnCName.DefaultCellStyle = dataGridViewCellStyle2;
            gvrbtnCName.HeaderText = "";
            gvrbtnCName.Name = "gvrbtnCName";
            gvrbtnCName.ReadOnly = true;
            gvrbtnCName.Visible = false;
            gvrbtnCName.Width = 30;
            // 
            // gvchkCName
            // 
            gvchkCName.HeaderText = "";
            gvchkCName.Name = "gvchkCName";
            gvchkCName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            gvchkCName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            gvchkCName.Width = 30;
            // 
            // gvtxtComponentName
            // 
            gvtxtComponentName.DataPropertyName = "ComponentName";
            gvtxtComponentName.HeaderText = "Component Name";
            gvtxtComponentName.Name = "gvtxtComponentName";
            gvtxtComponentName.ReadOnly = true;
            gvtxtComponentName.Width = 210;
            // 
            // cmbISName
            // 
            cmbISName.HeaderText = "Internal Standard";
            cmbISName.Name = "cmbISName";
            cmbISName.Width = 180;
            // 
            // chkNonAverage
            // 
            chkNonAverage.AutoSize = true;
            chkNonAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chkNonAverage.Location = new System.Drawing.Point(21, 69);
            chkNonAverage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkNonAverage.Name = "chkNonAverage";
            chkNonAverage.Size = new System.Drawing.Size(200, 21);
            chkNonAverage.TabIndex = 10;
            chkNonAverage.Text = "Show Non-Average Plotting";
            chkNonAverage.UseVisualStyleBackColor = true;
            // 
            // chkCName111
            // 
            chkCName111.CheckOnClick = true;
            chkCName111.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            chkCName111.FormattingEnabled = true;
            chkCName111.Location = new System.Drawing.Point(40, 760);
            chkCName111.Margin = new System.Windows.Forms.Padding(2);
            chkCName111.Name = "chkCName111";
            chkCName111.Size = new System.Drawing.Size(377, 976);
            chkCName111.TabIndex = 8;
            chkCName111.Visible = false;
            // 
            // cmbRegT
            // 
            cmbRegT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbRegT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cmbRegT.FormattingEnabled = true;
            cmbRegT.Items.AddRange(new object[] { "Linear", "Linear Through Zero", "Quadratic" });
            cmbRegT.Location = new System.Drawing.Point(154, 33);
            cmbRegT.Margin = new System.Windows.Forms.Padding(2);
            cmbRegT.Name = "cmbRegT";
            cmbRegT.Size = new System.Drawing.Size(263, 24);
            cmbRegT.TabIndex = 4;
            cmbRegT.SelectedIndexChanged += cmbRegT_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(14, 37);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(116, 17);
            label2.TabIndex = 1;
            label2.Text = "Regression Type";
            // 
            // grp2
            // 
            grp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            grp2.Location = new System.Drawing.Point(641, 30);
            grp2.Margin = new System.Windows.Forms.Padding(2);
            grp2.Name = "grp2";
            grp2.Padding = new System.Windows.Forms.Padding(2);
            grp2.Size = new System.Drawing.Size(1272, 891);
            grp2.TabIndex = 2;
            grp2.TabStop = false;
            grp2.Text = "Graph";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(646, 932);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(68, 17);
            label6.TabIndex = 7;
            label6.Text = "Equation:";
            // 
            // txtEquation
            // 
            txtEquation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtEquation.Location = new System.Drawing.Point(718, 936);
            txtEquation.Margin = new System.Windows.Forms.Padding(2);
            txtEquation.Name = "txtEquation";
            txtEquation.Size = new System.Drawing.Size(520, 62);
            txtEquation.TabIndex = 6;
            txtEquation.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(1924, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { importDataToolStripMenuItem, viewHistoryToolStripMenuItem, saveSelectedComponentToolStripMenuItem, saveFormToPDFToolStripMenuItem, setDefaultFolderToolStripMenuItem, setPDFDefaultFolderToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // importDataToolStripMenuItem
            // 
            importDataToolStripMenuItem.Name = "importDataToolStripMenuItem";
            importDataToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L;
            importDataToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            importDataToolStripMenuItem.Text = "&Load Data";
            importDataToolStripMenuItem.Click += importDataToolStripMenuItem_Click;
            // 
            // viewHistoryToolStripMenuItem
            // 
            viewHistoryToolStripMenuItem.Name = "viewHistoryToolStripMenuItem";
            viewHistoryToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H;
            viewHistoryToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            viewHistoryToolStripMenuItem.Text = "View &History";
            viewHistoryToolStripMenuItem.Click += viewHistoryToolStripMenuItem_Click;
            // 
            // saveSelectedComponentToolStripMenuItem
            // 
            saveSelectedComponentToolStripMenuItem.Name = "saveSelectedComponentToolStripMenuItem";
            saveSelectedComponentToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S;
            saveSelectedComponentToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            saveSelectedComponentToolStripMenuItem.Text = "&Save Selected Component";
            saveSelectedComponentToolStripMenuItem.Click += saveSelectedComponentToolStripMenuItem_Click_1;
            // 
            // saveFormToPDFToolStripMenuItem
            // 
            saveFormToPDFToolStripMenuItem.Name = "saveFormToPDFToolStripMenuItem";
            saveFormToPDFToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E;
            saveFormToPDFToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            saveFormToPDFToolStripMenuItem.Text = "&Export To PDF";
            saveFormToPDFToolStripMenuItem.Click += saveFormToPDFToolStripMenuItem_Click;
            // 
            // setDefaultFolderToolStripMenuItem
            // 
            setDefaultFolderToolStripMenuItem.Name = "setDefaultFolderToolStripMenuItem";
            setDefaultFolderToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F;
            setDefaultFolderToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            setDefaultFolderToolStripMenuItem.Text = "Set Default &Folder";
            setDefaultFolderToolStripMenuItem.Click += setDefaultFolderToolStripMenuItem_Click;
            // 
            // setPDFDefaultFolderToolStripMenuItem
            // 
            setPDFDefaultFolderToolStripMenuItem.Name = "setPDFDefaultFolderToolStripMenuItem";
            setPDFDefaultFolderToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            setPDFDefaultFolderToolStripMenuItem.Text = "Set PDF Default Folder";
            setPDFDefaultFolderToolStripMenuItem.Click += setPDFDefaultFolderToolStripMenuItem_Click;
            // 
            // frmIonSummer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1924, 1022);
            Controls.Add(label6);
            Controls.Add(txtEquation);
            Controls.Add(grp2);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(2);
            Name = "frmIonSummer";
            Text = "IonSummer";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComponents).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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

