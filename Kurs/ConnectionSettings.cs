using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class ConnectionSettings : Form
    {
        public bool Save;
        public ConnectionSettings()
        {
            InitializeComponent();
            Save = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Equals(this.btnOK))
            {
                try
                {
                    bool isPortBusy = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().Any(l => l.Port == Convert.ToInt32(numericUpDown1.Value));
                    if (isPortBusy)
                    {
                        Save = true;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Невозможно открыть данный порт, используйте другой!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                Save = false;
                this.Close();
            }
        }
    }
}
