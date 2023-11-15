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

        Task.Run(() => 
        {
            return upCounter.CountUp(20);
        })
            .ContinueWith((antecedent) =>
            {
                if (antecedent.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine($"Exception occurred: {antecedent.Exception?.InnerExceptions.First().Message}");
                    return -1;
                }

                else if (antecedent.Status == TaskStatus.RanToCompletion)
                {
                    // We offer the result to the next ContinueWith
                    return antecedent.Result;
                }
                // We are doing this just to satisfy the compiler
                else
                {
                    return -1;
                }
            })
            // This is ContinueWith chaining, because the previous return Task object so we can method do this method chaining
            // We cannot access directly to original task, it always we access the prevous one which is the result of the first ContinueWith
            .ContinueWith((antecedent) =>
            {
                if (antecedent.Result != -1)
                {
                    // Here we print the result from first ContinueWith
                    Console.WriteLine($"Result of Count-Up: {antecedent.Result}");
                }
            });

        Task.Run(() =>
        {
            return downCounter.CountDown(25);
        })
            .ContinueWith((antecedent) =>
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