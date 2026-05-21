using System;
using System.Collections.Generic;

namespace project01
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();
    }
}