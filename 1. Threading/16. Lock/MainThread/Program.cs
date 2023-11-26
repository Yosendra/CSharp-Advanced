// Two threads can share same resource (we call this shared resource)
// When two or more threads try to access same resource, it can lead to synchronization issue
// We need synchronization. Without it, it can lead to various issue like inconsistent data or unexpected behavior in the program.
// Instance of issue caused by synchronization issue : Race Condition, Data Inconsistency, Deadlock, Starvation

// Thread Synchronization is a the process of coordinating the execution of multiple threads to ensure
// that they do not interfere with each other while accessing shared resources.

// Thread Synchronization Mechanism
// 1. Monitor
// 2. Lock
// 3. Mutex
// 4. Semaphores

// Lock
// It just syntactic sugar of monitor mechanism. A shortcut syntax to use Monitor.Enter() and Monitor.Exit()

class Shared
{
    public static int SharedResource { get; set; }
    // This is dummy object for lock object in Monitor mechanism. Optionally it can be readonly
    public static readonly object lockObject = new object();
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
                
                // Here we use lock statement replacing the Monitor.Enter() and Monitor.Exit() syntax
                lock (Shared.lockObject)
                {
                    Console.WriteLine("Shred Resource in Count Up: " + Shared.SharedResource);
                    Shared.SharedResource++;
                }

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
            lock (Shared.lockObject)
            {
                Console.WriteLine("Shred Resource in Count Down: " + Shared.SharedResource);
                Shared.SharedResource--;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"j = {j} ");
            Thread.Sleep(100);
        }

        Thread.Sleep(1000);
        Console.WriteLine("Count Down is completed");
    }
}