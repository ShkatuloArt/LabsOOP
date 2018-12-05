using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{ 
    class Car
    {
        public int id;
        public string brand;
        public string model;
        public int year;
        public string color;
        public int price;
        public string number;
        static public int counter;
        public int age;
        internal const int ton = 2018;

        public Car(int id, string brand, string model, int year, string color, int price, string number) //конструктор
        { 
            this.id = id;
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.color = color;
            this.price = price;
            this.number = number;
            age = ton - year;
            counter++;
        }
        
        public void GetInfo()
        {
            Console.WriteLine($"ID номер: {id};\nМарка автомобиля: {brand};\nМодель автомобиля: {model};\nГод выпуска: {year};\n" +
                $"Цвет автомобиля: {color};\nЦена автомобиля: {price};\nРегистрационный номер: {number};\nВремя эксплуатации: {age} лет");
        }
       
        public static void StaticMethod()
        {
            Console.WriteLine($"\n\nИнформация с помощью статического метода о классе:\nВ классе создано {counter} объектов");
        }
        public partial class Part
        {
            int a;
        }
        public partial class Part
        {
            public string Name { get; set; }
            public Part(int a)
            {
                this.a = a = 10;
            }
            public void PartMethod()
            {
                Console.WriteLine($"\n\nИспользование класса partial: {a}");
            }
        }
    }
    class Player
    {
        public string Name { get; set;  }
        public string Team { get; set; }
    }
    class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };          
            var sequence = from n in months
                                           where n.Length < 5
                                           select n; 
            foreach (var name in sequence)
            {
                Console.WriteLine("{0}", name);
            }
            Console.WriteLine("\n");
            sequence = from n in months
                       where n == "January" || n == "February" || n == "December" || n == "June" || n == "July" || n == "August"
                       select n;
            foreach (var name in sequence)
            {
                Console.WriteLine("{0}", name);
            }
            Console.WriteLine("\n");
            sequence = from n in months
                       orderby n
                       select n;
            foreach (var name in sequence)
            {
                Console.WriteLine("{0}", name);
            }
            Console.WriteLine("\n");
            sequence = from n in months
                       where n.Length > 3 && n.Contains("u")
                       select n;
            foreach (var name in sequence)
            {
                Console.WriteLine("{0}", name);
            }
            Console.WriteLine("\n");
            List<Car> cars = new List<Car>();
            var firstCar = new Car(27, "BMW", "X5", 2012, "black", 7000, "0325fg");
            var secondCar = new Car(23, "Mercedes", "AMG 531", 2014, "black", 15000, "0368gdg");
            var thirdCar = new Car(27, "Audi", "RS6", 2011, "black", 10000, "h493fg");
            var fourthCar = new Car(37, "BMW", "i8", 2016, "red", 20000, "h49dfjg");
            var fivethCar = new Car(39, "Bugatti", "Chiron", 2017, "blue", 3000000, "7777889");
            var sixthCar = new Car(29, "Hyndai", "Sonata", 2015, "white", 30000, "dsjhgh6");
            cars.Add(firstCar);
            cars.Add(secondCar);
            cars.Add(thirdCar);
            cars.Add(fourthCar);
            cars.Add(fivethCar);
            cars.Add(sixthCar);
            Console.WriteLine("Список автомобилей задданной марки\n");
            var selectedCar = from n in cars
                              where n.brand == "BMW"
                              select n;
            foreach (var i in selectedCar)
            {
                i.GetInfo();
                Console.WriteLine();
            }
            Console.WriteLine("\n");

            Console.WriteLine("Список автомибилей заданной модели и эксплуатация больше s лет\n");
            Console.Write("Введите число s = ");
            int s = int.Parse(Console.ReadLine());
            selectedCar = from n in cars
                          where n.model == "RS6" && n.age > s
                          select n;
            foreach (var i in selectedCar)
            {
                i.GetInfo();
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            Console.WriteLine("Колличество автомобилей заданного цвета и дипазона цены\n");
            int size = (from n in cars where n.color == "black" && n.price > 11000 && n.price < 17000 select n).Count();
            Console.WriteLine(size);
            Console.WriteLine("\n");

            Console.WriteLine("Самый старый автомобиль\n");
            int max = cars.Max(n => n.age);
            selectedCar = from n in cars
                          where n.age == max
                          select n;
            foreach (var i in selectedCar)
            {
                i.GetInfo();
                Console.WriteLine();
            }
            Console.WriteLine("\n");


            Console.WriteLine("Первых пять самых новых автомобилей\n");
            selectedCar = cars.OrderBy(n => n.age).Take(5);
            foreach (var i in selectedCar)
            {
                i.GetInfo();
                Console.WriteLine();
            }
            Console.WriteLine("\n");

            Console.WriteLine("Автомобили упорядоченный по цене\n");
            selectedCar = cars.OrderByDescending(n => n.price);
            foreach (var i in selectedCar)
            {
                i.GetInfo();
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" }
            };
            List<Player> players = new List<Player>()
            {
                new Player {Name="Месси", Team="Барселона"},
                new Player {Name="Суарез", Team="Барселона"},
                new Player {Name="Роббен", Team="Бавария"},
                new Player {Name="Роналдо", Team="Ювентус"}
            };
            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { Name = pl.Name, Team = pl.Team, Country = t.Country };

            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1} ({2})", item.Name, item.Team, item.Country);
            }
        }
    }
}
