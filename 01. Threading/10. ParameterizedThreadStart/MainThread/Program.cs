class Program
{
    static void Main()
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        Console.WriteLine(mainThread.Name + "is started");

        var numberCounter = new NumberCounter();

        // Thread One
        // ParameterizedThreadStart delegate accept only 1 parameter type object in delegate
        ParameterizedThreadStart threadStart1 = numberCounter.CountUp;
        Thread thread1 = new(threadStart1)
        {
            Name = "Count Up Thread",
            Priority = ThreadPriority.Highest,
        };
        // Here we pass the parameter needed by delegate, when invoking the thread
        MaxCount maxCount = new()
        {
            Count = 100,
        };
        // If you want to pass more than one parameter, passing custom class is the better approach
        thread1.Start(maxCount);
        Console.WriteLine($"{thread1.Name} {thread1.ManagedThreadId} is {thread1.ThreadState}");

        // Thread Two
        ParameterizedThreadStart threadStart2 = numberCounter.CountDown;
        Thread thread2 = new(threadStart2)
        {
            Name = "Count Down Thread",
            Priority = ThreadPriority.BelowNormal,
        };
        thread2.Start(maxCount);
        Console.WriteLine($"{thread2.Name} {thread2.ManagedThreadId} is {thread2.ThreadState}");

        // Join
        thread1.Join();
        thread2.Join();

        Console.WriteLine(mainThread.Name + " completed");
        Console.ReadKey();
    }
}

class MaxCount
{
    public int Count { get; set; }
}

class NumberCounter
{
    public void CountUp(object? count)
    {
        try
        {
            Console.WriteLine("Count Up is started");
            Thread.Sleep(1000);

            // Needs to be casted explicitly from object type to int
            //var countInt = (int?)count;

            var maxCount = (MaxCount?)count;
            if (maxCount is null) return;

            for (int i = 1; i <= maxCount.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"i = {i}, ");
                // ThreadInterruptedException thrown from here because the thread already halted by Interrupt() method
                Thread.Sleep(100);
            }

            Thread.Sleep(1000);
            Console.WriteLine("Count Up is completed");
        }
        catch (ThreadInterruptedException)
        {
            Console.WriteLine("Count-Up Thread interrupted");
        }
    }

    public void CountDown(object? count)
    {
        Console.WriteLine("Count Down is started");
        Thread.Sleep(100);

        var maxCount = (MaxCount?)count;
        if (maxCount is null) return;

        for (int? j = maxCount.Count; j >= 1; j--)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"j = {j}, ");
            Thread.Sleep(100); // 1000 miliseconds = 1 second
        }

        Thread.Sleep(1000);
        Console.WriteLine("Count Down is completed");
    }
}