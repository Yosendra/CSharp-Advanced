class UpCounter
{
    public long CountUp(int count, CancellationToken cancellationToken)
    {
        long sum = 0;

        Console.WriteLine("\nCount-Up starts");
        for (int i = 1; i <= count; i++)
        {
            // cancellationToken.IsCancellationRequested we can use this to check, but here we will throw an exception
            // If this exception is thrown, the task status is 'Cancelled' not 'Faulted'
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine($"i = {i} ");
            sum += i;
            Task.Delay(300).Wait();
        }
        Console.WriteLine("\nCount-Up ends");

        //throw new Exception("Unable to generate sum in Count-Up method");

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

        // Create the CancellationTokenSource class object
        // Used to generate the token
        CancellationTokenSource cancellationTokenSource = new();

        Task.Run(() => 
        {
            // cancellationTokenSource.Token needs to be supplied in order 
            // the cancellation process can coordinate with the task
            return upCounter.CountUp(20, cancellationTokenSource.Token);
        },
        cancellationTokenSource.Token
        )
            .ContinueWith((antecedent) =>
            {
                // Give condition if task is canceled
                if (antecedent.Status == TaskStatus.Canceled)
                {
                    Console.WriteLine("Count-Up Task is Canceled.");
                    return -1;
                }
                else if (antecedent.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine($"Exception occurred: {antecedent.Exception?.InnerExceptions.First().Message}");
                    return -1;
                }
                else if (antecedent.Status == TaskStatus.RanToCompletion)
                {
                    return antecedent.Result;
                }

                return -1;
            })
            .ContinueWith((antecedent) =>
            {
                if (antecedent.Result != -1)
                {
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

        // Cancel task1
        Task.Delay(5000).Wait();
        cancellationTokenSource.Cancel();

        Console.WriteLine("\nEnd of Main Thread");
        Console.ReadKey();
    }
}

class SumData
{
    public long Sum { get; set; }
}