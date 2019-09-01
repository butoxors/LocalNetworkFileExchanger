using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kurs
{
    [Serializable]
    public class cFile
    {
        public long Length { get; set; }
        public string Name { get; set; }
        public string PathToFile { get; set; }
        public long filePointer { get; set; }
        public static readonly string FileNameOnDir = "/save.txt";
        public cFile() { }

        public cFile(long Length, string Name, string PathToFile)
        {
            this.Length = Length;
            this.Name = Name;
            this.PathToFile = PathToFile;
        }
        public static cFile DeserializeFile(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(byteArray, 0, byteArray.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                cFile obj = (cFile)binForm.Deserialize(memStream);
                return obj;
            }
        }
        public static byte[] SerializeToByteArray(cFile obj)
        {
            if (obj == null)
            {
                return null;
            }
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
        public override string ToString()
        {
            return "r\nДлинна: " + this.Length + "\r\nИмя: " + this.Name + "\r\nПуть: " + this.PathToFile + "\r\nУказатель файла: " + this.filePointer;
        }
        public static void OpenFile(out FileStream fs, string name, out long file_pointer)
        {
            fs = new FileStream(Directory.GetCurrentDirectory() + @"\" + name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            file_pointer = fs.Seek(fs.Length, SeekOrigin.Begin);

            if (file_pointer != 0)
            {
                fs.Close();
                fs = new FileStream(Directory.GetCurrentDirectory() + @"\" + name, FileMode.Append, FileAccess.Write);
                file_pointer = fs.Seek(fs.Length, SeekOrigin.Begin);
            }
        }
        public static long WriteToFile(ref FileStream fs, long file_pointer, byte[] data)
        {
            fs.Seek(file_pointer, SeekOrigin.Begin);
            fs.Write(data, 0, data.Length);

            return fs.Position;
        }
        public static long GetFileLength(ref FileStream fs)
        {
            FileInfo f = new FileInfo(fs.Name);
            long pointer = f.Length;
            return pointer;
        }
    }
}
