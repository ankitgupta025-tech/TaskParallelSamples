using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.AsyncProg
{
    internal static class Collections
    {
        private static ConcurrentDictionary<string, string> _dictionary = new ConcurrentDictionary<string, string>();
        private static ConcurrentQueue<int> _queue = new ConcurrentQueue<int>();
        private static ConcurrentStack<int> _stack = new ConcurrentStack<int>();
        private static ConcurrentBag<int> _bag = new ConcurrentBag<int>();
        private static BlockingCollection<int> _blockingCollection = new BlockingCollection<int>(_bag, 10);

        public static void Entry()
        {
            //AddDict();

            //AddBag();

            ManageBlockingCollection();
        }

        private static void AddDict()
        {
            _dictionary.TryAdd("1", "Mango");
            _dictionary["2"] = "Apple";

            _dictionary.AddOrUpdate("2", "Apple", (key, old) =>
            {
                return "old --> " + "Apple";
            });

            Console.WriteLine("The id 2 at is " + _dictionary["2"]);
        }

        private static void AddBag()
        {
            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var j = i;
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    _bag.Add(j);
                    Console.WriteLine($"{Task.CurrentId} has added {j}");

                    if (_bag.TryPeek(out int result))
                    {
                        Console.WriteLine($"{Task.CurrentId} has peeked {result}");
                    }
                }));
            }

            Task.WhenAll(tasks).Wait();

            for (int i = 0; i < 10; i++)
            {
                if (_bag.TryTake(out int res))
                {
                    Console.WriteLine($"Loop: {i} -- {Task.CurrentId} has peeked {res}");
                }
            }
        }

        private static void RunProducer()
        {
            int i = 0;
            while (true)
            {
                var x = i + 1;
                _blockingCollection.Add(x);
                Console.WriteLine($"+++ {x} added.");
                Thread.Sleep(new Random().Next(500));
                i = x;
            }
        }

        private static void RunConumer()
        {
            foreach (var item in _blockingCollection.GetConsumingEnumerable())
            {
                Console.WriteLine($"--- {item} processed.");
                Thread.Sleep(new Random().Next(5000));
            }
        }

        private static void ManageBlockingCollection()
        {
            var p = Task.Factory.StartNew(RunProducer);
            var c = Task.Factory.StartNew(RunConumer);
            Task.Factory.StartNew(RunProducer);
            //var c = Task.Factory.StartNew(RunConumer);

            Task.WaitAll(p, c);
        }
    }
}