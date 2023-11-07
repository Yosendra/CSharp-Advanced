// Two threads can share same resource (we call this shared resource)
// When two or more threads try to access same resource, it can lead to synchronization issue
// We need synchronization. Without it, it can lead to various issue like inconsistent data or unexpected behavior in the program.
// Instance of issue caused by synchronization issue : Race Condition, Data Inconsistency, Deadlock, Starvation

// Simulate the shared data
class Shared
{
    // static because the exact same resource should be accessible in both threads.
    public static int SharedResource { get; set; }
}

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
        Action<int> callback = sum =>
        {
            Console.WriteLine($"Return value from Count-Up thread is: {sum}");
        };

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

        // Expected value is 0. If not, that means some issue in synchronization 
        Console.WriteLine("Shared Resource : "+ Shared.SharedResource);
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
                Console.WriteLine("Shred Resource in Count Up: "+ Shared.SharedResource);
                // Count looping through SharedResource
                Shared.SharedResource++;

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
            // Expecting 1
            Console.WriteLine("Shred Resource in Count Down: " + Shared.SharedResource);
            // In the second thread, it alse use the shared resource for counting
            Shared.SharedResource--;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"j = {j} ");
            Thread.Sleep(100);
        }

        Thread.Sleep(1000);
        Console.WriteLine("Count Down is completed");
    }
}