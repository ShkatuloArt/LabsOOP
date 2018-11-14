using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    class Program
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
                if (a == "да" || a== "Да" )
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
        static void Main(string[] args)
        {
            Client client = new Client();
            Address adres = new Address();
            Count counter = new Count();
            Operation oper = new Operation();
            Printer Print = new Printer();
            List<object> array = new List<object>() { client, adres, counter, oper };
            foreach (object ise in array)
            {
                Print.Printing(ise);
            }
            Console.WriteLine("\n");
            client.addInfo();
            adres.addInfo();
            oper.addInfo();
            client.Type();
            adres.Type();
            counter.Type();
            oper.Type();
            Console.WriteLine('\n');

            bool isPerson = client is Person;
            if(isPerson)
            {
                Person person1 = (Person)client;
                person1.Type();
            }
            Person person2 = counter as Person;
            if (person2 != null)
            {
                person2.info();
            }
            Console.WriteLine("\n");
            Console.WriteLine(oper.ToString());
        }
    }
}
