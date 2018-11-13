using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            First first = new First() { CarPrice = 2000000, CarName= "Porshe" };
            First first2 = new First() { CarPrice = 5000000, CarName = "Запорожец" };
            Second second = new Second() { Age = 55, Name = "Saule" };
            Second second2 = new Second() { Age = 23, Name = "Vasia" };
            Third third = new Third() { SchoolName = "NIS", SchoolNum = 1 };
            Third third2 = new Third(){  SchoolNum = 2, SchoolName = "QSI" };
            XmlSerializer xmlSerializable = new XmlSerializer(typeof(First));
            using (FileStream file = new FileStream("Files.xml", FileMode.OpenOrCreate))
            {
                xmlSerializable.Serialize(file, first);
                xmlSerializable.Serialize(file, first2);
                xmlSerializable = new XmlSerializer(typeof(Second));
                xmlSerializable.Serialize(file, second);
                xmlSerializable.Serialize(file, second2);
                xmlSerializable = new XmlSerializer(typeof(Third));
                xmlSerializable.Serialize(file, third);
                xmlSerializable.Serialize(file, third2);

            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter stream = new StreamWriter("json.txt"))
            using (JsonWriter writer = new JsonTextWriter(stream))
            {
                serializer.Serialize(writer, first);
                serializer.Serialize(writer, first2);
                serializer.Serialize(writer, second);
                serializer.Serialize(writer, second2);
                serializer.Serialize(writer, third);
                serializer.Serialize(writer, third2);
            }








        }
    }
}
