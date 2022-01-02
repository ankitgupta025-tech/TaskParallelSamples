using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.AsyncProg
{
    public class AsyncProg
    {
        public void WriteNum(string s)
        {
            while (true)
            {
                Console.Write(s);
            }
        }

        private string GetString()
        {
            return "";
        }

        private Task<string> GetStringAsync()
        {
            return Task.FromResult("");
        }

        public void Write()
        {
            string s = "--";

            //2 ways to start a task
            //a
            Task task = new Task(() => WriteNum(s));
            task.Start();
        }

        private void Fair()
        {
            //b
            var task1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task 1 started");
                Thread.Sleep(5000);
                Console.WriteLine("Task 1 end");

                Task task = new Task(() => WriteNum(""));
            }, TaskCreationOptions.PreferFairness);

            task1.Start();

            var task2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task 2 started");
                Thread.Sleep(3000);
                Console.WriteLine("Task 2 end");
            }, TaskCreationOptions.PreferFairness);

            task2.Start();

            Task.WhenAll(task1, task2);
        }
    }
}