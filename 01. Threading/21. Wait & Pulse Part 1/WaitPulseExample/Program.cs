class Shared
{
    // Lock object to be used by both Producer and Consumer threads
    public static readonly object lockObject = new();
    // Buffer to store int data value
    public static Queue<int> Buffer = new();
    // Maximum capacity of the buffer (queue)
    public const int BufferCapacity = 5;

    public static void Print()
    {
        // Buffer: 1, 2, 3, 4, 5
        Console.Write("Buffer: ");
        foreach (var item in Buffer)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
    }
}

class Producer
{
    public void Produce()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: Generating Data");

        Console.WriteLine("Production Completed");
    }
}

class Consumer
{
    public void Consume()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} started");

        Console.WriteLine("Consumption Completed");
    }
}

class Program
{
    static void Main()
    {
        // Create object of Producer and Consumer types
        Producer producer = new();
        Consumer consumer = new();

        // Create object of Thread class
        Thread producerThread = new(producer.Produce)
        {
            Name = "Producer Thread"
        };
        Thread consumerThread = new(consumer.Consume)
        {
            Name = "Consumer Thread"
        };

        // Start the threads
        producerThread.Start();
        consumerThread.Start();

        // Join
        producerThread.Join();
        consumerThread.Join();

        Console.ReadKey();
    }
}

