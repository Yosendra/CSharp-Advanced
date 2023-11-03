class Program
{
    static void Main()
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        Console.WriteLine(mainThread.Name + "is started");

        var numberCounter = new NumberCounter();

        // Thread One
        ThreadStart threadStart1 = numberCounter.CountUp;
        Thread thread1 = new(threadStart1)
        {
            Name = "Count Up Thread",
            // Give thread a priority value througn built-in enum
            Priority = ThreadPriority.Highest,
        };
        thread1.Start();
        Console.WriteLine($"{thread1.Name} {thread1.ManagedThreadId} is {thread1.ThreadState}");

        // Thread Two
        ThreadStart threadStart2 = numberCounter.CountDown;
        Thread thread2 = new(threadStart2)
        {
            Name = "Count Down Thread",
            Priority = ThreadPriority.BelowNormal,
        };
        thread2.Start();
        Console.WriteLine($"{thread2.Name} {thread2.ManagedThreadId} is {thread2.ThreadState}");

        // Join
        thread1.Join();
        thread2.Join();

        Console.WriteLine(mainThread.Name + " completed");
        Console.ReadKey();
    }
}

class NumberCounter
{
    public void CountUp()
    {
        Console.WriteLine("Count Up is started");
        Thread.Sleep(1000);

        for (int i = 1; i <= 100; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"i = {i}, ");
            Thread.Sleep(100);
        }

        Thread.Sleep(1000);
        Console.WriteLine("Count Up is completed");
    }

    public void CountDown()
    {
        Console.WriteLine("Count Down is started");
        Thread.Sleep(100);

        for (int j = 100; j >= 1; j--)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"j = {j}, ");
            Thread.Sleep(100); // 1000 miliseconds = 1 second
        }

        Thread.Sleep(1000);
        Console.WriteLine("Count Down is completed");
    }
}