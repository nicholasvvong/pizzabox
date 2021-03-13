using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PizzaBox.Storing
{
    public class FileStorage
    {
        private readonly string _path;

        public FileStorage(string path)
        {
            _path = path;
        }
        public void WriteToXml<T>(List<T> data) where T : class
        {
            using (var writer = new StreamWriter(_path))
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                serializer.Serialize(writer, data);
            }
        }

        public IEnumerable<T> ReadFromXml<T>() where T : class
        {
            using(var reader = new StreamReader(_path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                return serializer.Deserialize(reader) as IEnumerable<T>;
            }
        }
    }
}