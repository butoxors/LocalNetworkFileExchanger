using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kurs
{
    class ClientHandler: AHandler
    {
        public ClientHandler(Socket socket, Client client)
        {
            this.client = client;
            ns = new NetworkStream(socket);
        }
        public override void ProcessSocketRequest()
        {
            loopbreak = false;
            if (fs == null)
                fs = new FileStream(file.PathToFile, FileMode.Open, FileAccess.Read);

            Write(Encoding.ASCII.GetBytes(((int)COMMAND.SIZE).ToString()), Encoding.ASCII.GetBytes(fs.Length.ToString()));

            Write(Encoding.ASCII.GetBytes(((int)COMMAND.CREATE).ToString()), Encoding.ASCII.GetBytes(file.Name));

            while (!loopbreak)
            {
                if (ns.ReadByte() != -1)
                {
                    byte[] cmd = ReadCMD();

                    byte[] recv_data = ReadStream();
                    Enum.TryParse<COMMAND>(Encoding.ASCII.GetString(cmd), out Command);
                    switch (Command)
                    {
                        #region Передача байтов файла
                        case COMMAND.READ:
                            #region Читаем из файла
                            file_pointer = long.Parse(Encoding.ASCII.GetString(recv_data));
                            if (file_pointer != fs.Length)
                            {
                                fs.Seek(file_pointer, SeekOrigin.Begin);
                                int temp_buffer_length = Convert.ToInt32(fs.Length - file_pointer < BufferSize ? fs.Length - file_pointer : BufferSize);
                                byte[] temp_buff = ReadData(temp_buffer_length);

                                Write(Encoding.ASCII.GetBytes(((int)COMMAND.WRITE).ToString()), temp_buff);

                                client.updateProgressBar(((int)Math.Ceiling((double)file_pointer / (double)fs.Length * 100)));
                            }
                            #endregion
                            else
                            {
                                #region Прекращаем чтение
                                Write(Encoding.ASCII.GetBytes(((int)COMMAND.CLOSE).ToString()), Encoding.ASCII.GetBytes(((int)COMMAND.CLOSE).ToString()));
                                fs.Close();
                                loopbreak = true;
                                #endregion
                            }
                            break;
                        #endregion
                        #region Закрыть файл
                        case COMMAND.CLOSE:
                            {
                                Write(Encoding.ASCII.GetBytes(((int)COMMAND.CLOSE).ToString()), Encoding.ASCII.GetBytes(((int)COMMAND.CLOSE).ToString()));
                                fs.Close();
                                loopbreak = true;
                            }
                            break;
                        #endregion

                        default:
                            break;
                    }
                }
            }
            ns.Close();
        }
    }
}
