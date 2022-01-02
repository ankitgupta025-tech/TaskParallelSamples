using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.AsyncProg
{
    internal class CountDownEventDemo
    {
        private static int taskCount = 5;
        private static CountdownEvent cte = new CountdownEvent(taskCount);
        private static Random random = new Random();

        public static void Demo()
        {
            var tasks = new Task[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}.");
                    Thread.Sleep(random.Next(3000));
                    cte.Signal(); // also takes a signalcount
                                  //cte.CurrentCount/InitialCount
                    Console.WriteLine($"Exiting task {Task.CurrentId}.");
                });
            }

            var finalTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Waiting for other tasks in task {Task.CurrentId}");
                cte.Wait();
                Console.WriteLine("All tasks completed.");
            });

            finalTask.Wait();
        }
    }
}