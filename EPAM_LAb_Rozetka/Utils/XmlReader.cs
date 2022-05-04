using EPAM_LAb_Rozetka.Models;
using System.IO;
using System.Xml.Serialization;


namespace EPAM_LAb_Rozetka.Utils
{
    public class XmlReader
    {
        static string dataFile = @"\resources\Data.xml";

        public static Products ReadDataFromFiles()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Products));
            string path = Directory.GetCurrentDirectory();
            path = path[0..^24];
            path += dataFile;
            using (Stream fStream = File.OpenRead(path))
            {
                return (Products)xmlFormat.Deserialize(fStream);
            }
        }
    }
}
