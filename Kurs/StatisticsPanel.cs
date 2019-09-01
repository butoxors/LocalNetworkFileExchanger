using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Kurs
{
    public partial class StatisticsPanel : UserControl
    {
        public string ServerStatus { get; set; }
        public string ClientStatus { get; set; }
        public StatisticsPanel()
        {
            InitializeComponent();
            ServerStatus = "Файл отсутствует";
        }

        private void SettingsPanel_VisibleChanged(object sender, EventArgs e)
        {
            lDirPath.Text = Directory.GetCurrentDirectory();
            lServerStatus.Text = ServerStatus;
            lClientStatus.Text = ClientStatus;
        }

        private void btnOpenExplorer_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", lDirPath.Text);
        }
    }
}
