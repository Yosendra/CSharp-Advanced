using System.Diagnostics;

class UpCounter
{
    public void CountUp(int count)
    {
        Console.WriteLine("\nCount-Up starts");
        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"i = {i} ");
        }
        Console.WriteLine("\nCount-Up ends");
    }
}

class DownCounter
{
    public void CountDown(int count)
    {
        Console.WriteLine("\nCount-Down starts");
        for (int j = count; j >= 1; j--)
        {
            Console.WriteLine($"j = {j} ");
        }
        Console.WriteLine("\nCount-Down ends");
    }
}

class Program
{
    public static void Main()
    {
        // Create Stopwatch object
        Stopwatch sw = new();

        // With Task
        sw.Start();
        WithTask();
        sw.Stop();

        long timeTakenForTask = sw.ElapsedMilliseconds;
        Console.WriteLine($"Task-time taken: {timeTakenForTask} ms");

        // With Thread
        sw.Restart();   // To begin from zero, not resume from last
        WithThread();
        sw.Stop();

        long timeTakenForThread = sw.ElapsedMilliseconds;
        Console.WriteLine($"Thread-time taken: {timeTakenForThread} ms");

        if (timeTakenForTask <= timeTakenForThread)
        {
            Console.WriteLine("\nTask is faster than Thread for now");
        }
        else
        {
            Console.WriteLine("\nThread is faster than Task for now");
        }

        Console.ReadKey();
    }

    private static void WithTask()
    {
        UpCounter upCounter = new();
        DownCounter downCounter = new();
        CountdownEvent countdownEvent = new(2);

        Task task1 = Task.Run(() => {
            upCounter.CountUp(20);
            countdownEvent.Signal();
        });

        Task task2 = Task.Run(() => {
            downCounter.CountDown(20);
            countdownEvent.Signal();
        });

        // Here we wait
        countdownEvent.Wait();
    }

    private static void WithThread()
    {
        UpCounter upCounter = new();
        DownCounter downCounter = new();
        CountdownEvent countdownEvent = new(2);

        Thread thread1 = new(() => {
            upCounter.CountUp(20);
            countdownEvent.Signal();
        });

        Thread thread2 = new(() => {
            downCounter.CountDown(20);
            countdownEvent.Signal();
        });

        thread1.Start();
        thread2.Start();

        // Here we wait
        countdownEvent.Wait();
    }
}