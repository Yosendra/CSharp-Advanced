using System.Runtime.CompilerServices;

class Program
{
    public async static Task Main()
    {
        Program program = new();

        try
        {
            await program.A();
            Console.WriteLine("Finish executing Main"); // This line will not be executed because the exception thrown
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        Console.ReadKey();
    }

    private async Task A()
    {
        await this.B();
        Console.WriteLine("Finish executing A"); // This line will not be executed because the exception thrown
    }

    private async Task B()
    {
        await this.C();
        Console.WriteLine("Finish executing B"); // This line will not be executed because the exception thrown
    }

    private async Task C()
    {
        throw new NotImplementedException();
    }
}