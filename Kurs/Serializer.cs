using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kurs
{
    public static class Serializer
    {
        static Serializer() { }
        public static void SerializeToFile(cFile file)
        {
            IFormatter f = new BinaryFormatter();
            Stream s = new FileStream(Directory.GetCurrentDirectory() + cFile.FileNameOnDir, FileMode.Create, FileAccess.Write);
            f.Serialize(s, file);
            s.Close();
        }
        public static cFile DeserializeFromFile()
        {
            cFile file;
            IFormatter f = new BinaryFormatter();
            try
            {
                Stream s = new FileStream(Directory.GetCurrentDirectory() + cFile.FileNameOnDir, FileMode.Open, FileAccess.Read);
                file = (cFile)f.Deserialize(s);
                s.Close();
            }catch(Exception ex)
            {
                return null;
            }
            return file;
        }
        public static void Clean()
        {
            try
            {
                File.Delete(Directory.GetCurrentDirectory() + cFile.FileNameOnDir);
            }
            catch (Exception ex) { }
        }
    }
}
