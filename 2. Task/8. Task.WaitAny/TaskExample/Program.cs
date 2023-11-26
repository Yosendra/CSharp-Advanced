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

        // Here we use Task.WaitAny instead of Task.WaitAll
        // Either one of these tasks is complete, then continue the execution
        // It return the index of array task of Task.WaitAny() argument
        // If task1 is completed first, then it returns index 0
        int completedTaskIndex = Task.WaitAny(task1, task2);

        if (completedTaskIndex == 0)
        {
            Console.WriteLine($"Result of Count-Up: {task1.Result}");
        }
        else
        {
            Console.WriteLine($"Result of Count-Down: {task2.Result.Sum}");
        }

        Console.ReadKey();
    }
}

// Simulate complex type which used by Task Generic
class SumData
{
    public long Sum { get; set; }
}