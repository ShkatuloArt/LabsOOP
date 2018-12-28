using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Lab16
{
    public class Shop
    {
        private BlockingCollection<int> blockingCollection;
        private List<Task> providers;
        private List<Task> customers;

        public Shop()
        {
            blockingCollection = new BlockingCollection<int>();
            providers = new List<Task>();
            customers = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                    providers.Add(new Task(() => Provider(i)));
                customers.Add(new Task(() => Customer(i)));
            }
        }

        public void Start()
        {
            Console.WriteLine("Работа начата!");
            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                    providers[i].Start();
                customers[i].Start();
            }

            Task.WaitAll(customers.ToArray());
        }

        private void Provider(int time)
        {
            blockingCollection.Add(time);
            Thread.Sleep(time * 100);
        }

        private void Customer(int wait)
        {
            wait *= 200;
            if (blockingCollection.TryTake(out wait))
                Console.WriteLine("Клиент не дождался.");
            else Console.WriteLine("Клиент купил вещь.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //task 1
            Stopwatch stopWatch = new Stopwatch();
            int[,] firstMatrix = new int[4, 4];
            int[,] secondMatrix = new int[4, 4];
            int[,] resultMatrix = new int[4, 4];
            firstMatrix = Add();
            secondMatrix = Add();
            Task task1 = new Task(() =>
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        resultMatrix[i, j] = 0;
                        for (int t = 0; t < 4; t++)
                        {
                            resultMatrix[i, j] += firstMatrix[i, t] * secondMatrix[t, j];
                        }
                    }
                }
            });
            stopWatch.Start();
            task1.Start();
            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            Show(resultMatrix);
            Console.WriteLine($"\nTask {task1.Id}: {task1.Status}");
            Console.WriteLine("Затраченное время: " + timeSpan);
            Console.ReadKey();
            //task 2

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Task task2 = new Task(() =>
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        resultMatrix[i, j] = 0;
                        for (int k = 0; k < 4; k++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                Console.WriteLine("Операция прервана");
                                return;
                            }
                            resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                        }
                    }
                }
            });
            Console.WriteLine("\ntask2\nCancellationToken:\n");
            task2.Start();
            Console.WriteLine("Введите Y для отмены операции или другой символ для ее продолжения:");
            string s = Console.ReadLine();
            if (s == "Y" || s == "y")
            {
                tokenSource.Cancel();
            }
            Console.WriteLine($"Status: {task1.Status}");
            Console.ReadKey();
            //task3

            int r = 0;
            Func<int> func = () => { return r += 4; };
            Task<int> resultOne = new Task<int>(func);
            Task<int> resultTwo = new Task<int>(func);
            Task<int> resultThree = new Task<int>(func);
            resultOne.Start();
            resultTwo.Start();
            resultThree.Start();
            Func<int> Formula = () =>
            {
                return resultOne.Result + resultThree.Result * resultThree.Result;
            };
            Task<int> task3 = new Task<int>(Formula);
            task3.Start();
            Console.WriteLine("\ntask3\nResult = " + task3.Result);
            Console.ReadKey();
            //task4

            Task task4 = new Task(() =>
            {
                Console.Write("\ntask4_1\nDoing..");
            });
            Task task4_1 = task4.ContinueWith(t => Console.Write("continuation\n"));
            task4.Start();
            task4_1.Wait();
            Console.ReadKey();
            //task 4_1

            Task<int> what = Task.Run(() => Enumerable.Range(1, 100000).Count(n => (n % 2 == 0)));
            var awaiter = what.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine("\ntask4_2\nResult: " + awaiter.GetResult());
            });
            Console.ReadKey();
            //task5

            Console.WriteLine("\ntask5");
            Random rand = new Random();
            stopWatch.Restart();
            Parallel.For(0, 6, CreateArray);
            stopWatch.Stop();
            Console.WriteLine("\nЗатраченное время при Parallel.For: " + stopWatch.Elapsed);
            stopWatch.Restart();
            for (int j = 0; j < 6; j++)
            {
                int[] array = new int[1000000];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rand.Next(20);
                }
            }
            stopWatch.Stop();
            Console.WriteLine("Затраченное время при For: " + stopWatch.Elapsed + "\n\n");

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6 };
            stopWatch.Restart();
            ParallelLoopResult result = Parallel.ForEach<int>(list, CreateArray);
            stopWatch.Stop();
            Console.WriteLine("\nЗатраченное время при Parallel.ForEach: " + stopWatch.Elapsed);
            stopWatch.Restart();
            foreach (int d in list)
            {
                int[] array = new int[1000000];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rand.Next(20);
                }
            }
            stopWatch.Stop();
            Console.WriteLine("Затраченное время при Foreach: " + stopWatch.Elapsed + "\n");
            Console.ReadKey();
            //task6

            Console.WriteLine("\ntask6");
            Parallel.Invoke(Display,() => Console.WriteLine("Выполняется задача {0}", Task.CurrentId), () => Factorial(5));
            Console.ReadKey();
            //task7

            Console.WriteLine("\ntask7");
            Shop shop = new Shop();
            shop.Start();
            Console.ReadKey();
            //task8

            Console.WriteLine("\ntask8");
            FactorialAsync();
            Console.WriteLine();

        }
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial(8));                            // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");  // выполняется синхронно
        }

        static void Display()
        {
            Console.WriteLine("Выполняется задача {0}", Task.CurrentId);           
        }

        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Console.WriteLine("Выполняется задача {0}", Task.CurrentId);            
            Console.WriteLine("Результат {0}", result);
        }

        static public int[,] Add()
        {
            int[,] matrix = new int[4, 4];
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = rand.Next(20);
                }
            }
            return matrix;
        }

        static public void Show(int[,] matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static public void CreateArray(int d)
        {
            Random rand = new Random();
            int[] array = new int[1000000];
            for (int i = 0; i <array.Length; i ++)
            {
                array[i] = rand.Next(20);
            }
            Console.WriteLine("Выполнена задача " + d);
        }
    }
}
