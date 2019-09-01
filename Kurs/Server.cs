using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public class Server : AArch
    {
        ServerHandler handler;
        private Socket serverSocket;
        private Socket clientSocket;
        private ServerPanel Panel;
        public Server(Form form, ServerPanel panel, int port = 8001, string address = "127.0.0.1")
        {
            this.form = (App)form;
            Port = port;
            Address = IPAddress.Any;
            this.Panel = panel;
        }
        public void RestartServer()
        {
            this.Close();
            this.StartServer();
        }
        public void StartServer()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(Address, Port));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(AcceptCallback, null);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                clientSocket = serverSocket.EndAccept(ar);

                serverSocket.BeginAccept(AcceptCallback, null);
                handler = new ServerHandler(this, clientSocket);
                thread = new Thread(handler.ProcessSocketRequest);
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public override void Close()
        {
            if (thread != null)
                if (thread.IsAlive)
                {
                    handler.Close();
                    //thread.Abort();
                }
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        internal void updateProgressBar(int value)
        {
            pointer = handler.file_pointer;
            ((App)form).Invoke(new MethodInvoker(delegate { ((App)form).serverPanel1.UpdateProgressVar(value); }));

        }
        internal void UpdateRow(string name, long filePointer)
        {
            Panel.UpdateRow(name, filePointer);
            //((App)form).serverPanel1.Invoke(new MethodInvoker(delegate { ((App)form).serverPanel1.UpdateRow(name, filePointer); }));
        }
        internal void AddFileToTable(string name, long length, long filePointer)
        {
            Panel.AddFileToTable(name, length, filePointer);
            //((App)form).serverPanel1.Invoke(new MethodInvoker(delegate { ((App)form).serverPanel1.AddFileToTable(name, length, filePointer); }));
        }
        protected override void Message(string msg)
        {
            /*form.tbServer.Invoke(new MethodInvoker(delegate ()
            {
                form.tbServer.Text += msg + "\r\n";
            }));*/
        }
    }
}
