using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FactorialAsync.Tasks
{
    class Program
    {
        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Thread.Sleep(800);
            return result;
        }
        // определение асинхронного метода
        static async Task<int> FactorialAsync(int n)
        {
            return await Task.Run(() => Factorial(n));
        }
        static async Task Main1()
        {
            int n1 = await FactorialAsync(5);
            int n2 = await FactorialAsync(6);
            Console.WriteLine($"n1={n1}  n2={n2}");
            Console.WriteLine("123");
            Console.Read();
        }
        static void Main(string[] args)
        {
            var tasks = new List<Task>
            {
                Main1()
            };


            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("123");
            Console.Read();
        }
    }
}