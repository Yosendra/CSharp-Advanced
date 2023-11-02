class Program
{
    static void Main()
    {
        // Access current working thread which is Main Thread
        Thread mainThread = Thread.CurrentThread;
        
        // Giving name to the thread
        mainThread.Name = "Main Thread";

        // Invoke the .ToString()
        Console.WriteLine(mainThread);
        
        // Print the thread's name we have given
        Console.WriteLine(mainThread.Name);

        Method1();
    }

    static void Method1() 
    {
        Console.WriteLine("Method 1");
    }
}