using System;

namespace project01
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }

        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}