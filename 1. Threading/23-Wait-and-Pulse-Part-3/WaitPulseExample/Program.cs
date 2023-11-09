﻿class Shared
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

        for (int i = 0; i <= 10; i++)
        {
            lock (Shared.lockObject)
            {
                Console.WriteLine("Producer: Generating Data");
                Thread.Sleep(5000);

                if (Shared.Buffer.Count >= Shared.BufferCapacity)
                {
                    Console.WriteLine("Buffer is full. Waiting for signal from consumer.");

                    // Wait for signal from consumer thread
                    Monitor.Wait(Shared.lockObject);
                }
                Shared.Buffer.Enqueue(i);
                Console.WriteLine($"Producer produced: {i}");
                Shared.Print();

                // Wake up the consumer thread
                Monitor.Pulse(Shared.lockObject);
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
                    Monitor.Wait(Shared.lockObject);
                }
            }

            Console.WriteLine("Consumer: Processing the data");
            Thread.Sleep(2500);

            lock (Shared.lockObject)
            {
                int val = Shared.Buffer.Dequeue();
                Console.WriteLine($"Consumer consumed : {val}");

                // Signal the producer that there is a space in the buffer
                Monitor.Pulse(Shared.lockObject);
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

