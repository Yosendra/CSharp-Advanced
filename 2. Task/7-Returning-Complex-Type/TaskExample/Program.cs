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
    public SumData CountDown(int count)
    {
        long sum = 0;

        Console.WriteLine("\nCount-Down starts");
        for (int j = count; j >= 1; j--)
        {
            Console.WriteLine($"j = {j} ");
            sum += j;
        }
        Console.WriteLine("\nCount-Down ends");

        // Here we return SumData object
        return new SumData { Sum = sum, };
    }
}

class Program
{
    public static void Main()
    {
        UpCounter upCounter = new();
        DownCounter downCounter = new();

        // Here we use Task<long> because we are returning long value in delegate we are passing
        Task<long> task1 = Task.Run(() => 
        {
            // Here we are trying to return a value from Task
            return upCounter.CountUp(20);
        });

        // So here we use Task<SumData> because downcounter.CountDown() return SumData object
        Task<SumData> task2 = Task.Run(() => 
        {
            return downCounter.CountDown(25);
        });

        // We can use Task.WaitAll() instead of Task.Wait()
        //task1.Wait();
        //task2.Wait();
        Task.WaitAll(task1, task2);

        // Here, after wait the tasks, we ask the result of each task
        Console.WriteLine($"Result of Count-Up: {task1.Result}");

        // Because the result of task2 is SumData object, we must be more specific about the result we want to access.
        // In this case we want the sum property to be displayed
        Console.WriteLine($"Result of Count-Down: {task2.Result.Sum}");

        Console.ReadKey();
    }
}

// Simulate complex type which used by Task Generic
class SumData
{
    public long Sum { get; set; }
}