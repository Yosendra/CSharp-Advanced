
// Range (..) Opearator

List<string> myFriendsList = new()
{
    "Scott", "Allen", "Jones", "James", "Sara"
};

string[] myFriendsArray = new string[]
{
    "Scott", "Allen", "Jones", "James", "Sara"
};

// Skip "Scott", take next three element

// Range - LINQ
IEnumerable<string> shortListedElements1 = myFriendsList.Skip(1).Take(3);
foreach (string friend in shortListedElements1)
    Console.Write($"{friend}, ");
Console.WriteLine();

// Range - Range Struct : currently only working on Array, not List
Range range = 1..4;
string[] shortListedElements2 = myFriendsArray[range];
//string[] shortListedElements2 = myFriendsArray[1..4];
foreach (string friend in shortListedElements2)
    Console.Write($"{friend}, ");

Console.ReadKey();