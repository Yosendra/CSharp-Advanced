namespace PartialMethodExample
{
    // Partial class in the same namespace
    // Will be combined with the other same partial class when compilation

    // Student2.cs
    partial class Student
    {
        // Here we set property in Student2.cs, then we set the field in Student1.cs
        public int Id 
        {
            // Notice that '_id' field is accessible in this file
            get => _id;
            set => _id = value; 
        }

        // Partial method implementation
        public partial int GetStudentId()   // Must have same signature as the other part
        {
            return Id;
        }
    }
}
