
// A lambda expression (or lambda function) can have a return type before the list of parenthesized parameters

class Program
{
    static void Main()
    {
        var getMessage = () => "Hello World";

        // Scenario 1
        Func<int, object> getResult = (mark) => 
        {
            if (mark >= 35)
                return "Pass";
            else
                return 0;
        };
        var tempResult = getResult(10);
        Console.WriteLine(tempResult.GetType());
        Console.WriteLine(tempResult);

        // Scenario 2
        var GetNumbers = IList<int> () => new int[] { 1, 2, 3 };
        var result = GetNumbers();
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }

        Console.ReadKey();
    }
}