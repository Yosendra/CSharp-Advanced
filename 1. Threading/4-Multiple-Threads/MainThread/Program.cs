class Program
{
    static void Main()
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        Console.WriteLine(mainThread.Name);

        var numberCounter = new NumberCounter();

        // Define delegate for thread one
        ThreadStart threadStart1 = new ThreadStart(numberCounter.CountUp);
        // Create object thread one and pass the delegate 
        Thread thread1 = new Thread(threadStart1);
        // Give name to thread one
        thread1.Name = "Count Up Thread";
        // Check ThreadState for Thread One before start
        Console.WriteLine($"{thread1.Name} is {thread1.ThreadState}"); // Unstarted
        // Execute the method that we have passed using delegate
        thread1.Start();
        // Check ThreadState for Thread One after start
        Console.WriteLine($"{thread1.Name} is {thread1.ThreadState}"); // Running


        // Same code for Thread Two
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
        }
    }

    public void CountDown()
    {
        for (int j = 100; j >= 1; j--)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"j = {j}, ");
        }
    }
}