// AggregateException has property InnerException which contains list of actual exception

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
            Task.Delay(300).Wait();
        }
        Console.WriteLine("\nCount-Up ends");

        // Simulate an exception is thrown in this task
        // This exception will be assigned to InnerExceptions collection in AggregateException
        throw new Exception("Unable to generate sum in Count-Up method");

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

        return new SumData { Sum = sum, };
    }
}

class Program
{
    public static void Main()
    {
        UpCounter upCounter = new();
        DownCounter downCounter = new();

        Task<long> task1 = Task.Run(() => 
        {
            return upCounter.CountUp(20);
        });

        task1.ContinueWith((antecedent) =>
        {
            // Either you can access exception or result in Task. You cannot access both
            if (antecedent.Status == TaskStatus.RanToCompletion)
            {
                Console.WriteLine($"Result of Count-Up: {antecedent.Result}");
            }
            else if (antecedent.Status == TaskStatus.Faulted)
            {
                Console.WriteLine($"Exception occurred: {antecedent.Exception?.InnerExceptions.First().Message}");
            }
        });

        Task<SumData> task2 = Task.Run(() => 
        {
            return downCounter.CountDown(25);
        });

        task2.ContinueWith((antecedent) =>
        {
            Console.WriteLine($"Result of Count-Down: {antecedent.Result.Sum}");
        });

        Console.WriteLine("\nEnd of Main Thread");
        Console.ReadKey();
    }
}

class SumData
{
    public long Sum { get; set; }
}