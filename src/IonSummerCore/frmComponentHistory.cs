using IonSummer.Models;
using Newtonsoft.Json;
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
    public partial class frmComponentHistory : Form
    {
        public frmComponentHistory()
        {
            InitializeComponent();
        }

        public dynamic lstData = null;
        private void frmComponentHistory_Load(object sender, EventArgs e)
        {
            dgvComponentHistory.DataSource = lstData;
            dgvComponentHistory.AutoResizeColumns();
            dgvComponentHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dgvComponentHistory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string ID = dgvComponentHistory.Rows[e.RowIndex].Cells[3].Value.ToString();
                ((frmIonSummer)this.Owner).viewID = new List<string>();
                ((frmIonSummer)this.Owner).viewID.Add(ID);
                ((frmIonSummer)this.Owner).ViewAndExport = false;
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (e.ColumnIndex == 2)
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string ID = dgvComponentHistory.Rows[e.RowIndex].Cells[3].Value.ToString();
                    var lstMasterData = JsonConvert.DeserializeObject<List<ReverseCalculationMasterModel>>(File.ReadAllText("dbIonSummer.json"));

                    lstMasterData.Remove(lstMasterData.Where(w => w.ID == ID).FirstOrDefault());

                    File.WriteAllText("dbIonSummer.json", JsonConvert.SerializeObject(lstMasterData));

                    var HistoryData = lstMasterData.Select(s => new { s.ID, RegressionType = s.RegressionType.ToString().Replace("_", " "), Components = s.Components, s.CreatedOn }).ToList();

                    dgvComponentHistory.DataSource = HistoryData;
                }

            }
        }

        private void btnCombined_Click(object sender, EventArgs e)
        {
            ((frmIonSummer)this.Owner).viewID = new List<string>();
            foreach (DataGridViewRow dRow in dgvComponentHistory.Rows)
            {
                if (Convert.ToBoolean(dRow.Cells[0].EditedFormattedValue) == true)
                {
                    string ID = dRow.Cells[3].Value.ToString();
                    ((frmIonSummer)this.Owner).viewID.Add(ID);
                }
            }
            if (((frmIonSummer)this.Owner).viewID.Count > 0)
            {
                ((frmIonSummer)this.Owner).ViewAndExport = false;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select records to view");
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all the records?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var lstMasterData = JsonConvert.DeserializeObject<List<ReverseCalculationMasterModel>>(File.ReadAllText("dbIonSummer.json"));

                foreach (DataGridViewRow drow in dgvComponentHistory.Rows)
                {
                    string ID = dgvComponentHistory.Rows[drow.Index].Cells[3].Value.ToString();
                    lstMasterData.Remove(lstMasterData.Where(w => w.ID == ID).FirstOrDefault());
                }

                File.WriteAllText("dbIonSummer.json", JsonConvert.SerializeObject(lstMasterData));

                var HistoryData = lstMasterData.Select(s => new { s.ID, RegressionType = s.RegressionType.ToString().Replace("_", " "), Components = s.Components, s.CreatedOn }).ToList();

                dgvComponentHistory.DataSource = HistoryData;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            ((frmIonSummer)this.Owner).viewID = new List<string>();
            foreach (DataGridViewRow dRow in dgvComponentHistory.Rows)
            {
                if (Convert.ToBoolean(dRow.Cells[0].EditedFormattedValue) == true)
                {
                    string ID = dRow.Cells[3].Value.ToString();
                    ((frmIonSummer)this.Owner).viewID.Add(ID);
                }
            }
            if (((frmIonSummer)this.Owner).viewID.Count > 0)
            {
                ((frmIonSummer)this.Owner).ViewAndExport = true;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select records to view and export");
            }
        }
    }
}
