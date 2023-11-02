class Program
{
    static void Main()
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";

        // Get the thread's priority level
        ThreadPriority priority = mainThread.Priority;

        Console.WriteLine(mainThread.Name);
        
        // Output : Normal
        Console.WriteLine(priority);

        // Output : True
        Console.WriteLine(mainThread.IsAlive);

        // Output : False
        // Indicate that Main Thread will prevent console application from closing
        // Console application has to wait until the completion of Main Thread
        // That is the completion of Main Method's excecution
        Console.WriteLine(mainThread.IsBackground);

        ThreadState state = mainThread.ThreadState;
        // Output : Running
        Console.WriteLine(state);

        Console.ReadKey();
    }
}