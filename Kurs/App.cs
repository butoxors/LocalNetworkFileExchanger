using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class App : Form
    {
        private Server server;
        private Client client;
        public cFile file;
        //public UserControl Files;
        public IPAddress CurrentIP;
        /// <summary>
        /// Конструктор
        /// </summary>
        public App()
        {
            InitializeComponent();
            clientPanel1.Visible = true;
            serverPanel1.Visible = false;
            statisticsPanel1.Visible = false;

            serverPanel1.btnStartServer.Click += StartServer;

            #region Кнопка Стоп (Сервер)
            serverPanel1.btnStopServer.Click += StopServer;
            #endregion

            #region Кнопка подключения к серверу (Клиент)
            clientPanel1.btnClientConnect.Click += StartClient;
            #endregion

            #region Кнопка Пауза/Старт (Клиент)
            clientPanel1.btnPause.Click += SendFile;
            #endregion

            clientPanel1.btnReset.Click += btnReset_Click;
        }
        private void SendFile(object sender, EventArgs e)
        {
            clientPanel1.btnPause.Text = "Приостановить";
            clientPanel1.btnPause.Image = Properties.Resources.rounded_pause_button;
            clientPanel1.btnPause.Click -= SendFile;
            clientPanel1.btnPause.Click += PauseFile;
            client.Send(clientPanel1.file);
            statisticsPanel1.lFileStatus.Text = "Отправка файла";
        }
        private void PauseFile(object sender, EventArgs e)
        {
            client.Pause();
            clientPanel1.btnPause.Text = "Возобновить";
            clientPanel1.btnPause.Image = Properties.Resources.play_button;
            clientPanel1.btnPause.Click -= PauseFile;
            clientPanel1.btnPause.Click += ResumeFile;
            statisticsPanel1.lFileStatus.Text = "Отправка файла приостановлена";
        }
        private void ResumeFile(object sender, EventArgs e)
        {
            clientPanel1.btnPause.Text = "Приостановить";
            clientPanel1.btnPause.Image = Properties.Resources.rounded_pause_button;
            client.Resume();
            clientPanel1.btnPause.Click -= ResumeFile;
            clientPanel1.btnPause.Click += PauseFile;
            statisticsPanel1.lFileStatus.Text = "Отправка файла возобновлена";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            clientPanel1.pDown.Visible = false;
            clientPanel1.btnPause.Visible = false;
            clientPanel1.btnPause.Text = "Запустить";
            clientPanel1.btnPause.Image = Properties.Resources.play_button;
            clientPanel1.btnReset.Visible = false;
            clientPanel1.lFileInfo.Text = clientPanel1.lines[0];
            clientPanel1.file = null;
            clientPanel1.panel2.BackgroundImage = Kurs.Properties.Resources.download;
            clientPanel1.btnTakeAFile.Visible = true;
            clientPanel1.panel2.Paint += clientPanel1.panel2_Paint;
            clientPanel1.UpdateProgressVar(0);
            clientPanel1.btnPause.Click += SendFile;
            statisticsPanel1.lFileStatus.Text = "Файл отсутствует";
        }
        /// <summary>
        /// Кнопка остановки службы Сервер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopServer(object sender, EventArgs e)
        {
            try
            {
                server.Close();
                serverPanel1.btnStartServer.Text = "Запустить сервер";
                statisticsPanel1.ServerStatus = "Остановлен";
                serverPanel1.btnStopServer.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Не удалось остановить службу \"Сервер\" : " + ex.Message);
                statisticsPanel1.ServerStatus = "Ошибка остановки";
                serverPanel1.btnStopServer.Enabled = true;
            }
        }
        internal void UpdateProgressVar(int value, AArch who)
        {
            if (who is Server)
            {
                bool s = serverPanel1.UpdateProgressVar(value);
                if (!s)
                {
                    serverPanel1.label1.Text = "В ожидании получения данных";
                    serverPanel1.progressBar1.Value = 0;
                }
            }else if (who is Client)
            {
                bool s = clientPanel1.UpdateProgressVar(value);
                if (!s)
                {
                    clientPanel1.label3.Text = "В ожидании получения данных";
                    clientPanel1.progressBar1.Value = 0;
                    clientPanel1.btnPause.Click += SendFile;
                    clientPanel1.btnPause.Text = "Передать";
                    clientPanel1.btnPause.Image = Properties.Resources.play_button;
                }
            }
        }
        /// <summary>
        /// Запустить службу Клиент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartClient(object sender, EventArgs e)
        {
            try
            {
                int l = clientPanel1.tbIP.Text.Length;
                client = new Client(this, Convert.ToInt32(clientPanel1.tbPort.Text), clientPanel1.tbIP.Text.Remove(l - 1));
                client.StartClient();
                statisticsPanel1.ClientStatus = "Запущен";
                clientPanel1.btnClientConnect.Click += StopClient;
                clientPanel1.btnClientConnect.Text = "Откючиться";
                clientPanel1.btnClientConnect.Image = Kurs.Properties.Resources.no_wifi;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось запустить службу \"Клиент\" : " + ex.Message);
                statisticsPanel1.ClientStatus = "Ошибка запуска";
                client.Close();
                clientPanel1.btnClientConnect.Click += StartClient;
                clientPanel1.btnClientConnect.Text = "Подключиться";
                clientPanel1.btnClientConnect.Image = Kurs.Properties.Resources.wifi;
            }
        }
        /// <summary>
        /// Остановить службу Клиент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopClient(object sender, EventArgs e)
        {
            try
            {
                client.Close();
                clientPanel1.btnClientConnect.Click += StartClient;
                clientPanel1.btnClientConnect.Text = "Подключиться";
                clientPanel1.btnClientConnect.Image = Kurs.Properties.Resources.wifi;
                statisticsPanel1.ClientStatus = "Остановлен";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось остановить службу \"Клиент\" : " + ex.Message);
                statisticsPanel1.ClientStatus = "Ошибка остановки";
            }
        }
        /// <summary>
        /// Запустить сервер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartServer(object sender, EventArgs e)
        {
            try
            {
                int l = serverPanel1.tbIP.Text.Length;
                server = new Server(this,serverPanel1, Convert.ToInt32(serverPanel1.tbPort.Text), serverPanel1.tbIP.Text);
                server.StartServer();
                serverPanel1.btnStartServer.Click += RestartServer;
                serverPanel1.btnStartServer.Text = "Перезапустить сервер";
                statisticsPanel1.ServerStatus = "Запущен";
                serverPanel1.btnStartServer.Image = Kurs.Properties.Resources.refresh;
                serverPanel1.btnStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось запустить службу \"Сервер\" : " + ex.Message);
                statisticsPanel1.ServerStatus = "Ошибка запуска";
                serverPanel1.btnStartServer.Text = "Запустить сервер";
                serverPanel1.btnStopServer.Enabled = false;
            }
        }
        /// <summary>
        /// Перезапустить сервер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartServer(object sender, EventArgs e)
        {
            try
            {
                serverPanel1.btnStartServer.Click += RestartServer;
                server.RestartServer();
                serverPanel1.btnStartServer.Text = "Перезапустить сервер";
                serverPanel1.btnStartServer.Image = Kurs.Properties.Resources.refresh;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось перезапустиь службу \"Сервер\" : " + ex.Message);
                statisticsPanel1.ServerStatus = "Ошибка перезапуска";
            }
            
        }
        /// <summary>
        /// Перетаскивание формы мышкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_MouseDown(object sender, MouseEventArgs e)
        {
            Control c = (Control)sender;
            c.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        /// <summary>
        /// Закрыть окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Минимизировать окно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Изменение цвета кнопок навигации
        /// </summary>
        /// <param name="btn"></param>
        private void ChangeBtnPrors(Button btn)
        {
            foreach(var but in panel1.Controls.OfType<Button>())
            {
                if (but != btn)
                {
                    but.BackColor = Color.FromArgb(74, 105, 189);
                }
                else
                {
                    but.BackColor = Color.FromArgb(84, 160, 255);
                }
            }
        }
        /// <summary>
        /// Переход на меню Клиент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClient_Click(object sender, EventArgs e)
        {
            clientPanel1.Visible = false;
            serverPanel1.Visible = true;
            statisticsPanel1.Visible = false;
            ChangeBtnPrors(sender as Button);
        }
        /// <summary>
        /// Переход на меню Сервер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnServer_Click(object sender, EventArgs e)
        {
            clientPanel1.Visible = true;
            serverPanel1.Visible = false;
            statisticsPanel1.Visible = false;
            ChangeBtnPrors(sender as Button);
        }
        /// <summary>
        /// Переход на меню Статистика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            statisticsPanel1.Visible = true;
            serverPanel1.Visible = false;
            clientPanel1.Visible = false;
            ChangeBtnPrors(sender as Button);
        }
        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null)
                client.Close();
            if (server != null)
                server.Close();
        }
    }
}
