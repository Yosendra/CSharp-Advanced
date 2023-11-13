// Wait(), WaitAny(), WaitAll() these all are blocking statement, it is not recommendded using these in the real project
// Instead use async-await keyword for non-blocking operation

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

            // We use Task.Delay()
            Task.Delay(300).Wait();
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
            Task.Delay(300).Wait();

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

        Console.WriteLine("Waiting completion tasks");

        // .WaitAll() is a blocking statement, so it will block the current working thread which is main thread
        Task.WaitAll(task1, task2);

        Console.WriteLine($"Result of Count-Up: {task1.Result}");
        Console.WriteLine($"Result of Count-Down: {task2.Result.Sum}");

        Console.WriteLine("\nEnd of Main Thread");
        Console.ReadKey();
    }
}

// Simulate complex type which used by Task Generic
class SumData
{
    public long Sum { get; set; }
}