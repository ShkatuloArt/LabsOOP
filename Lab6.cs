using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    { 
        interface IPers
        {
            void info(string str);
        }
        interface IPerson
        {
            string name { get; set; }
            string address { get; set; }
            double SumSavingAccount { get; set; }
            double SumForeignCurrencyAccount { get; set; }
            double SumCheckingAccount { get; set; }
            double SumTotalAccount { get; set; }
        }
        abstract class Person : IPers, IPerson
        {
            public string name { get; set; }
            public string address { get; set; }
            public bool block1 { get; set; }
            public bool block2 { get; set; }
            public bool block3 { get; set; }
            public bool block4 { get; set; }
            public double SumSavingAccount { get; set; }
            public double SumForeignCurrencyAccount { get; set; }
            public double SumCheckingAccount { get; set; }
            public double SumTotalAccount { get; set; }

            public void info(string str)
            {
                Console.WriteLine(str);
            }
           
            public virtual void Type()
            {
                Console.WriteLine("Банк");
            }
            public Person()
            {
                name = "null";
                address = "null";
                SumSavingAccount = 0;
                SumForeignCurrencyAccount = 0;
                SumCheckingAccount = 0;
                SumTotalAccount = 0;
                block1 = false;
                block2 = false;
                block3 = false;
                block4 = false;
            }

            public virtual void showInfo()
            {
                if (name != "null")
                    Console.WriteLine("Client = {0}", name);
                if (address != "null")
                    Console.WriteLine("Address = {0}", address);
                if (SumSavingAccount != 0)
                    Console.WriteLine("SumSavingAccount = {0};  Блокированный счет?: {1}", SumSavingAccount, block1);
                if (SumForeignCurrencyAccount != 0)
                    Console.WriteLine("SumForeignCurrencyAccount = {0};  Блокированный счет?: {1}", SumForeignCurrencyAccount, block2);
                if (SumCheckingAccount != 0)
                    Console.WriteLine("SumCheckingAccount = {0};  Блокированный счет?: {1}", SumCheckingAccount, block3);
                if (SumTotalAccount != 0)
                    Console.WriteLine("SumTotalAccount = {0};  Блокированный счет?: {1}", SumTotalAccount, block4);
            }
            public virtual void showInfo1()
            {
                double sum = 0;
                sum = SumSavingAccount + SumTotalAccount + SumForeignCurrencyAccount + SumCheckingAccount;
                Console.WriteLine("Сумма со всех счетов у клиента {0}, равна {1}", name, sum);
            }
            public virtual double showInfo2()
            {
                double sum = 0;
                sum = SumSavingAccount + SumTotalAccount + SumForeignCurrencyAccount + SumCheckingAccount;
                return sum;
            }
            public virtual string getclient()
            {
                return name;
            }

        }

        class Client : Person
        {
            public override void Type()
            {
                Console.WriteLine("Клиент");
            }
            public Client()
            {
                name = Console.ReadLine();
                Console.WriteLine("Введите адресс клиента: ");

                address = Console.ReadLine();
                Console.WriteLine("Введите счет и его сумму: ");
                int x;
                do
                {
                    Console.WriteLine("1. Накопительный");
                    Console.WriteLine("2. Валютный");
                    Console.WriteLine("3. Расчетный");
                    Console.WriteLine("4. Общий");
                    Console.WriteLine("0. Прекратить добавлять счета");
                    x = int.Parse(Console.ReadLine());
                    switch (x)
                    {
                        case 1:
                            Console.WriteLine("Сумма на счете");
                            SumSavingAccount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Блокировать счет");
                            string str1 = Console.ReadLine();
                            if (str1 == "Да" || str1 == "да")
                            {
                                block1 = true;
                            }
                            break;
                        case 2:
                            Console.WriteLine("Сумма на счете");
                            SumForeignCurrencyAccount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Блокировать счет");
                            string str2 = Console.ReadLine();
                            if (str2 == "Да" || str2 == "да")
                            {
                                block2 = true;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Сумма на счете");
                            SumCheckingAccount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Блокировать счет");
                            string str3 = Console.ReadLine();
                            if (str3 == "Да" || str3 == "да")
                            {
                                block3 = true;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Сумма на счете");
                            SumTotalAccount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Блокировать счет");
                            string str4 = Console.ReadLine();
                            if (str4 == "Да" || str4 == "да")
                            {
                                block4 = true;
                            }
                            break;
                    }
                } while (x != 0);
            }
        }


        sealed class Address : Person
        {
            public override void Type()
            {
                Console.WriteLine("Адрес");
            }
            public Address()
            {
                address = Console.ReadLine();
            }
        }
        class SavingAccount : Person
        {
            public override void Type()
            {
                Console.WriteLine("Накопительный счет:");
            }
            public SavingAccount()
            {
                Console.WriteLine("Сумма на счете");
                SumSavingAccount = int.Parse(Console.ReadLine());
                Console.WriteLine("Блокировать счет");
                string str = Console.ReadLine();
                if (str == "Да" || str == "да")
                {
                    block1 = true;
                }
            }
        }
        class ForeignCurrencyAccount : Person
        {
            public override void Type()
            {
                Console.WriteLine("Валютный счет: ");
            }
            public ForeignCurrencyAccount()
            {
                Console.WriteLine("Сумма на счете");
                SumForeignCurrencyAccount = int.Parse(Console.ReadLine());
                Console.WriteLine("Блокировать счет");
                string str = Console.ReadLine();
                if (str == "Да" || str == "да")
                {
                    block2 = true;
                }
            }
        }
        class CheckingAccount : Person
        {
            public override void Type()
            {
                Console.WriteLine("Расчетный счет: ");
            }
            public CheckingAccount()
            {
                Console.WriteLine("Сумма на счете");
                SumCheckingAccount = int.Parse(Console.ReadLine());
                Console.WriteLine("Блокировать счет");
                string str = Console.ReadLine();
                if (str == "Да" || str == "да")
                {
                    block3 = true;
                }
            }
        }
        class TotalAccount : Person
        {
            public override void Type()
            {
                Console.WriteLine("Общий счет: ");
            }
            public TotalAccount()
            {
                Console.WriteLine("Сумма на счете");
                SumTotalAccount = int.Parse(Console.ReadLine());
                Console.WriteLine("Блокировать счет");
                string str = Console.ReadLine();
                if (str == "Да" || str == "да")
                {
                    block4 = true;
                }
            }
        }

        enum Numerus : byte
        {
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        struct Structur
        {
            string name;
            int age;
            string sex;
            string adress;


            public Structur(string name, int age, string sex, string adress) : this()
            {
                this.age = age;
                this.name = name;
                this.sex = sex;
                this.adress = adress;
            }

            public void info()
            {
                Console.WriteLine("name = {0}; age = {1}; sex = {2}; adress = {3}", name, age, sex, adress);
            }
        }


        class CountClient
        {
            string name;
            public CountClient(string vName)
            {
                name = vName;
            }
            public Person[] array = new Person[0];

            public Person AddElem
            {
                private get
                {
                    return AddElem;
                }
                set
                {
                    Array.Resize(ref array, array.Length + 1);
                    array[array.Length - 1] = value;
                }
            }
            public void ShowElem()
            {
                Console.WriteLine("\nСписок клиентов");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write("{0}.", i + 1);
                    array[i].showInfo();
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n");
            }
            public void DeleteElem(int k)
            {
                for (int i = k - 1; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                Array.Resize(ref array, array.Length - 1);
            }
            public void AllSum(int k)
            {
                array[k-1].showInfo1();
            }
            public void AllSumClient()
            {
                double allsum = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    allsum += array[i].showInfo2();
                }
                Console.WriteLine("Сумма со всех счетов равна = {0}", allsum);
            }
            public void FindElem(string str)
            {
                bool flag = true;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].getclient() == str)
                    {
                        array[i].showInfo();
                        flag = false;
                    } 
                }
                if (flag)
                {
                    Console.WriteLine("Такого клиента не существует!");
                }
            }

        }

        public class Control
        {
            static string name = "None";
            public Control(string vName)
            {
                name = vName;
            }
            CountClient Bank = new CountClient(name);

            public void AddElem()
            {
                Console.WriteLine("Введите имя клиента: ");
                Bank.AddElem = new Client();
               
            }
            public void ShowElem()
            {
                Bank.ShowElem();
            }
            public void DeleteElem()
            {
                Console.Write("Введите элемент который хотите удалить: ");
                int k = int.Parse(Console.ReadLine());
                Bank.DeleteElem(k);
            }
            public void AllSum()
            {
                Console.Write("Введите номер клиента, о котором хотите узнать: ");
                int k = int.Parse(Console.ReadLine());
                Bank.AllSum(k);
            }
            public void AllSumClient()
            {
                Bank.AllSumClient();
            }
            public void FindElem()
            {
                Console.WriteLine("\nВведите имя клиента: ");
                string str = Console.ReadLine();
                Bank.FindElem(str);
            }
        }
        
        static void Main(string[] args)
        {
            int k = 0;
            Console.WriteLine("Введите имя банка: ");
            string name = Console.ReadLine();
            Control bank = new Control(name);
            do
            {
                Console.WriteLine("Выберите далнеишие действия:");
                Console.WriteLine("1. Добавить клиента");
                Console.WriteLine("2. Удалить клиента");
                Console.WriteLine("3. Вся информация о клиентах");
                Console.WriteLine("4. Вывести общий сумму на всех счетах клиента");
                Console.WriteLine("5. Вывести общую сумму на всех счетах");
                Console.WriteLine("6. Поиск клиента по имени");
                Console.WriteLine("0. Выход");
                k = int.Parse(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        bank.AddElem(); break;
                    case 2:
                        bank.DeleteElem(); break;
                    case 3:
                        bank.ShowElem(); break;
                    case 4:
                        bank.AllSum(); break;
                    case 5:
                        bank.AllSumClient(); break;
                    case 6:
                        bank.FindElem(); break;
                }
            } while (k != 0);
        }
    }
}
