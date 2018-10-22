using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Car one = new Car();
            one.GetInfo();
            Console.WriteLine($"Hash={one.ID}");
            Car two = new Car(1, "Toyota", "camry", 2010, "black", "11000", "d4g5")     
                Id = 5,
                Brand = "BMW",
                Model = "x6",
                Year = 2012,
                Color = "white",
                Price = "14000",
                Number = "31fs",
            };
            two.GetInfo();
            Console.WriteLine($"Hash={two.ID}");
            Car three = new Car(0, " ");
            three.Id = 56;
            three.Number = "24fh";
            three.GetInfo();
            Console.WriteLine($"Hash={three.ID}");

            // OUT AND REF
            int g = 46;
            three.OutRef(ref g, out string j);
            Console.WriteLine(three.GetType());
            Console.WriteLine(three.ToString());
            Console.WriteLine(three.GetHashCode());

            Car.StaticMethod();

            //Закрытый конструктор
            Car FOR = new Car(214);
            FOR.Brand = "Audi";
            FOR.Model = "Q7";
            FOR.GetInfo();
            Console.WriteLine(FOR.GetHashCode());
            // сравнение
            Car OneE = new Car("9000");
            Car TwoE = new Car("3144");
            Console.WriteLine();
            Console.WriteLine(OneE.Equals(TwoE));
            // анонимный тип
            var anonymType = new { Id = 232, Brand = "Wolkswagen", Model = "Golf-2", Year = 2009, Color = "Grey", Price = "4000", Number = "frg213" };
            Console.WriteLine($"\nАнонимный тип:  {anonymType.GetType()}");
            //Создать массив объектов. Вывести: 
            //a)  список автомобилей заданной марки; 
            //b)  список автомобилей заданной модели, которые эксплуатируются больше n лет; 
            Car[] ArrayObject = new Car[2];
            for (int i = 0; i < 2; i++)
            {
                ArrayObject[i] = new Car();
                Console.WriteLine("\n\nВведите идентификационный номер:  ");
                ArrayObject[i].Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n\nВведите марку автомобиля:  ");
                ArrayObject[i].Brand = Console.ReadLine();
                Console.WriteLine("\n\nВведите модель автомобиля:  ");
                ArrayObject[i].Model = Console.ReadLine();
                Console.WriteLine("\n\nВведите год выпуска автомобиля:  ");
                ArrayObject[i].Year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n\nВведите цвет автомобиля:  ");
                ArrayObject[i].Color = Console.ReadLine();
                Console.WriteLine("\n\nВведите цену автомобиля:  ");
                ArrayObject[i].Price = Console.ReadLine();
                Console.WriteLine("\n\nВведите регистрационный номер:  ");
                ArrayObject[i].Number = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"\nНомер №{i}");
                Console.WriteLine($"Идентификационный номер:{ArrayObject[i].Id}");
                Console.WriteLine($"Марка автомобиля:{ArrayObject[i].Brand}");
                Console.WriteLine($"Модель автомобиля:{ArrayObject[i].Model}");
                Console.WriteLine($"Год выпуска автомобиля:{ArrayObject[i].Year}");
                Console.WriteLine($"Цвет автомобиля:{ArrayObject[i].Color}");
                Console.WriteLine($"Цена автомобиля:{ArrayObject[i].Price}");
                Console.WriteLine($"Регистрационный номер:{ArrayObject[i].Number}");
            }
            Console.WriteLine("\n\nВведите марку автомобиля: ");
            string SearchBrand = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                if (SearchBrand == ArrayObject[i].Brand)
                {
                    Console.WriteLine($"\n\nНайденные марки: \n{ArrayObject[i].Id}\n{ArrayObject[i].Brand}\n{ArrayObject[i].Model}\n{ArrayObject[i].Year}" +
                        $"\n{ArrayObject[i].Color}\n{ArrayObject[i].Price}\n{ArrayObject[i].Number}");
                }
            }
            Console.WriteLine("\n\nВведите модель автомобиля: ");
            string SearchModel = Convert.ToString(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                int Age = Car.AgeMethod(ArrayObject[i].Year);
                if ((SearchModel == ArrayObject[i].Model) && (Age < 8))
                {
                    Console.WriteLine($"\n\nНайденные модели: \n{ArrayObject[i].Id}\n{ArrayObject[i].Brand}\n{ArrayObject[i].Model}\n{ArrayObject[i].Year}" +
                        $"\n{ArrayObject[i].Color}\n{ArrayObject[i].Price}\n{ArrayObject[i].Number}");
                }
            }
            //количество созданных объектов
            three.Counter();

        }

        class Car
        {
            private int id;
            public int Id
            {
                set
                {
                    if (value == 0) { Console.WriteLine("Некорректный номер идентификатора"); }
                    else
                    {
                        Console.WriteLine("Данные id введены правильно");
                        id = value;
                    }
                }
                get
                {
                    return id;
                }
            }
            private string brand;
            public string Brand
            {
                set
                {
                    if (value == " ") { Console.WriteLine("Некорректная марка автомобиля"); }
                    else
                    {
                        Console.WriteLine("Данные brand введены правильно");
                        brand = value;
                    }
                }
                get
                {
                    return brand;
                }
            }
            private string model;
            public string Model
            {
                set
                {
                    if (value == " ") { Console.WriteLine("Некорректная модель автомобиля"); }
                    else
                    {
                        Console.WriteLine("Данные model введены правильно");
                        model = value;
                    }
                }
                get
                {
                    return model;
                }
            }
            private int year;
            public int Year
            {
                set
                {
                    if (value == 0) { Console.WriteLine("Некорректный год выпуска"); }
                    else
                    {
                        Console.WriteLine("Данные year введены правильно");
                        year = value;
                    }
                }
                get
                {
                    return year;
                }
            }
            private string color;
            public string Color
            {
                set
                {
                    if (value == " ") { Console.WriteLine("Некорректный цвет автомобиля"); }
                    else
                    {
                        Console.WriteLine("Данные color введены правильно");
                        color = value;
                    }
                }
                get
                {
                    return color;
                }
            }
            private string price;
            public string Price
            {
                set
                {
                    if (value == " ") { Console.WriteLine("Некорректная цена автомобиля"); }
                    else
                    {
                        Console.WriteLine("Данные price введены правильно");
                        price = value;
                    }
                }
                get
                {
                    return price;
                }
            }
            private string number;
            public string Number
            {
                set
                {
                    if (value == " ") { Console.WriteLine("Некорректный регистрационный номер"); }
                    else
                    {
                        Console.WriteLine("Данные number введены правильно");
                        number = value;
                    }
                }
                get
                {
                    return number;
                }
            }
            static public int counter;
            public readonly double ID;
            public string H;
            public int value { get; set; } = 1;
            internal const int ton = 2018;
            
            static Car()// Статический конструктор
            {
                Console.WriteLine("Вызван конструктор static\n");
                string a = "porshe";
                string b = "panamera";
                counter++;
            }
            public Car() //конструкор класса Car без параметров(по умолчанию)
            {
                Console.WriteLine("Первый конструктор (по умолчанию)");
                id = 23;
                brand = "BMW";
                model = "X5";
                year = 2008;
                color = "black";
                price = "8000";
                number = "4r5t";
                ID = GetHashCode();
                counter++;
            }
            public Car(int id,string brand, string model, int year, string color, string price, string number) //конструктор
            {
                Console.WriteLine("\nВторой конструктор");
                this.id = id;
                this.brand = brand;
                this.model = model;
                this.year = year;
                this.color = color;
                this.price = price;
                this.number = number;
                ID = GetHashCode();
                counter++;
            }
            public Car(int num, string reg) // Третий конструктор
            {
                Console.WriteLine("\nТретий конструктор");
                num = 26;
                reg = "23dgde";
                ID = GetHashCode();
                counter++;
            }
            public Car(double Num1) // Четвертый конструктор, в котором вызван закрытый конструктор
            {
                Num1 = 142;
                Car closed = new Car("Chevrole", "Comaro", 2013);
                closed.Id = (int)Num1;
                closed.GetInfo();
                Console.WriteLine("\nЧетвертый конструктор, в котором вызван закрытый конструктор\n");
                ID = GetHashCode();
                counter++;
            }
            private Car(string privatebrand, string privatemodel, int privateyear) // закрытый конструктор
            {
                Console.WriteLine("\nЗакрытый конструктор\n");
                brand = privatebrand;
                model = privatemodel;
                year = privateyear;
                counter++;
            }
            public Car(string price)
            {
                this.price = price;
                ID = GetHashCode();
                counter++;
            }
            public void GetInfo()
            {
                Console.WriteLine($"ID номер: {id};\nМарка автомобиля: {brand};\nМодель автомобиля: {model};\nГод выпуска: {year};\n" +
                    $"Цвет автомобиля: {color};\nЦена автомобиля: {price};\nРегистрационный номер: {number}.");
            }//Вывод всей инфы
            public override int GetHashCode()
            {
                H = brand;
                int hash = 269;
                hash = string.IsNullOrEmpty(H) ? 0 : H.GetHashCode();
                hash = (hash * 48) + value.GetHashCode();
                return hash;
            } //хэш
            public void OutRef(ref int id, out string model)
            {
                Console.WriteLine("\nМетод с OUT and REF");
                this.model = model = "cs2443";
                id = 100;
                Console.WriteLine(model);
                Console.WriteLine(id);
            }
            public static void StaticMethod()
            {
                Console.WriteLine($"\n\nИнформация с помощью статического метода о классе:\nВ классе создано {counter} объектов");
            }
            public static int AgeMethod(int NUM)
            {
                int z = ton - NUM;
                return z;
            }
            public void Counter()
            {
                Console.WriteLine($"\n\nКоличество созданных объектов = {counter}");
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
    }
}
