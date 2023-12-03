class Program
{
    static void Main()
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        
        Console.WriteLine(mainThread.Name);

        var numberCounter = new NumberCounter();
        numberCounter.CountUp();
        numberCounter.CountDown();

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