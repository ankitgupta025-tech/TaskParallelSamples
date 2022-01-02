using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.AsyncProg
{
    public class ExceptionHandle
    {
        public static void Enter()
        {
            Console.WriteLine($"ExceptionHandle start.!!");

            var task1 = new Task(InvalidOp);
            var task2 = new Task(AccessDenied);
            var task3 = new Task(() =>
            {
                Console.WriteLine($"task1 status.!!{task1.Status}");
                Console.WriteLine($"task2 status.!!{task2.Status}");
                Console.WriteLine($"Wait for 5 sec.!!");
                Thread.Sleep(5000);
                Console.WriteLine($"task1 status.!!{task1.Status}");
                Console.WriteLine($"task2 status.!!{task2.Status}");
            });

            task1.Start();
            task2.Start();
            task3.Start();

            var error = Task.WhenAll(task3, task2, task1);
            Console.WriteLine($"InvalidOp.!!{error.Exception}");
        }

        private static void InvalidOp()
        {
            Console.WriteLine($"InvalidOp.!!");
            throw new InvalidOperationException("this is invalid");
        }

        private static void AccessDenied()
        {
            Console.WriteLine($"AccessDenied.!!");
            throw new AccessViolationException("access denied");
        }
    }
}