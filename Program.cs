using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public static class MathOperation
    {
        static int min = 0;
        static int max = 0;
        public static void MaxAndMin(Queue A)
        {
            for (int i = 0; i < A.array.Count(); i++)
            {
                if (A.array[i] > max)
                {
                    max = A.array[i];
                }
                if (A.array[i] < min)
                {
                    min = A.array[i];
                }
            }
            Console.WriteLine($"\n\nMax={max}");
            Console.WriteLine($"\nMin={min}");
        }
        public static void HowMuchelements(Queue A)
        {
            A.Quantity();
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
    public class Node
    {
        public int value;
        public Node next;
        public Node()
        {
            value = 0;
            next = null;
        }
        public Node(int value)
        {
            this.value = value;
            next = null;
        }
    }
    public class Queue
    {
        public int counter = 0;
        public Queue()
        {

        }
        public bool IsEmpty()
        {
            return Begin == null;
        }
        public List<int> array = new List<int>();
        public void Push(int value)
        {
            array.Add(value);
            if (IsEmpty())
            {
                Begin = End = new Node(value);
                counter++;
                Console.WriteLine("Добавлен элемент {0}", End.value);
            }
            else
            {
                Node newNode = new Node(value);
                End.next = newNode;
                End = newNode;
                counter++;
                Console.WriteLine("Добавлен элемент {0}", End.value);
            }
        }
        public void Out()
        {
            foreach (var x in this.array)
            {
                Console.WriteLine(x);
            }
        }
        public int Del()
        {
            if (!IsEmpty())
            {
                Node m = Begin;
                int a = m.value;
                Begin = m.next;
                m.next = null;
                array.Remove(a);
                Console.WriteLine("Удален элемент {0}", a);
                counter--;
                return a;
            }

            else
            {
                throw new Exception("Очередь пуста");
            }
        }
        public bool Check()
        {
            Begin1 = Begin;
            bool key = false;
            for (int i = 0; i < counter; i++)
            {
                if (!IsEmpty())
                {

                    Node b = Begin1;
                    int a = b.value;
                    if (a % 2 == 0)
                    {
                        key = true;
                    }
                    if (b.next != null)
                        Begin1 = b.next;
                    else
                        break;
                }
            }
            return key;
        }
        public void OutPut()
        {
            Begin1 = Begin;
            for (int i = 0; i < counter; i++)
            {
                if (!IsEmpty())
                {
                    Node b = Begin1;
                    int a = b.value;
                    Console.WriteLine("Элемент очереди {0}", a);
                    if (b.next != null)
                        Begin1 = b.next;
                    else
                        break;
                }
            }
        }
        public void ResZero()
        {
            Begin1 = Begin;
            for (int i = 0; i < counter; i++)
            {
                if (!IsEmpty())
                {
                    Node b = Begin1;
                    int a = b.value;
                    if (a < 0)
                    {
                        b.value = 0;
                    }
                    if (b.next != null)
                        Begin1 = b.next;
                    else
                        break;
                }
            }
        }
        public int Counte()
        {
            Begin1 = Begin;
            int cnt = 0;
            for (int i = 0; i < counter; i++)
            {
                if (!IsEmpty())
                {
                    Node b = Begin1;
                    int a = b.value;
                    if (a > 0)
                    {
                        cnt += 1;
                    }
                    if (b.next != null)
                        Begin1 = b.next;
                    else
                        break;
                }
            }
            return cnt;
        }
        public Node Begin1 { get; private set; }
        public Node Begin { get; private set; }
        public Node End { get; private set; }


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
                data = "16 oktober 2018";
            }
        }
        public static int operator /(Queue A, int a)
        {
            A.Push(a);
            return a;
        }
        public static Queue operator ++(Queue A)
        {
            A.Del();
            return A;
        }
        public static bool operator false(Queue A)
        {
            return A.Check();
        }
        public static bool operator true(Queue A)
        {
            return A.Check();
        }
        public static explicit operator int(Queue A)
        {
            int a = A.Counte();
            return a;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue A = new Queue();
            int Elem = A / 8;
            Elem = A / 7;
            Elem = A / 11;
            Elem = A / 67;
            Elem = A / -56;
            Elem = A / 56;
            A++;
            A++;
            Console.WriteLine("Cуществуют ли четные элементы в очереди?");
            if (A)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
            MathOperation.MaxAndMin(A);
            MathOperation.HowMuchelements(A);
            A.ResZero();
            A.OutPut();
            int count = (int)A;
            Console.WriteLine("Колличество положительных элементов {0}", count);
            string str = "s4dh56gsdjg";
            MathOperation.Search(str);
        }
    }
}