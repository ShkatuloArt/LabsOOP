using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;

namespace Lab14
{
    interface IPers
    {
        void info(string str);
    }
    interface IPerson
    {
        string name { get; set; }
        string address { get; set; }        
        void info();
    }
    [Serializable]
    public abstract class Person : IPers, IPerson
    {
        public string name { get; set; }
        public string address { get; set; }    
        public void info()
        {
           
        }
        public void info(string str)
        {
            Console.WriteLine(str);
        }
        public virtual void addInfo()
        {
            Console.WriteLine("Введите имя клиента");
            name = Console.ReadLine();
            Console.WriteLine("Введите адрес клиента");
            address = Console.ReadLine();            
        }
        public virtual void Type()
        {
            Console.WriteLine("Персоны");
        }
        public Person()
        {
            name = "null";
            address = "null";          
        }       
    }

    [Serializable]
    public class Client : Person
    {
        string age { set; get; }
        public override void Type()
        {
            Console.WriteLine("Клиент");
        }
    }


    class Program
    {
        static public void BinarySerialize(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("client.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Выполнена сериализация в формате binary");               
            }
        }
        static public void BinaryDesirialize()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("client.dat", FileMode.OpenOrCreate))
            {
                Client client = (Client)formatter.Deserialize(fs);
                Console.WriteLine("Выполнена десириализация в формате binary");
                Console.WriteLine("Имя: {0} --- Адрес: {1}", client.name, client.address);
            }
        }
        static public void SoapSerialize(object obj)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream("client.soap", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Выполнена сериализация в формате Soap");
            }
        }
        static public void SoapDesirialize()
        {
            SoapFormatter formatter = new SoapFormatter();
            using (FileStream fs = new FileStream("client.soap", FileMode.OpenOrCreate))
            {
                Client client = (Client)formatter.Deserialize(fs);
                Console.WriteLine("Выполнена десериализация в формате Soap");
                Console.WriteLine("Имя: {0} --- Адрес: {1}", client.name, client.address);
            }
        }
        static public void JsonSerialize(object obj)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Client));
            using (FileStream fs = new FileStream("client.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, obj);
                Console.WriteLine("Выполнена сериализация в формате Json");
            }

        }
        static public void JsonDeserialize()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Client));
            using (FileStream fs = new FileStream("client.json", FileMode.OpenOrCreate))
            {
                Client client = (Client)jsonFormatter.ReadObject(fs);
                Console.WriteLine("Выполнена десериализация в формате Json");
                Console.WriteLine("Имя: {0} --- Адрес: {1}", client.name, client.address);
            }
        }
        static public void XmlSerialize(object obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Client));
            using (FileStream fs = new FileStream("client.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
                Console.WriteLine("Выполнена сериализация в формате Xml");
            }
        }
        static public void XmlDeserialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Client));
            using (FileStream fs = new FileStream("client.xml", FileMode.OpenOrCreate))
            {
                Client client = (Client)formatter.Deserialize(fs);
                Console.WriteLine("Выполнена десериализация в формате Xml");
                Console.WriteLine("Имя: {0} --- Адрес: {1}", client.name, client.address);
            }
        }
        static public void XmlArraySerialize(object obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Client[]));
            using (FileStream fs = new FileStream("clientArray.xml", FileMode.OpenOrCreate))
            {
               formatter.Serialize(fs, obj);
               Console.WriteLine("Выполнена сериализация массива в формате Xml");
            }
        }
        static public void XmlArrayDeserialize()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Client[]));
            using (FileStream fs = new FileStream("clientArray.xml", FileMode.OpenOrCreate))
            {
                Client[] clients = (Client[])formatter.Deserialize(fs);
                Console.WriteLine("Выполнена десериализация массива в формате Xml");
                foreach(Client x in clients)
                {
                    Console.WriteLine("Имя: {0} --- Адрес: {1}", x.name, x.address);
                }               
            }
        }
        static public void XPath()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("client.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.OuterXml);
            }
        }
        static public void CreateXml()
        {
            XDocument xDoc = new XDocument(new XElement("OOP", new XElement("Labs", new XElement("Lab1", "github"), new XElement("Lab2", "Classes"))));
            xDoc.Save("oop.xml");
        }
        static public void XmlLinq()
        {
            XDocument xdoc = XDocument.Load("OOP.xml");
            foreach (XElement phoneElement in xdoc.Element("OOP").Elements("Labs"))
            {                
                XElement companyElement = phoneElement.Element("Lab1");
                XElement priceElement = phoneElement.Element("Lab2");

                if (companyElement != null && priceElement != null)
                {                    
                    Console.WriteLine("Lab1: {0}", companyElement.Value);
                    Console.WriteLine("Lab2: {0}", priceElement.Value);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Client firstClient = new Client();
            Client secondClient = new Client();
            Client[] clients = new Client[] { firstClient, secondClient };
            firstClient.addInfo();
            secondClient.addInfo();
            BinarySerialize(firstClient);
            BinaryDesirialize();
            SoapSerialize(firstClient);
            SoapDesirialize();
            JsonSerialize(firstClient);
            JsonDeserialize();
            XmlSerialize(firstClient);
            XmlDeserialize();
            Console.WriteLine("\n");
            XmlArraySerialize(clients);
            XmlArrayDeserialize();
            Console.WriteLine("\n");
            XPath();
            Console.WriteLine("\n");
            CreateXml();
            XmlLinq();
        }
    }
}
