using System;
using System.Threading;
using FirstTask;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskQueue = new TaskQueue(21);
            var mutex = new Mutex();

            for (int i = 0; i < 21; i++)
            {
                int j = i;
                taskQueue.EnqueueTask(delegate
                {
                    mutex.Lock();
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("proc id = " + Thread.CurrentThread.ManagedThreadId + " task = " + i);
                    }
                    mutex.Unlock();
                });
            }

            taskQueue.Finish();
        }
    }
}