using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Lab_12
{
    public class Printer
    {
        public void Printing(object obj)
        {
            obj.ToString();

            Console.WriteLine($"Это {obj.GetType()}");
        }
    }
    interface IPers
    {
        void info(string str);
    }
    interface IPerson
    {
        string name { get; set; }
        string address { get; set; }
        string count { get; set; }
        string operation { get; set; }
        void info();
    }
    abstract class Person : IPers, IPerson
    {
        public string name { get; set; }
        public string address { get; set; }
        public string count { get; set; }
        public string operation { get; set; }
        public bool debitcard { get; set; }
        public void info()
        {
            if (debitcard)
            {
                Console.WriteLine("Оформить дебетовую карту");
            }
            else
            {
                Console.WriteLine("Не оформлять дебетовую карту");
            }
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
            Console.WriteLine("Введите счет: накопительный, валютный, расчетный, общий");
            count = Console.ReadLine();
            Console.WriteLine("Операции со счетом: пополнение, вывод");
            operation = Console.ReadLine();
            Console.WriteLine("Офрмление дебетовой карты");
            string a = Console.ReadLine();
            if (a == "да" || a == "Да")
            {
                debitcard = true;
            }
        }
        public virtual void Type()
        {
            Console.WriteLine("Персоны");
        }
        public Person()
        {
            name = "null";
            address = "null";
            count = "null";
            operation = "null";
            debitcard = false;
        }
        public override string ToString()
        {
            string str1;
            if (debitcard)
            {
                str1 = "Оформлять дебетовую карту";
            }
            else
            {
                str1 = "Не оформлять дебетовую карту";
            }
            return name + "\n" + address + "\n" + count + "\n" + operation + "\n" + str1 + "\n";
        }
        public string Read(string str)
        {
            return str;
        }
    }
    class Client : Person
    {
        string age { set; get; }
        public override void Type()
        {
            Console.WriteLine("Персона");
        }
    }
    sealed class Address : Person
    {
        public override void Type()
        {
            Console.WriteLine("Адрес");
        }
    }
    class Count : Person
    {
        public override void Type()
        {
            Console.WriteLine("Счет");
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
    class Operation : Count
    {
        public override void Type()
        {
            Console.WriteLine("Операции со счетом");
        }
    }
    class Reflector
    {
        static public void Info(object obj)
        {
            StreamWriter writer = new StreamWriter(@"info.txt");
            Type t = obj.GetType();
            writer.WriteLine("Информация о классе");
            writer.WriteLine("Full name = " + t.FullName);
            writer.WriteLine("Base type = " + t.BaseType);
            writer.WriteLine("Is sealed = " + t.IsSealed);
            writer.WriteLine("Is class = " + t.IsClass);

            foreach(Type x in t.GetInterfaces())
            {
                writer.WriteLine(x.Name);
            }
            foreach ( FieldInfo y in t.GetFields())
            {
                writer.WriteLine(y.Name);
            }
            writer.Close();
        }
        static public void InfoMethod(object obj)
        {
            Type t = obj.GetType();
            foreach (MethodInfo x in t.GetMethods())
            {
                Console.WriteLine("Method = " + x);
            }
        }
        static public void InfoFild(object obj)
        {
            Type t = obj.GetType();
            foreach (FieldInfo x in t.GetFields())
            {
                Console.WriteLine("Field = " + x.Name);
            }
            foreach ( PropertyInfo y in t.GetProperties())
            {
                Console.WriteLine("Property = " + y);
            }
        }
        static public void InfoInterface(object obj)
        {
            Type t = obj.GetType();
            foreach(Type x in t.GetInterfaces())
            {
                Console.WriteLine(x.Name);
            }
        }
        static public void InfoNameMethodParameter(object obj, string str)
        {
            Type t = obj.GetType();

            foreach (MethodInfo x in t.GetMethods())
            {
                foreach(ParameterInfo y in x.GetParameters())
                {
                    if(y.Name.Contains(str))
                    {
                        Console.WriteLine(x.Name);
                    }
                }
            }
        }
        static public void ReadMethod(object obj, string str)
        {
            StreamReader reader = new StreamReader("Parameters.txt");
            string parameter = reader.ReadLine();
            Type t = obj.GetType();
            MethodInfo info = t.GetMethod(str);
            object ob = Activator.CreateInstance(typeof(Client));
            object result = info.Invoke(ob, new object[] { parameter });
            Console.WriteLine((result));
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            Console.WriteLine("1 - задание.\n");
            Reflector.Info(client);
            Console.WriteLine("\n2 - задание.\n");
            Reflector.InfoMethod(client);
            Console.WriteLine("\n3 - задание.\n");
            Reflector.InfoFild(client);
            Console.WriteLine("\n4 - задание.\n");
            Reflector.InfoInterface(client);
            Console.WriteLine("\n5 - задание.\n");
            Reflector.InfoNameMethodParameter(client, "str");
            Console.WriteLine("\n6 - задание.\n");
            Reflector.ReadMethod(client, "Read");
        }
    }
}
