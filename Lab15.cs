using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;
using System.IO;


namespace OOP_lab_15
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            //задание 1
            foreach (Process process in Process.GetProcesses())
            {
                Console.WriteLine("ID--- {0}\tName--- {1}\t\tPriority--- {2}\t\tVirtualMemory--- {3}", process.Id,
                    process.ProcessName, process.BasePriority, process.VirtualMemorySize64);
            }

            //задание 2
            AppDomain domain = AppDomain.CurrentDomain;
            AppDomainSetup setup = domain.SetupInformation;
            Console.WriteLine("Name - {0}", domain.FriendlyName);
            Console.WriteLine("Base Directory - {0} \n", domain.BaseDirectory);
            Console.WriteLine("SetupInformation of domain:");
            Console.WriteLine("Name of directory - {0}", setup.ApplicationBase);
            Console.WriteLine("Activator args - {0}", setup.ActivationArguments);
            Console.WriteLine("Loader optimize - {0}", setup.LoaderOptimization);
            Assembly[] assemb = domain.GetAssemblies();
            foreach (Assembly asm in assemb)
            {
                Console.WriteLine(asm.GetName().Name);
            }
            Console.WriteLine("\n");

            AppDomain secondaryDomain = AppDomain.CreateDomain("Secondary domain");
            // событие загрузки сборки
            secondaryDomain.AssemblyLoad += Domain_AssemblyLoad;
            // событие выгрузки домена
            secondaryDomain.DomainUnload += SecondaryDomain_DomainUnload;

            Console.WriteLine("Домен: {0}", secondaryDomain.FriendlyName);
            secondaryDomain.Load(new AssemblyName("Lab14"));
            Assembly[] assemblies = secondaryDomain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);
            // выгрузка домена
            AppDomain.Unload(secondaryDomain);
            Console.WriteLine("\n");

            //задание3
            Thread task = new Thread(new ParameterizedThreadStart(Count));
            Console.Write("Введите количество значений: "); int n = int.Parse(Console.ReadLine());
            task.Start(n);
            Thread.Sleep(2000);
            Console.WriteLine("\nThread sleep");
            task.Suspend();
            Console.WriteLine("Name: " + task.Name);
            Console.WriteLine("Priority: " + task.Priority);
            Console.WriteLine("Thread: " + task.ThreadState);
            Console.WriteLine("Thread resume\n");
            Thread.Sleep(1000);
            task.Resume();          

            //задание4
            Thread.Sleep(5000);
            Thread firstThread = new Thread(new ParameterizedThreadStart(Odd));
            firstThread.Name = "First thread";
            Thread secondThread = new Thread(new ParameterizedThreadStart(Even));
            secondThread.Name = "Second thread";
            firstThread.Start(n);
            Thread.Sleep(500);
            secondThread.Start(n);
            secondThread.Priority = ThreadPriority.Highest;
            Thread.Sleep(10000);

            Console.WriteLine("\nСначало четные - Потом нечетные");
            Thread thirdThread = new Thread(new ParameterizedThreadStart(Odd2));
            thirdThread.Name = "First thread";
            Thread fourthThread = new Thread(new ParameterizedThreadStart(Even2));
            fourthThread.Name = "Second thread";
            fourthThread.Start(n);
            thirdThread.Start(n);

            //задание5            
            TimerCallback callback = new TimerCallback(TimerFunc);
            Timer timer = new Timer(callback, null, 0, 1600);
        }

        private static void SecondaryDomain_DomainUnload(object sender, EventArgs e)
        {
            Console.WriteLine("Домен выгружен из процесса");
        }

        private static void Domain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Сборка загружена");
        }

        private const string Path = @"E:\Threads.txt";

        public static void Count(object n)
        {

            for (var i = 1; i <= (int)n; i++)
            {
                Console.WriteLine("Thread:");
                Console.WriteLine(i);
                Thread.Sleep(400);

                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(i);
                }
            }

        }

        public static void Even(object n)
        {
            x = 2;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                }
                Thread.Sleep(1000);
            }
        }

        public static void Odd(object n)
        {
            x = 1;
            for (int i = x; i <= (int)n; i += 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                x++;
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                }
                Thread.Sleep(1000);
            }
        }

        public static int x;
        static Mutex mut = new Mutex();
        public static void Even2(object n)
        {
            mut.WaitOne();
            x = 2;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                }
                Thread.Sleep(1000);
            }
            mut.ReleaseMutex();
        }

        public static void Odd2(object n)
        {
            mut.WaitOne();
            x = 1;
            for (int i = x; i <= (int)n; i = i + 2)
            {
                Thread.Sleep(500);
                Console.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                x++;
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine(Thread.CurrentThread.Name + " --- x = " + i);
                }
                Thread.Sleep(1000);
            }
            mut.ReleaseMutex();
        }

        private static void TimerFunc(object c)
        {
            Console.WriteLine("It's Timer");
        }
    }
}
