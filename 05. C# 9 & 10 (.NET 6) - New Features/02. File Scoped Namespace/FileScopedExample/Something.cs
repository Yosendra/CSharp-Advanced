// We decide top-level statment here
Something something = new();
Console.WriteLine(something.student);
Console.WriteLine(something.teacher);
Console.ReadKey();

// This class will not be included in College namespace, and do not belong to any namespace
class Something
{
    // We can access College namespace here
    public College.Student student = new College.Student();
    public College.Teacher teacher = new College.Teacher();
}
