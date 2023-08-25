
namespace IonSummer
{
    partial class frmReverseCalculation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReverseCalculation));
            this.dgvCalculatedConcentration = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculatedConcentration)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCalculatedConcentration
            // 
            this.dgvCalculatedConcentration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalculatedConcentration.Location = new System.Drawing.Point(12, 12);
            this.dgvCalculatedConcentration.Name = "dgvCalculatedConcentration";
            this.dgvCalculatedConcentration.Size = new System.Drawing.Size(1608, 807);
            this.dgvCalculatedConcentration.TabIndex = 0;
            // 
            // frmReverseCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 831);
            this.Controls.Add(this.dgvCalculatedConcentration);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReverseCalculation";
            this.Text = "Calculated Concentrations";
            this.Load += new System.EventHandler(this.frmReverseCalculation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalculatedConcentration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCalculatedConcentration;
    }
}