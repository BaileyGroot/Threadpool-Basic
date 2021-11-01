using System;
using System.Threading;
using System.Diagnostics;
namespace ThreadPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {
                    ThreadPool.QueueUserWorkItem(Process);
                }
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 100000; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        // ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1)
        // You don't need "new WaitCallback" but it is there because you might encounter it in the future.
        // Queues a method for execution, and specifies an object containing data to be used by the method. The method executes when a thread pool thread becomes available.
        static void Process(object callback)
        {
        }
    }
}