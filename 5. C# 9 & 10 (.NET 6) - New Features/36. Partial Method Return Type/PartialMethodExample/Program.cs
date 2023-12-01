using PartialMethodExample;

Student student = new();
student.Id = 1;

Console.WriteLine(student.Id);
Console.WriteLine(student.GetStudentId());
Console.ReadKey();