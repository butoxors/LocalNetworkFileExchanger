using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Kurs
{
    public abstract class AHandler
    {
        protected FileStream fs;
        protected COMMAND Command;
        public readonly int BufferSize = 20000;
        protected byte[] cmd;
        protected NetworkStream ns;
        public cFile file { get; set; }
        protected Client client { get; set; }
        protected bool loopbreak { get; set; }
        public long file_pointer;

        public void Write(byte[] cmd, byte[] data)
        {
            byte[] packet = CreateDataPacket(cmd, data);
            ns.Write(packet, 0, packet.Length);
            ns.Flush();
        }
        public virtual void Pause()
        {
            if (fs != null)
            {
                Write(Encoding.ASCII.GetBytes(((int)COMMAND.PAUSE).ToString()), Encoding.ASCII.GetBytes(((int)COMMAND.PAUSE).ToString()));
            }
            //Thread.Sleep(Timeout.Infinite);
        }
        public virtual void Resume()
        {
            if (fs != null)
            {
                Write(Encoding.ASCII.GetBytes(((int)COMMAND.RESUME).ToString()), Encoding.ASCII.GetBytes(((int)COMMAND.RESUME).ToString()));
            }
            //Thread.Sleep(Timeout.Infinite);
        }
        public virtual void Close()
        {
            if (fs != null)
            {
                Write(Encoding.ASCII.GetBytes(((int)COMMAND.CLOSE).ToString()), Encoding.ASCII.GetBytes(((int)COMMAND.CLOSE).ToString()));
            }
        }
        public virtual void ProcessSocketRequest() { }

        internal virtual byte[] ReadStream()
        {
            byte[] data_buff = null;
            int b = 0;
            string buff_length = "";
            while ((b = ns.ReadByte()) != 4)
            {
                buff_length += (char)b;
            }
            int data_length = Convert.ToInt32(buff_length);

            data_buff = new byte[data_length];
            int byte_read = 0;
            int byte_offset = 0;
            while (byte_offset < data_length)
            {
                byte_read = ns.Read(data_buff, byte_offset, data_length - byte_offset);
                byte_offset += byte_read;
            }
            return data_buff;
        }
        internal virtual byte[] ReadCMD()
        {
            byte[] cmd_buff = new byte[1];
            ns.Read(cmd_buff, 0, cmd_buff.Length);
            return cmd_buff;
        }

        internal virtual byte[] CreateDataPacket(byte[] cmd, byte[] data)
        {
            #region 2 cmd dataLength 4 data

            byte[] initialize = new byte[1];
            initialize[0] = 2;
            byte[] separ = new byte[1];
            separ[0] = 4;
            byte[] dataLength = Encoding.ASCII.GetBytes(Convert.ToString(data.Length));
            MemoryStream ms = new MemoryStream();
            ms.Write(initialize, 0, initialize.Length);
            ms.Write(cmd, 0, cmd.Length);
            ms.Write(dataLength, 0, dataLength.Length);
            ms.Write(separ, 0, separ.Length);
            ms.Write(data, 0, data.Length);

            #endregion
            return ms.ToArray();
        }
        internal virtual byte[] ReadData(int length)
        {
            byte[] buff = new byte[length];
            fs.Read(buff, 0, length);
            return buff;
        }
    }
}
