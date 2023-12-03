
// Constant string may be initialized using 'string interpolation' i.e. with ${},
// if all the placeholders are constant strings

class Example
{
    public const string BaseUrl = "http://www.example.com";
    
    // this is in the past, we repeat the domain
    public const string ApiUrl_1 = "http://www.example.com/api";

    // this is the new feature with string interpolation
    // notice the placeholder should be paired with constant string 
    public const string ApiUrl_2 = $"{BaseUrl}/api";
}

class Program
{
    static void Main()
    {
        Console.WriteLine(Example.BaseUrl);
        Console.WriteLine(Example.ApiUrl_1);
        Console.WriteLine(Example.ApiUrl_2);

        Console.ReadKey();
    }
}