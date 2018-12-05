using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class User
    {
        public delegate void UserEvent(string str);
        public delegate int Year(int age);
        Year year = (int age) => { int a =2018 - age;
            Console.WriteLine("asg");
            return a;
        };
        public event UserEvent OnMove;
        public event UserEvent OnCompression;

        public string name;
        public int age;
        public int pos = 0;
        public double size = 1;
        
        public User()
        {
            name = "";
            age = 0;
        }

        public User(string name, int age) : this()
        {
            this.name = name;
            this.age = age;
        }


        public void UserMove(int move)
        {
            pos += move;

            if (OnMove != null)
            {
                OnMove($"Текущая позиция {name} = {pos}");
            }
            else
            {
                Console.WriteLine($"{name} не подписан на событие OnMove");
            }
        }

        public void UserCompression(double compressionRatio)
        {
            size *= compressionRatio;

            if (OnCompression != null)
            {
                OnCompression($"Текущий размер {name} = {compressionRatio}");
            }
            else
            {
                Console.WriteLine($"{name} не подписан на событие OnCompression");
            }
        }

        public void info()
        {
            Console.WriteLine($"name: {name}");
            Console.WriteLine($"age: {age}");
            Console.WriteLine($"Year of Birth: {year(age)}");
            Console.WriteLine($"size: {size}");
            Console.WriteLine($"position: {pos}");
            Console.WriteLine("\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User firstUser = new User("Shkatulo Artem", 18);
            User secondUser = new User("Sheiko Anton", 20);
            User thirdUser = new User("Korbut Ivan", 24);
            User fourthUser = new User("Morozov Dima", 18);

            firstUser.OnMove += Subscription;
            secondUser.OnCompression += Subscription;
            thirdUser.OnMove += Subscription;
            thirdUser.OnCompression += Subscription;
            
            firstUser.UserCompression(10);
            firstUser.UserMove(3);
            firstUser.info();

            secondUser.UserCompression(8.9);
            secondUser.UserMove(-5);
            secondUser.info();

            thirdUser.UserCompression(7.6);
            thirdUser.UserMove(7);
            thirdUser.info();

            fourthUser.UserCompression(34.2);
            fourthUser.UserMove(-24);
            fourthUser.info();

            Action<string> action;
            string str = "СтРока кОторУю НужнО иЗменИть";
            action = ToUpperCase;
            action(str);

            action -= ToUpperCase;
            action += ToLowerCase;
            action(str);

            action -= ToLowerCase;
            action += ReplaceLiter;
            action(str);

            action += ToUpperCase;
            action += RemoveString;
            action(str);
        }

        static public void Subscription(string subscription)
        {
            Console.WriteLine(subscription);
        }
        static public void ToUpperCase(string str)
        {
            str = str.ToUpper();
            Console.WriteLine(str);
        }
        static public void ToLowerCase(string str)
        {
            str = str.ToLower();
            Console.WriteLine(str);
        }
        static public void ReplaceLiter(string str)
        {
            str = str.Replace(' ', '|');
            Console.WriteLine(str);
        }
        static public void RemoveString(string str)
        {
            str = str.Remove(6);
            Console.WriteLine(str);
        }
    }
}
