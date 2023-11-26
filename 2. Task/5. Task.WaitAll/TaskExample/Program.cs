using System.Diagnostics;

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
        UpCounter upCounter = new();
        DownCounter downCounter = new();

        Task task1 = Task.Run(() => {
            upCounter.CountUp(20);
        });

        Task task2 = Task.Run(() => {
            downCounter.CountDown(20);
        });

        // We can use Task.WaitAll() instead of Task.Wait()
        //task1.Wait();
        //task2.Wait();

        Task.WaitAll(task1, task2);
        
        Console.ReadKey();
    }
}