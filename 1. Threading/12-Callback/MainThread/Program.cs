// Callback
// Callback is a method to be executed by a thread after completion of thread execution.
// Generally, the callback method is defined by the thread invoker (in this code it is Main thread a.k.a Main method)

class Program
{
    static void Main()
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        Console.WriteLine(mainThread.Name + "is started");

        NumberUpCounter numberUpCounter = new()
        {
            Count = 100,
        };
        NumberDownCounter numberDownCounter = new()
        {
            Count = 100,
        };

        // Thread One
        // Create Callback method
        Action<int> callback = sum =>
        {
            Console.WriteLine($"Return value from Count-Up thread is: {sum}");
        };

        // Here we pass the callback as an argument to CountUp method
        ThreadStart threadStart1 = () => 
        {
            numberUpCounter.CountUp(callback);
        };
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

    public void CountUp(Action<int> callback)
    {
        int sum = 0;

        try
        {
            Console.WriteLine("Count Up is started");
            Thread.Sleep(1000);

            for (int i = 1; i <= Count; i++)
            {
                sum += i;
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
        finally
        {
            // invoke callback in thread method
            callback(sum);
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