class Program
{
    static void Main()
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        Console.WriteLine(mainThread.Name);

        var numberCounter = new NumberCounter();

        // Thread One
        ThreadStart threadStart1 = new ThreadStart(numberCounter.CountUp);
        Thread thread1 = new Thread(threadStart1);
        thread1.Name = "Count Up Thread";
        Console.WriteLine($"{thread1.Name} is {thread1.ThreadState}");
        thread1.Start();
        Console.WriteLine($"{thread1.Name} is {thread1.ThreadState}");

        // Thread Two
        ThreadStart threadStart2 = new ThreadStart(numberCounter.CountDown);
        Thread thread2 = new Thread(threadStart2);
        thread2.Name = "Count Down Thread";
        Console.WriteLine($"{thread2.Name} is {thread2.ThreadState}"); // Unstarted
        thread2.Start();
        Console.WriteLine($"{thread2.Name} is {thread2.ThreadState}"); // Unstarted

        Console.WriteLine(mainThread.Name + " completed");
        Console.ReadKey();
    }
}

class NumberCounter
{
    public void CountUp()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"i = {i}, ");
            Thread.Sleep(1000); // 1000 miliseconds = 1 second
        }
    }

    public void CountDown()
    {
        for (int j = 100; j >= 1; j--)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"j = {j}, ");
            Thread.Sleep(1000); // 1000 miliseconds = 1 second
        }
    }
}