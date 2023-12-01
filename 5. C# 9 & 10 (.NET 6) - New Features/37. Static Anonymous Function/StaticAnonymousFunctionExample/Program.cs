
// Static Anonymous Function
//  => an anonymous method or lambda expression, prefixed with 'static'keyword
//
// It cannot access the state (local variables, parameters, 'this' keyword and 'base' keyword)
// of the enclosing method, and also cannot access instance members of enclosing type.
//
// But it is possible to access static class or static field in it
//
// The point is static anonymouse function should not access anything from instance data,
// it cannot access data from the object

class Student
{
    public int RollNumber { get; set; }
    public List<int> Marks { get; set; }
}

class Teacher
{
    public static int MinPassMarksStatic { get; set; } = 35;    // permitted to be accessed
    public const int MinPassMarksConstant = 35;                 // permitted to be accessed
    public int MinPassMarksProperty { get; set; } = 35;         // not permitted to be accessed

    public void GetMarksOfPassedSubjects(int minimumPassMarksParameter) // not permitted to be accessed
    {
        Student student = new Student()
        {
            RollNumber = 1,
            Marks = new List<int>() { 34, 10, 50, 78, 40 }
        };

        int minimumPassMarksLocalVariable = 35; // not permitted to be accessed

        // Get marks of passed subjects. Assuming minimum pass marks: 35

        // We use static here to prevent accidentally acces variable outside of lambda expression
        // Before, it is possible due to closure concept, inner function (anonymous function)
        // can access variable of the outer function (.GetMarksOfPassedSubjects())
        IEnumerable<int> passedSubjectMarks = student.Marks.Where(static (int n) => 
        {
            // access the variable
            if (n >= MinPassMarksStatic)
                return true;
            else
                return false;
        });

        foreach (var item in passedSubjectMarks)
            Console.WriteLine(item);
    }
}

class Program
{
    static void Main()
    {
        Teacher teacher = new Teacher();
        teacher.GetMarksOfPassedSubjects(35);

        Console.ReadKey();
    }
}