using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Kurs
{
    public class Client : AArch
    {
        private Socket clientSocket;
        ClientHandler handler;
        cFile file;

        public Client(Form form, int port = 8001, string address = "127.0.0.1")
        {
            this.form = (App)form;
            this.Port = port;
            this.Address = IPAddress.Parse("127.0.0.1");
            pointer = 0;
        }
        public override void Close()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    try
                    {
                        thread.Abort();
                        handler.Close();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
            }
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        public void StartClient()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPEndPoint point = new IPEndPoint(Address, Port);

                clientSocket.BeginConnect(point, ConnectCallback, null);

                //Message("Клиент успешно запущен!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        internal void updateProgressBar(int value)
        {
            pointer = handler.file_pointer;
            ((App)form).Invoke(new MethodInvoker(delegate { ((App)form).clientPanel1.UpdateProgressVar(value); }));
        }
        public void Send(cFile file)
        {

            if (handler == null)
            {
                this.file = file;
                handler = new ClientHandler(clientSocket, this);
                handler.file = file;
                pointer = 0;
            }
            else
            {
                handler.file_pointer = file.filePointer;
            }
            thread = new Thread(delegate () { handler.ProcessSocketRequest(); });

            thread.Start();
            
        }
        public void Resume()
        {
            try
            {
                //handler.Resume();
                if (handler == null)
                {
                    handler = new ClientHandler(clientSocket, this);
                    handler.file = file;
                    thread = new Thread(delegate () { handler.ProcessSocketRequest(); });
                    pointer = 0;
                    thread.Start();
                }
                else
                {
                    thread = new Thread(delegate () { handler.ProcessSocketRequest(); });
                    thread.Start();
                    //handler.file = file;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public void Pause()
        {
            try
            {
                //handler.Pause();
                thread.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        protected override void Message(string msg)
        {
            /*form.tbClient.Invoke(new MethodInvoker(delegate ()
            {
                form.tbClient.Text += msg + "\r\n";
            }));*/
        }
    }
}
