using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Kurs
{
    class ServerHandler : AHandler
    {
        private Server server;
        private Int64 FileLength;
        public ServerHandler(Server server, Socket socket)
        {
            ns = new NetworkStream(socket);
            this.server = server;
            FileLength = 0;
        }
        public override void ProcessSocketRequest()
        {
            fs = null;
            file_pointer = 0;
            loopbreak = false;
            try
            {
                while (!loopbreak)
                {
                    if (ns.ReadByte() != -1)
                    {

                        byte[] cmd = ReadCMD();

                        byte[] recv_data = ReadStream();
                        Enum.TryParse<COMMAND>(Encoding.ASCII.GetString(cmd), out Command);
                        switch (Command)
                        {
                            #region Создание файла
                            case COMMAND.CREATE:
                                {
                                    if (fs == null)
                                        cFile.OpenFile(out fs, Encoding.UTF8.GetString(recv_data), out file_pointer);

                                    Write(Encoding.ASCII.GetBytes(((int)COMMAND.READ).ToString()), Encoding.ASCII.GetBytes(((int)COMMAND.READ).ToString()));

                                    //server.AddFileToTable(fs.Name, fs.Length, file_pointer);

                                }
                                break;
                            #endregion
                            #region Запись в файл
                            case COMMAND.WRITE:
                                {
                                    if (fs == null)
                                        cFile.OpenFile(out fs, Encoding.UTF8.GetString(recv_data), out file_pointer);

                                    file_pointer = cFile.WriteToFile(ref fs, file_pointer, recv_data);

                                    Write(Encoding.ASCII.GetBytes(((int)COMMAND.READ).ToString()), Encoding.ASCII.GetBytes(file_pointer.ToString()));

                                    server.updateProgressBar(((int)Math.Ceiling((double)file_pointer / (double)FileLength * 100)));

                                }
                                break;
                            #endregion
                            #region Закрыть файл
                            case COMMAND.CLOSE:
                                {
                                    //Write(Encoding.ASCII.GetBytes(((int)COMMAND.CLOSE).ToString()), Encoding.ASCII.GetBytes(((int)COMMAND.CLOSE).ToString()));

                                    fs.Close();
                                    loopbreak = true;
                                }
                                break;
                            #endregion
                            case COMMAND.RESUME:
                                file_pointer = cFile.GetFileLength(ref fs);
                                Write(Encoding.ASCII.GetBytes(((int)COMMAND.READ).ToString()), Encoding.ASCII.GetBytes(file_pointer.ToString()));
                                break;
                            case COMMAND.SIZE:
                                {
                                    FileLength = Convert.ToInt64(Encoding.UTF8.GetString(recv_data));
                                    //Write(Encoding.ASCII.GetBytes(((int)COMMAND.READ).ToString()), Encoding.ASCII.GetBytes(file_pointer.ToString()));
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                ns.Close();
            }
        }
    }
}
