class Program
{
    static void Main()
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        Console.WriteLine(mainThread.Name + "is started");

        // Initiallize object of class NumberUpCounter class, then initialize its properties
        NumberUpCounter numberUpCounter = new()
        {
            Count = 100,
        };
        NumberDownCounter numberDownCounter = new()
        {
            Count = 100,
        };

        // Thread One
        ThreadStart threadStart1 = numberUpCounter.CountUp;
        Thread thread1 = new(threadStart1)
        {
            Name = "Count Up Thread",
            Priority = ThreadPriority.Highest,
        };
        thread1.Start();
        Console.WriteLine($"{thread1.Name} {thread1.ManagedThreadId} is {thread1.ThreadState}");


        // Thread Two        
        ThreadStart threadStart2 = numberDownCounter.CountDown;
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

// Encapsulate CountUp method to a class
class NumberUpCounter
{
    public int Count { get; set; }

    public void CountUp()
    {
        try
        {
            Console.WriteLine("Count Up is started");
            Thread.Sleep(1000);

            for (int i = 1; i <= Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"i = {i} ");
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
}

// Encapsulate CountUp method to a class
class NumberDownCounter
{
    public int Count { get; set; }

    public void CountDown()
    {
        Console.WriteLine("Count Down is started");
        Thread.Sleep(100);

        for (int? j = Count; j >= 1; j--)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"j = {j} ");
            Thread.Sleep(100);
        }

        Thread.Sleep(1000);
        Console.WriteLine("Count Down is completed");
    }
}