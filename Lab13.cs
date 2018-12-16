using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Lab13
{
    class SAALog
    {
        static string path = "log.txt";
        static public void WriteLog(string text, bool bl = true)
        {
            StreamWriter sw = new StreamWriter(path, bl);
            sw.WriteLine(DateTime.Now + " : " + text);
            sw.Close();
        }

        static public void Read()
        {
            StreamReader sr = new StreamReader(path);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }

        static public string Find(string date)
        {
            string str = " ";

            foreach (string s in File.ReadLines(path))
            {
                if (s.Contains(date))
                {
                    str += s + "\n";
                }
            }
            return str;
        }

        static public void Long()
        {
            int i = 0;
            foreach (string s in File.ReadLines(path))
            {
                i++;
            }
            Console.WriteLine("В файле " + i + " log");
        }

        static public void Log()
        {
            string date = DateTime.Now.ToString("dd.MM.yyy") + " " + DateTime.Now.Hour;
            Console.WriteLine("\n" + date);
            string log = Find(date);
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(log);
            sw.Close();
        }
    }

    class SAADiskInfo
    {
        static public void DiskInfo()
        {
            Console.WriteLine("Информация о диске");
            foreach (DriveInfo disk in DriveInfo.GetDrives())
            {
                if (disk.Name == "E:\\")
                {                    
                    Console.WriteLine("Метка тома: {0}", disk.RootDirectory);
                    Console.WriteLine("Имя диска: {0}", disk.Name);
                    Console.WriteLine("Обьём: {0}", disk.TotalSize);
                    Console.WriteLine("Доступный Обьём: {0}", disk.AvailableFreeSpace);
                    Console.WriteLine("Свободно места: {0}", disk.TotalFreeSpace);
                    Console.WriteLine("Файловая система: {0}", disk.DriveFormat);
                    Console.WriteLine("Свободно места: {0}", disk.TotalFreeSpace);
                    Console.WriteLine();
                }
            }
            SAALog.WriteLog("DiskInfo");
        }
    }

    class SAAFileInfo
    {
        static public void FileInfo()
        {
            string path = "E:\\file.txt";
            FileInfo file = new FileInfo(path);

            if (file.Exists)
            {
                Console.WriteLine("Имя файла: " + file.Name);
                Console.WriteLine("Время создания: " + file.CreationTime);
                Console.WriteLine("Расширение: " + file.Extension);
                Console.WriteLine("Размер: " + file.Length);
                Console.WriteLine("Полный путь: " + Path.GetFullPath(path));
            }
            Console.WriteLine();
            SAALog.WriteLog("FileInfo");
        }

    }

    class SAADirInfo
    {
        static string path = "E:\\Steam\\steamapps";
        static DirectoryInfo dirInfo = new DirectoryInfo(path);
        static public void DirInfo()
        {
            Console.WriteLine("Количество файлов в папке : " + dirInfo.GetFiles().Length);
            Console.WriteLine("Время создания : " + dirInfo.CreationTime);
            Console.WriteLine("Количество подпапок : " + dirInfo.GetDirectories().Length);
            Console.WriteLine("Родительская папка : " + dirInfo.Parent);
            Console.WriteLine();
            SAALog.WriteLog("DirInfo");
        }
    }

    class SAACompressed
    {
        static public void Manager3()
        {
            string sourceFile = "E://SAAInspect//SAAFiles/file1.txt"; // исходный файл
            string compressedFile = "E://SAAInspect//SAAFiles/File.gz"; // сжатый файл
            string targetFile = "E://SAAInspect/new_file1.txt"; // восстановленный файл

            // создание сжатого файла
            Compress(sourceFile, compressedFile);
            // чтение из сжатого файла
            Decompress(compressedFile, targetFile);
            SAALog.WriteLog("Manager3");
        }
        public static void Compress(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено.", sourceFile);
                    }
                }
            }
        }
        public static void Decompress(string compressedFile, string targetFile)
        {
            // поток для чтения из сжатого файла
            using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
            {
                // поток для записи восстановленного файла
                using (FileStream targetStream = File.Create(targetFile))
                {
                    // поток разархивации
                    using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(targetStream);
                        Console.WriteLine("Восстановлен файл: {0}", targetFile);
                    }
                }
            }
        }
    }

    class SAAFileManager
    {
        static public void Manager(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path + "SAAInspect");
            DirectoryInfo dir2 = new DirectoryInfo(path);
            dir.Create();
            StreamWriter sw = new StreamWriter(path + "/SAAInspect/SAAdirinfo.txt");
            sw.WriteLine("Количество папок: " + dir2.GetDirectories().Length);
            sw.WriteLine("Количество файлов: " + dir2.GetFiles().Length);
            sw.Close();
            FileInfo file = new FileInfo(path + "/SAAInspect/SAAdirinfo.txt");
            file.CopyTo(path + "/SAAInspect/SAAseconddirinfo.txt", true);
            file.Delete();

            Console.WriteLine("Операция завершена");
            SAALog.WriteLog("Manager");
        }

        static public void Manager2(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path + "SAAFiles");
            dir.Create();
            DirectoryInfo dir2 = new DirectoryInfo("E:\\Files");
            foreach (FileInfo fl in dir2.GetFiles())
            {
                if (fl.Extension == ".txt")
                {
                    fl.CopyTo(path + "SAAFiles\\" + fl.Name);
                }
            }
            dir.MoveTo("E:\\SAAInspect\\SAAFiles");
            Console.WriteLine("Операция завершена");
            SAALog.WriteLog("Manager2");
        }        
    }

    class Program
    {
        static void Main(string[] args)
        {
            // SAADiskInfo.DiskInfo();
            //SAAFileInfo.FileInfo();
            // SAADirInfo.DirInfo();
            // SAAFileManager.Manager("E:\\");
            //   SAAFileManager.Manager2("E:\\");
            SAACompressed.Manager3();
          //  SAALog.Read();
          //  Console.WriteLine("\n");
          //  Console.WriteLine(SAALog.Find("DiskInfo"));
          //  SAALog.Long();
          //  SAALog.Log();
          //  SAALog.Long();
        }
    }
}
