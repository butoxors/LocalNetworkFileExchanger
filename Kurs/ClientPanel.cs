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
using System.Net;

namespace Kurs
{
    public partial class ClientPanel : UserControl
    {
        public cFile file;

        public List<string> lines = new List<string>()  { "Переместите сюда файл", "Отпустите мышь", "" };
        public List<string> tblines = new List<string>() { new WebClient().DownloadString("http://icanhazip.com"), "8001" };

        public ClientPanel()
        {
            InitializeComponent();
            file = null;
            //this.tbIP.Text = new WebClient().DownloadString("http://icanhazip.com");
            this.tbIP.Text = "127.0.0.1";
        }

        public void panel2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 2);
            pen.DashPattern = new float[] { 2, 2, 2, 2 };
            e.Graphics.DrawRectangle(pen, new Rectangle(25, 25, panel2.Width - 50, panel2.Height - 50));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Start();
            Button btn = (Button)sender;
            btn.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            btn.Invalidate();
            if (panel1.Visible)
                timer.Tick += new EventHandler((o, s) =>
                {
                    if (panel1.Width > 5)
                    {
                        panel1.Width -= 25;
                    }
                    else
                    {
                        panel1.Visible = false;
                        timer.Stop();
                    }
                });
            else
                timer.Tick += new EventHandler((o, s) =>
                {
                    panel1.Visible = true;
                    if (panel1.Width <= 185)
                    {
                        panel1.Width += 25;
                    }
                    else
                    {
                        timer.Stop();
                    }
                });
        }
        public void FileIsOpen(FileInfo fiFile)
        {
            file = new cFile((long)fiFile.Length, fiFile.Name, fiFile.FullName);
            btnPause.Visible = true;
            btnPause.Text = "Запустить";
            btnPause.Image = Properties.Resources.play_button;
            pDown.Visible = true;
            lFileInfo.Text = "Файл выбран! " + file.PathToFile;
            btnReset.Visible = true;
            panel2.BackgroundImage = null;
            panel2.Paint -= panel2_Paint;
            btnTakeAFile.Visible = false;
            panel2.Invalidate();
        }
        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                    FileInfo fiFile = new FileInfo(Path.GetFullPath(files[0]));

                    FileIsOpen(fiFile);
                }
                catch (Exception)
                {
                    btnPause.Visible = false;
                    pDown.Visible = false;
                    lFileInfo.Text = "Не удалось открыть файл...";
                }
            }
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            lFileInfo.Text = lines[1];
            e.Effect = DragDropEffects.Copy;
        }

        private void panel2_DragLeave(object sender, EventArgs e)
        {
            lFileInfo.Text = lines[0];
        }
        internal bool UpdateProgressVar(int value)
        {
            if (this.progressBar1.Value >= 100)
                return false;

            this.progressBar1.Value = value;

            return true;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tblines.Contains(tb.Text))
                tb.Text = string.Empty;

            tb.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == string.Empty)
            {
                tb.ForeColor = Color.SteelBlue;
                tb.Text = tblines[Convert.ToInt32(tb.Tag)];
            }

        }

        private void btnTakeAFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var o = new OpenFileDialog())
                {
                    if (o.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fiFile = new FileInfo(Path.GetFullPath(o.FileName));

                        //file = new cFile((int)fiFile.Length, fiFile.Name, fiFile.FullName);

                        FileIsOpen(fiFile);
                        
                    }
                }
            }
            catch (Exception) { }
        }

    }
}
