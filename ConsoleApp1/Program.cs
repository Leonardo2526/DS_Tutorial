using System;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        public static string DS_LogOutputPath { get; set; } = @"C:\Users\dnknt\OneDrive\Рабочий стол\Новая папка\Log.txt";

        static void Main(string[] args)
        {
            try
            {
                FirstMethod();
                //SecondMethod();
                //ThirdMethod();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            };
            Console.WriteLine("Complete!");
            Console.ReadLine();
        }

        static void FirstMethod()
        //This is the first method for writing
        {
            using StreamWriter writer = File.AppendText(DS_LogOutputPath);
            writer.WriteLine("Log message1");
        }

        static void SecondMethod()
        //This is the second method for writing
                {
            using var stream = new FileStream(DS_LogOutputPath, FileMode.Create, FileAccess.Write, FileShare.Write, 4096);
            var bytes = Encoding.UTF8.GetBytes("Log message2");
            stream.Write(bytes, 0, bytes.Length);
        }

        static void ThirdMethod()
        //This is the third method for writing
        {
            var logFile = File.Create(DS_LogOutputPath);
            var logWriter = new StreamWriter(logFile);
            logWriter.WriteLine("Log message3");
            logWriter.Dispose();
        }
    }
}
