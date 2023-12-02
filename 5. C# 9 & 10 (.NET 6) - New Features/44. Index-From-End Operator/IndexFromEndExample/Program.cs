
// ^ (carret) => this operator returns the index from end of the array (index starts from 1)
// ex: array[^1]

List<string> myFriends = new()
{
    "Scott", "Allen", "Jones", "James", "Sara"
};

// Traditional way to get the last index of an element in array
Console.WriteLine(myFriends[myFriends.Count - 1]);

// Using '^' operator
Console.WriteLine(myFriends[^1]);

Console.ReadKey();