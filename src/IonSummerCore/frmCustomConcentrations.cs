using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IonSummer
{
    public partial class frmCustomConcentrations : Form
    {
        public frmCustomConcentrations()
        {
            InitializeComponent();
        }

        private void dgvCustomConcentration_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                double i;

                if (!double.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show("Please enter numeric value");
                }
            }
        }
    }
}
