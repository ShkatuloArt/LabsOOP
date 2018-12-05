using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10
{
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
    class Student
    {
        string name;
        int age;

        public Student(string a, int b)
        {
            name = a;
            age = b;
        }
    }
    
    class Program
    {
        public static void Change(object x, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Person personA = e.NewItems[0] as Person;
                        Console.WriteLine("Объект добавлен: ");
                        personA.Type();
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        Person personR = e.OldItems[0] as Person;
                        Console.WriteLine("Объект удален: ");
                        personR.Type();
                        break;
                    }
            }
        }
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            Random rand = new Random();
            Student student = new Student("Артём Шкатуло", 18);

            for (int i = 0; i < 5; i++)
            {
                array.Add(rand.Next(50));
            }

            array.Add("Строка");
            array.Add(student);

            foreach ( object x in array)
            {
                Console.Write(x + "\t");
            }
            Console.WriteLine();
            Console.Write("Введите номер, для удаления: ");
            int elem = int.Parse(Console.ReadLine());
            array.RemoveAt(--elem);
            foreach (object x in array)
            {
                Console.Write(x + "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Количество элементов равно = " + array.Count);
            Console.Write("Введите элемент, который нужно найти: ");
            elem = int.Parse(Console.ReadLine());
            if (array.Contains(elem))
            {
                Console.WriteLine("Элемент присутствует.\n");
            }
            else
            {
                Console.WriteLine("Такого элемента не существует!\n");
            }

            Dictionary<int, long> pairs = new Dictionary<int, long>(5);
            pairs.Add(1, 21252654);
            pairs.Add(2, 12125623);
            pairs.Add(3, 21521634);
            pairs.Add(4, 3161483346);
            pairs.Add(5, 3208523673);
            foreach (object x in pairs)
            {
                Console.Write(x + "\t");
            }
            Console.WriteLine();
            for (int i = 3; i < 5; i++)
            {
                pairs.Remove(i);
            }
            foreach (object x in pairs)
            {
                Console.Write(x + "\t");
            }
            Console.WriteLine("\n");
            pairs[4] = 21215267;
            


            List<long> list = new List<long>();
            foreach (KeyValuePair<int, long> x in pairs)
            {
                list.Add(x.Value);
            }
            foreach (long x in list)
            {
                Console.Write(x + "\t");
            }
            Console.WriteLine("\t");

            Dictionary<int, Person> userType = new Dictionary<int, Person>();
            userType.Add(1, new Client());
            userType.Add(2, new Address());
            userType.Add(3, new Count());
            userType.Add(4, new Operation());
            foreach (KeyValuePair<int, Person> x in userType)
            {
                Console.Write(x.Key + " - ");
                userType[x.Key].Type();
            }
            for (int i = 1; i < 3; i++)
            {
                userType.Remove(i);
            }
            userType[1] = new Client();
            userType[2] = new Operation();

            List<Person> listP = new List<Person>();
            foreach (KeyValuePair<int, Person> x in userType)
            {
                listP.Add(userType[x.Key]);
            }
            Console.WriteLine("\n");

            foreach (Person x in listP)
            {
                x.Type();
            }
            Console.WriteLine("\n");

            if (listP.Contains(userType[1]))
            {
                Console.WriteLine("Элемент присутствует\n");
            }
            else
            {
                Console.WriteLine("Элемент не найден!\n");
            }
            Console.WriteLine("\n");


            ObservableCollection<Person> people = new ObservableCollection<Person>();
            people.CollectionChanged += Change;
            people.Add(new Client());
            people.Add(new Address());
            people.RemoveAt(1);
        }
    }
}
