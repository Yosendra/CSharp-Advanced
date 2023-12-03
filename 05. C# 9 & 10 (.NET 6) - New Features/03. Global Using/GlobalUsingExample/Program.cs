// We need not to import Generic namespace to use List<> collection
// also we can use linq immediately without importing System.Linq namespace in this file

List<int> numbers = new()
{
    1, 2, 3
};

var backUpNumbers = numbers.Select(x => x).ToList();
foreach (var number in backUpNumbers)
{
    Console.WriteLine(number);
}

Console.ReadKey();