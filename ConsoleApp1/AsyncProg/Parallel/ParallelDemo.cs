using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.AsyncProg.Par
{
    internal class ParallelDemo
    {
        public static void Demoo()
        {
            //Invoke();

            //ForLoop();

            ForEach();
        }

        private static void ForEach()
        {
            string[] letters = { "oh", "what", "a", "night" };
            var po = new ParallelOptions();
            po.MaxDegreeOfParallelism = 2;
            Parallel.ForEach(letters, po, letter =>
            {
                Console.WriteLine($"{letter} has length {letter.Length} (task {Task.CurrentId})");
            });
        }

        private static void ForLoop()
        {
            Parallel.For(1, 11, x =>
            {
                Console.Write($"{x * x}\t");
            });
            Console.WriteLine();
        }

        private static void Invoke()
        {
            var a = new Action(() => Console.WriteLine($"First {Task.CurrentId}"));
            var b = new Action(() => Console.WriteLine($"Second {Task.CurrentId}"));
            var c = new Action(() => Console.WriteLine($"Third {Task.CurrentId}"));

            Parallel.Invoke(a, b, c);
            // these are blocking operations; wait on all tasks
        }
    }
}