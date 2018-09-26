using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static (int, string, int) GetValue()
        {
            int result = 18;
            string name = "Artem";
            int result2 = 193;
            return (result, name, result2);
        }
        static void Main(string[] args)
        {
            //a
            sbyte Byte = 1;
            short Num = 2;
            int Num_1 = 10;
            long Num_2 = 22341525;
            double D = 234.1243d;
            uint num_1 = 20;
            float f = 1.23f;
            bool boolean = false;
            string name = "George";
            char n = 'G';

            //b
            byte b = 5;
            short s = b;
            int p = b;
            long l = b;
            double d = l;
            Console.WriteLine("Short = {0}, Int = {1}, Long = {2}, Double = {3}", s, p, l, d);
            int r = (int)l;
            byte k = (byte)d;
            //c
            int box = 5;
            Object o = box;
            byte m = (byte)(int)o;
            //d
            var mas = new[] { 2, 3, 4, 5, 8 };
            Console.WriteLine(mas.GetType());
            //e
            int? x1 = null;
            int? x2 = null;
            Console.WriteLine(x1 == x2);
            // 2 a
            string str1 = "abcd";
            string str2 = "abf";
            Console.WriteLine(str1 == str2);
            // b
            string string1 = "Hello ";
            string string2 = "World ";
            string string3 = "!!!!!!";
            Console.WriteLine(string1 + string2 + string3);
            string str = String.Copy(string2);
            Console.WriteLine(str);
            str = (string1 + string2 + string3).Substring(3, 7);
            Console.WriteLine(str);
            string[] clubs = (string1 + string2 + string3).Split(' ');
            Console.WriteLine(clubs[1]);
            Console.WriteLine((string1 + string2 + string3).Insert(6, "My "));
            Console.WriteLine((string1 + string2 + string3).Remove(13, 5));
            // c
            string STR = "";
            string STR1 = null;
            Console.WriteLine(String.IsNullOrEmpty(STR));
            Console.WriteLine((STR == STR1) + "    " + (STR + STR1));
            // d
            StringBuilder sb = new StringBuilder("ABC", 50);
            sb.Append(new char[] { 'D', 'E', 'F' });
            Console.WriteLine(sb.ToString());
            sb.Insert(0, "Alphabet: ");
            Console.WriteLine(sb.ToString());
            Console.WriteLine(sb.Remove(10, 2));
            // 3 a
            int[,] MAS = new int[2, 3];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    MAS[i, j] = i + j;
                    Console.Write(MAS[i, j] + "  ");
                }
                Console.WriteLine();
            }
            // b
            string[] string_mas = { "Arsenal ", "Bavaria ", "Real " };
            foreach (string word in string_mas) Console.Write(word);
            Console.WriteLine();
            Console.WriteLine("Length string_mas: " + string_mas.Length);
            string slowo = string_mas[1];
            string_mas[1] = string_mas[2];
            string_mas[2] = slowo;
            foreach (string word in string_mas) Console.Write(word);
            Console.WriteLine();
            // c
            float[][] float_mas = { new float[2], new float[3], new float[4] };
            for (int i = 0; i < 2; i++)
            {
                float_mas[0][i] = Convert.ToSingle(Console.ReadLine());
            }
            for (int i = 0; i < 3; i++)
            {
                float_mas[1][i] = Convert.ToSingle(Console.ReadLine());
            }
            for (int i = 0; i < 4; i++)
            {
                float_mas[2][i] = Convert.ToSingle(Console.ReadLine());
            }
            foreach (float[] MASFLOAT in float_mas)
            {
                foreach (float MASFLOAT1 in MASFLOAT)
                    Console.Write("\t" + MASFLOAT1);

                Console.WriteLine();
            }
            // d
            var array = new[] { 2, 3, 4, 5, 8 };
            var array1 = new[] { "BMW", "Audi", "Mercedes", "Toyota" };
            Console.WriteLine(array.GetType());
            Console.WriteLine(array1.GetType());
            //4 a
            (int age, string name, char gender, string city, ulong height) student = (18, "Artem", 'm', "Minsk", 193);
            // b
            Console.WriteLine($" {student}");
            Console.WriteLine(student.age);
            Console.WriteLine(student.Item3);
            Console.WriteLine(student.Item4);
            Console.WriteLine();
            // c
            var (one, two, three) = GetValue();
            Console.WriteLine(two);
            Console.WriteLine(three);
            Console.WriteLine(one);
            // d
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            Console.WriteLine(left == right);
            // 5
            int [] Array_1 = new int[] { 6, 4, 2, 7, 8 };
            string nam = "Artem";
             (int, int, int, char) LocFun(int[] A, string firstName)
            {
                int max1 = 0;
                int min1 = 20;
                int sum1 = 0;
                char symbol1 = (char)(firstName[0]);
                for (int i = 0; i < A.Length; i ++)
                {
                    if (A[i] > max1)
                        max1 = A[i];
                    if (A[i] < min1)
                        min1 = A[i];
                    sum1 += A[i];
                }

                return (max1, min1, sum1, symbol1);
            }
            var someTuple = LocFun(Array_1, nam);
            Console.WriteLine($" {someTuple}");
        }
    }
}
