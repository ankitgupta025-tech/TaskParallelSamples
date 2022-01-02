using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.AsyncProg
{
    internal class ResetEventsDemo
    {
        public static void Demo()
        {
            //Manual();
            Automatic();
        }

        public static void Manual()
        {
            var evt = new ManualResetEventSlim();

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Boiling water...");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Boiling takes time....");
                    Thread.Sleep(new Random().Next(100));
                }
                Console.WriteLine("Water is ready.");
                evt.Set();
            });

            var makeTea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Waiting for water...");
                evt.Wait();
                Console.WriteLine("Here is your tea!");
                Console.WriteLine($"Is the event set? {evt.IsSet}");
                evt.Wait();
                evt.Wait();

                evt.Reset();
                evt.Wait(500); // already set!  // multiple waits are ok
                Console.WriteLine("That was a nice cup of tea!");
            });

            makeTea.Wait();
        }

        private static void Automatic()
        {
            // try switching between manual and auto :)
            var evt = new AutoResetEvent(false);

            evt.Set(); // ok, it's set

            evt.WaitOne(); // this is ok but, in auto, it causes a reset. multiple wait is blocking

            if (evt.WaitOne(1000))
            {
                Console.WriteLine("Succeeded");
            }
            else
            {
                Console.WriteLine("Timed out");
            }
        }
    }
}