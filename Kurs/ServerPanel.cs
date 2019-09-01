using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Kurs
{
    public partial class ServerPanel : UserControl
    {
        public ServerPanel()
        {
            InitializeComponent();

            //this.tbIP.Text = new WebClient().DownloadString("http://icanhazip.com");
            this.tbIP.Text = "127.0.0.1";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            tb.Text = string.Empty;

            tb.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == string.Empty)
            {
                tb.ForeColor = Color.SteelBlue;
                tb.Text = "8001";
            }

        }
        internal bool UpdateProgressVar(int value)
        {
            if (progressBar1.Value >= 100)
                return false;

            progressBar1.Value = value;

            return true;
        }
        internal void AddFileToTable(string name, long length, long filePointer)
        {
            dataGridView1.Rows.Add(name, length, filePointer);
        }
        internal void UpdateRow(string name, long filePointer)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == name)
                {
                    dataGridView1.Rows[i].Cells[1].Value = filePointer;
                    dataGridView1.Rows[i].Cells[2].Value = filePointer;
                }
            }
        }
        private void btnHide_Click(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Start();
            Button btn = (Button)sender;
            btn.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            btn.Invalidate();
            if (panel2.Visible)
                timer.Tick += new EventHandler((o, s) =>
                {
                    if (panel2.Width > 5)
                    {
                        panel2.Width -= 25;
                    }
                    else
                    {
                        panel2.Visible = false;
                        timer.Stop();
                    }
                });
            else
                timer.Tick += new EventHandler((o, s) =>
                {
                    panel2.Visible = true;
                    if (panel2.Width <= 185)
                    {
                        panel2.Width += 25;
                    }
                    else
                    {
                        timer.Stop();
                    }
                });
        }
    }
}
