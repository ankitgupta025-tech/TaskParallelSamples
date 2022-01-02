using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.AsyncProg
{
    /// <summary>
    /// Atomic operation: cannot be interupted.
    /// eg x = 1, reference assignment ie assign value to a reference type. It cannot be interrupted.
    /// read and writes to value types
    /// </summary>

    internal static class DataSharingAndSync
    {
        public static void Entry()
        {
            var tasks = new List<Task>();
            var bank = new Bank();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bank.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bank.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Final balance: " + bank.Balance);
        }
    }

    internal class Bank
    {
        private object _locker = new object();
        public int Balance { get; private set; }

        /// <summary>
        ///  op1 temp <- get_balance + amount
        ///  op2 set_bal
        /// </summary>
        /// <param name="amount"></param>
        public void Deposit(int amount)
        {
            lock (_locker)
            {
                Balance += amount;
            }
        }

        public void Withdraw(int amount)
        {
            lock (_locker)
            {
                Balance -= amount;
            }
        }

        #region options

        // lock
        // Interlocked.Increment
        // spinlock

        #endregion options
    }
}