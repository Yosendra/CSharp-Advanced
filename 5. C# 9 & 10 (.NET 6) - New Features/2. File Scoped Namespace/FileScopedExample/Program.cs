// College - Student, Teacher

// Traditional Way, namespace use curly braced
//namespace College
//{
//    class Student {}
//    class Teacher {}
//}

// But in file scoped namespace, only one namespace is allowed

// - namespace statement can be declared before or after using statement
using System;
namespace College;
using System.IO;

class Student { }
class Teacher { }

// Using semicolon at the end of namespace statement, both class still in College namespace
