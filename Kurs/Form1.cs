using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form1 : Form
    {
        private Server server;
        private Client client;
        private string filename;
        FileInfo fiFile;
        private cFile cFile;
        public UserControl Files;
        public IPAddress CurrentIP;

        public Form1()
        {
            InitializeComponent();
        }
        public void ShowServerMessage(string msg)
        {
            try
            {
                tbServer.Text += msg + "\r\n";
            }
            catch (Exception) { }
        }
        public void ShowClientMessage(string msg)
        {
            try
            {
                tbClient.Text += msg + "\r\n";
            }
            catch (Exception) { }
        }

        private void SendMsgToClient_Click(object sender, EventArgs e)
        {
            //server.SendToClient(Encoding.ASCII.GetBytes(tbServerMsg.Text));
        }

        private void SendMsgToServer_Click(object sender, EventArgs e)
        {
            //client.SendToServer(tbClientMsg.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Получение имени компьютера.
            String host = System.Net.Dns.GetHostName();
            // Получение ip-адреса.
            CurrentIP = Dns.GetHostByName(host).AddressList[0];

            //server = new Server(this,address:CurrentIP.ToString());
            toolStripStatusLabel1.Text = "Режим : Сервер";
            //client = new Client(this);
            //toolStripStatusLabel3.Text = "Save dir: " + Directory.GetCurrentDirectory() + @"\";
            /*try
            {
                cFile = Serializer.DeserializeFromFile();
                if (cFile.filePointer >= cFile.Length)
                {
                    Serializer.Clean();
                    cFile = null;
                }
                userFileControl1.StartBtn.BeginInvoke(new MethodInvoker(delegate ()
                {
                    if (cFile != null)
                    {
                        userFileControl1.progressBar1.Value = (int)Math.Ceiling((double)cFile.filePointer / (double)cFile.Length * 100);
                        tbFileDatas.Text += cFile.ToString();
                        userFileControl1.StartBtn.Text = "Resume";
                        userFileControl1.StartBtn.Click -= new EventHandler(this.SendFile_Click);
                        userFileControl1.StartBtn.Click += new EventHandler(this.ResumeFile);
                        ShowServerMessage("File is ready...");
                    }
                }));
            }
            catch (Exception ex) { }*/
            UpdateStatus(server);
        }
        public void ResetFile(object sender, EventArgs e)
        {
            Serializer.Clean();
            cFile = null;
            userFileControl1.progressBar1.BeginInvoke(new MethodInvoker(delegate ()
            {
                userFileControl1.progressBar1.Value = 0;
                userFileControl1.ResetBtn.Enabled = true;
                userFileControl1.StartBtn.Text = "Start";
                userFileControl1.StartBtn.Click += new System.EventHandler(this.SendFile_Click);
                ShowServerMessage("Reset file...");
                tbFileDatas.Visible = false;
            }));
        }
        internal void TakeFile_Click(object sender, EventArgs e)
        {
            try
            {
                tbFileDatas.Clear();
                using (var o = new OpenFileDialog())
                {
                    if (o.ShowDialog() == DialogResult.OK)
                    {
                        filename = o.FileName;
                        fiFile = new FileInfo(Path.GetFullPath(o.FileName));

                        cFile = new cFile((int)fiFile.Length, fiFile.Name, fiFile.FullName);
                        tbFileDatas.Visible = true;
                        tbFileDatas.Text += cFile.ToString();
                        ShowServerMessage("File loaded...");
                    }
                }
            }
            catch (Exception) { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
                client.Close();
            if (server != null)
                server.Close();
            if (cFile != null)
            {
                if (cFile.filePointer < cFile.Length)
                {
                    Serializer.SerializeToFile(cFile);
                }
            }
        }

        internal void UpdateProgressVar(int value)
        {
            cFile.filePointer = client.pointer;
            userFileControl1.progressBar1.BeginInvoke(new MethodInvoker(delegate ()
            {
                if (value != 100)
                {
                    userFileControl1.progressBar1.Value = value;
                }
                else
                {
                    userFileControl1.ResetBtn.Enabled = true;
                    userFileControl1.progressBar1.Value = 0;
                    userFileControl1.StartBtn.Text = "Start";
                    userFileControl1.StartBtn.Click += new System.EventHandler(this.SendFile_Click);
                }
            }));
        }
        
        internal void SendFile_Click(object sender, EventArgs e)
        {
           if (cFile != null)
            {
                client.Send(cFile);

                userFileControl1.StartBtn.BeginInvoke(new MethodInvoker(delegate ()
                {
                    userFileControl1.StartBtn.Text = "Pause";
                    userFileControl1.ResetBtn.Enabled = false;
                    userFileControl1.StartBtn.Click -= new System.EventHandler(this.SendFile_Click);
                    userFileControl1.StartBtn.Click += new System.EventHandler(this.PauseFile);
                    ShowServerMessage("Start downloading...");
                }));
            }
            else
            {
                MessageBox.Show("Файл не выбран!");
            }
        }
        internal void ResumeFile(object sender, EventArgs e)
        {
            try
            {
                //client.Resume(cFile);
                userFileControl1.progressBar1.BeginInvoke(new MethodInvoker(delegate ()
                {
                    userFileControl1.ResetBtn.Enabled = true;
                    userFileControl1.StartBtn.Text = "Pause";
                    userFileControl1.StartBtn.Click -= new System.EventHandler(this.ResumeFile);
                    userFileControl1.StartBtn.Click += new System.EventHandler(this.PauseFile);
                    ShowServerMessage("Resume downloading...");
                }));
            }
            catch(Exception ex)
            {
                if (cFile.filePointer < cFile.Length)
                {
                    Serializer.SerializeToFile(cFile);
                }
            }
            
        }
        internal void PauseFile(object sender, EventArgs e)
        {
            try
            {
                //cFile.filePointer = client.pointer;
                //Serializer.SerializeToFile(cFile);
                client.Pause();
                userFileControl1.StartBtn.BeginInvoke(new MethodInvoker(delegate ()
                {
                    userFileControl1.StartBtn.Text = "Resume";
                    userFileControl1.StartBtn.Click -= new System.EventHandler(this.PauseFile);
                    userFileControl1.StartBtn.Click += new System.EventHandler(this.ResumeFile);
                    ShowServerMessage("Pause downloading...");
                }));
            }catch(Exception ex)
            {
                /*if (cFile.filePointer < cFile.Length)
                {
                    Serializer.SerializeToFile(cFile);
                }*/
            }
        }
        private void userFileControl1_Load(object sender, EventArgs e)
        {
            userFileControl1.StartBtn.Click += new System.EventHandler(this.SendFile_Click);
            userFileControl1.OpenBtn.Click += new System.EventHandler(this.TakeFile_Click);
            userFileControl1.ResetBtn.Enabled = true;
            userFileControl1.ResetBtn.Click += new EventHandler(this.ResetFile);
        }

        private void серверToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Close();
                //server = new Server(this, address:CurrentIP.ToString());

                toolStripStatusLabel1.Text = "Режим : Сервер";
                UpdateStatus(server);
            }
        }

        private void данныеПодключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectionSettings connectionSettings = new ConnectionSettings();
            connectionSettings.Load += new EventHandler((o, s) =>
            {
                connectionSettings.tbIP.Text = CurrentIP.ToString();
                if (server != null)
                {
                    connectionSettings.numericUpDown1.Value = server.Port;
                }
                else
                {
                    connectionSettings.numericUpDown1.Value = 8001;
                }
            });
            connectionSettings.FormClosing += new FormClosingEventHandler((o, s) =>
            {
                if (connectionSettings.Save)
                {
                    if (client != null)
                    {
                        client.Address = IPAddress.Parse(connectionSettings.tbIP.Text);
                        client.Port = Convert.ToInt32(connectionSettings.numericUpDown1.Value);
                        CurrentIP = IPAddress.Parse(connectionSettings.tbIP.Text);
                        UpdateStatus(client);
                        userFileControl1.Enabled = false;
                    }
                    if (server != null)
                    {
                        server.Port = Convert.ToInt32(connectionSettings.numericUpDown1.Value);
                        UpdateStatus(server);
                    }
                }
            });
            connectionSettings.Show();
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Close();
                //client = new Client(this, address:CurrentIP.ToString());

                toolStripStatusLabel1.Text = "Режим : Клиент";
                UpdateStatus(client);
                userFileControl1.Enabled = true;
            }
        }
        private void UpdateStatus(AArch type)
        {
            toolStripStatusLabel2.Text = "IP : " + type.Address.ToString();
            toolStripStatusLabel3.Text = "Port : " + type.Port.ToString(); ;
        }

        private void pDragDrop_DragEnter(object sender, DragEventArgs e)
        {
            tbFileDatas.Visible = false;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                label1.Text = "Отпустите мышь";
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void pDragDrop_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "Выберите файл или претащите его сюда";
        }

        private void pDragDrop_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 2);
            pen.DashPattern = new float[] { 2, 2, 2, 2 };
            e.Graphics.DrawRectangle(pen, 1, 1, pDragDrop.Width - 2, pDragDrop.Height - 2);
        }

        private void pDragDrop_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string []file = (string[])e.Data.GetData(DataFormats.FileDrop);
                tbFileDatas.Clear();
                using (var o = new OpenFileDialog())
                {
                    fiFile = new FileInfo(Path.GetFullPath(file[0]));

                    cFile = new cFile((int)fiFile.Length, fiFile.Name, fiFile.FullName);
                    tbFileDatas.Visible = true;
                    tbFileDatas.Text += cFile.ToString();
                    ShowServerMessage("File loaded...");
                }
            }
            catch (Exception)
            {
                tbFileDatas.Visible = false;
                label1.Text = "Не удалось открыть файл";
            }
        }
    }
}
