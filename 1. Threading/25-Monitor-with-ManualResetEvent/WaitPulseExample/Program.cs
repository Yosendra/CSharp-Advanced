class Shared
{
    // Lock object to be used by both Producer and Consumer threads
    public static readonly object lockObject = new();
    // Buffer to store int data value
    public static Queue<int> Buffer = new();
    // Maximum capacity of the buffer (queue)
    public const int BufferCapacity = 5;
    // Default to "true" because producer has to keep proceed, but consumer has to wait for the first time
    public static ManualResetEvent ProducerEvent = new(true); 
    public static ManualResetEvent ConsumerEvent = new(false);

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
        Thread.Sleep(2000);

        for (int i = 0; i <= 10; i++)
        {
            lock (Shared.lockObject)
            {
                if (Shared.Buffer.Count >= Shared.BufferCapacity)
                {
                    Console.WriteLine("Buffer is full. Waiting for signal from consumer.");

                    // Sets the state of producer event to "unsignaled". But it doesn't block the execution flow
                    Shared.ProducerEvent.Reset();
                }
            }

            // This then will actually stop the execution
            // If ProducerEvent is "unsignaled", continue exection. Vice versa
            Shared.ProducerEvent.WaitOne();

            lock (Shared.lockObject)
            {
                Shared.Buffer.Enqueue(i);
                Console.WriteLine($"Producer produced: {i}");
                Shared.Print();

                // Sets the consumer thread event as signaled. It wakes the consumer thread
                Shared.ConsumerEvent.Set();
            }
        }

        Console.WriteLine("Production Completed");
    }
}

class Consumer
{
    public void Consume()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} started");

        for (int i = 0; i < 10; i++)
        {
            lock (Shared.lockObject)
            {
                if (Shared.Buffer.Count == 0)
                {
                    Console.WriteLine("Buffer is empty, waiting for signal from producer");
                    Shared.ConsumerEvent.Reset();   // Set the consumer event as "unsignaled"
                }
            }

            Shared.ConsumerEvent.WaitOne();   // Block the consumer thread

            Console.WriteLine("Consumer: Processing the data");
            Thread.Sleep(2500);

            lock (Shared.lockObject)
            {
                int val = Shared.Buffer.Dequeue();
                Console.WriteLine($"Consumer consumed : {val}");

                // Signal the producer that there is a space in the buffer
                Shared.ProducerEvent.Set();
            }
        }

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

        Console.WriteLine("Main thread completed");

        Console.ReadKey();
    }
}

