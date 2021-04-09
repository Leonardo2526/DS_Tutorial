using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace HelloApp
{
    class Program
    {
        static async void ReadWriteAsync()
        {
            string s = "Hello world! One step at a time";

            // hello.txt - файл, который будет записываться и считываться
            using (StreamWriter writer = new StreamWriter(@"C:\Users\d.saraev.GCM\Desktop\hello.txt", false))
            {
                await writer.WriteLineAsync(s);  // асинхронная запись в файл
            }
            using (StreamReader reader = new StreamReader(@"C:\Users\d.saraev.GCM\Desktop\hello.txt"))
            {
                string result = await reader.ReadToEndAsync();  // асинхронное чтение из файла
                Console.WriteLine(result);
            }
        }
        static void Main(string[] args)
        {
            ReadWriteAsync();

            Console.WriteLine("Некоторая работа");
            Console.Read();
        }
    }
}