using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab8
{
    public static class MathOperation
    {
        public static void HowMuchelements(Queue1<int> operand)
        {
            operand.Quantity();
        }
        public static void Search(string str)
        {
            foreach (char x in str)
            {
                if ((x == '0') || (x == '1') || (x == '2') || (x == '3') || (x == '4') || (x == '5') || (x == '6') || (x == '7') || (x == '8') || (x == '9'))
                {
                    Console.WriteLine("Первая цифра {0}", x);
                    break;
                }
            }
        }
    }
    interface IOperations<T>
    {
        void Out();
        void Add(T obj);
        void Delete();
    }
    public class Queue1<T> : IOperations<T> where T : struct
    {
        public int counter = 0;
        Queue<T> queue = new Queue<T>();
        public void Out()
        {
            foreach (T s in queue)
            {
                Console.Write(s + "\t");
            }
        }
        public void Add(T obj)
        {
            queue.Enqueue(obj);
            counter += 1;
        }
        public void Delete()
        {
            counter -= 1;
            queue.Dequeue();
        }
        public void Quantity()
        {
            Console.WriteLine("Колличество элементов {0}", counter);
        }
        public class Owner
        {
            public int id;
            public string name;
            public string organization;
            public Owner()
            {
                id = 72171098;
                name = "Artem";
                organization = "BSTU";
            }
        }
        public class Date
        {
            public string data;
            public Date()
            {
                data = "20 november 2018";
            }
        }
       
        public static T operator /(Queue1<T> operand, T obj)
        {
            operand.Add(obj);
            return obj;
        }
        public static Queue1<T> operator ++(Queue1<T> operand)
        {
            operand.Delete();
            return operand;
        }
        public static implicit operator Queue1<T>(int v)
        {
            throw new NotImplementedException(); 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue1<int> queue1 = new Queue1<int>();
            int k = 0;
            do
            {
                Console.WriteLine("\n1. Добавить элемент");
                Console.WriteLine("2. Вывести элемент");
                Console.WriteLine("3. Удалить элемент");
                Console.WriteLine("4. Колличество элементов");
                Console.WriteLine("5. Работа со строкой");
                Console.Write("Выберите действие: ");
                k = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (k)
                {
                    case 1:
                        try
                        { 
                            Console.Write("Введите число: ");
                            int x = int.Parse(Console.ReadLine());
                            queue1 = queue1 / x;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Операция завершена");
                        }
                        break;
                    case 2:
                        queue1.Out();
                        break;
                    case 3:
                        try
                        {
                            queue1++;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Операция завершена");
                        }
                        break;
                    case 4:
                        MathOperation.HowMuchelements(queue1);
                        break;
                    case 5:
                        try
                        {
                            Console.WriteLine("Введите строку");
                            string str = Console.ReadLine();
                            MathOperation.Search(str);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Операция завершена");
                        }
                        break;
                }
            } while (k != 0);
        }
    }
}
