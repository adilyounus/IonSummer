using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IonSummer
{
    public partial class frmDefaultPath : Form
    {
        public frmDefaultPath()
        {
            InitializeComponent();
        }

        private void frmDefaultPath_Load(object sender, EventArgs e)
        {
            string DefaultFolder = ConfigurationManager.AppSettings["DefaultFolder"].ToString();
            txtPath.Text = DefaultFolder;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {

            string DefaultFolder = ConfigurationManager.AppSettings["DefaultFolder"].ToString();

            if (Directory.Exists(DefaultFolder))
            {
                folderBrowserDialog1.SelectedPath = DefaultFolder;
            }

            DialogResult res = folderBrowserDialog1.ShowDialog(this);
            
            if (res == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configFile.AppSettings.Settings["DefaultFolder"].Value = txtPath.Text;
            configFile.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
