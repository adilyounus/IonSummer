using IonSummer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IonSummer
{
    public partial class frmReverseCalculation : Form
    {
        public dynamic lstData;
        public string GraphFileName;
        public bool hideform;
        public frmReverseCalculation()
        {
            InitializeComponent();
        }

        private void frmReverseCalculation_Load(object sender, EventArgs e)
        {
            dgvCalculatedConcentration.DataSource = lstData;
            dgvCalculatedConcentration.AutoResizeColumns();
            dgvCalculatedConcentration.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            foreach (DataGridViewColumn item in dgvCalculatedConcentration.Columns)
            {
                item.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (item.HeaderText.StartsWith("h_"))
                {
                    item.Visible = false;
                }
            }

            if (hideform)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Size = new Size(0, 0);
            }

        }
    }
}
