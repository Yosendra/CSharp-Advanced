// Wait(), WaitAny(), WaitAll() these all are blocking statement, it is not recommendded using these in the real project
// Instead use async-await keyword for non-blocking operation

// Task.ContinueWith() is the solution for blocking statement

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

        Task<long> task1 = Task.Run(() => 
        {
            // Here we are trying to return a value from Task
            return upCounter.CountUp(20);
        });

        // Here we use .ContinueWith()
        // This will be executed after the task1 is completed.
        // antecedent = the result of task1
        task1.ContinueWith((antecedent) =>
        {
            Console.WriteLine($"Result of Count-Up: {antecedent.Result}");
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

// Simulate complex type which used by Task Generic
class SumData
{
    public long Sum { get; set; }
}