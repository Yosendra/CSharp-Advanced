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
        // Create object for both counter classes
        UpCounter upCounter = new();
        DownCounter downCounter = new();

        // Instead of creating two threads, now we are creating two tasks
        // Create and start task

        // This is not the recommended way to create task object by new keyword
        // You have too many things to configure manually yourself
        // Task task = new Task();

        Task task1 = Task.Run(() => {
            upCounter.CountUp(20);
        });

        Task task2 = Task.Run(() => {
            downCounter.CountDown(20);
        });

        // So you don't need to call start method or anything to start the task

        Console.ReadKey();
    }
}