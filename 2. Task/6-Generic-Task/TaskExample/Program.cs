class UpCounter
{
    public long CountUp(int count)
    {
        long sum = 0;

        Console.WriteLine("\nCount-Up starts");
        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"i = {i} ");
            sum += i;
        }
        Console.WriteLine("\nCount-Up ends");

        return sum;
    }
}

class DownCounter
{
    public long CountDown(int count)
    {
        long sum = 0;

        Console.WriteLine("\nCount-Down starts");
        for (int j = count; j >= 1; j--)
        {
            Console.WriteLine($"j = {j} ");
            sum += j;
        }
        Console.WriteLine("\nCount-Down ends");

        return sum;
    }
}

class Program
{
    public static void Main()
    {
        UpCounter upCounter = new();
        DownCounter downCounter = new();

        // Here we use Task<int> because we are returning int value in delegate we are passing
        Task<long> task1 = Task.Run(() => 
        {
            // Here we are trying to return a value from Task
            return upCounter.CountUp(20);
        });

        Task<long> task2 = Task.Run(() => 
        {
            return downCounter.CountDown(25);
        });

        // We can use Task.WaitAll() instead of Task.Wait()
        //task1.Wait();
        //task2.Wait();

        Task.WaitAll(task1, task2);

        // Here, after wait the tasks, we ask the result of each task
        Console.WriteLine($"Result of Count-Up: {task1.Result}");
        Console.WriteLine($"Result of Count-Down: {task2.Result}");

        Console.ReadKey();
    }
}