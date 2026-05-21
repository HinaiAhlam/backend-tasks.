using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; 

namespace project01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                if (!context.Departments.Any())
                {
                    var csDept = new Department { Name = "CS" };
                    var itDept = new Department { Name = "IT" };
                    var isDept = new Department { Name = "IS" };

                    context.Departments.AddRange(csDept, itDept, isDept);

                    var initialStudents = new List<Student>
                    {
                        new Student { Name = "Ali", Age = 20, Department = csDept, Grade = 90 },
                        new Student { Name = "Sara", Age = 22, Department = itDept, Grade = 75 },
                        new Student { Name = "Mona", Age = 21, Department = csDept, Grade = 88 },
                        new Student { Name = "Omar", Age = 23, Department = isDept, Grade = 60 },
                        new Student { Name = "Lina", Age = 20, Department = itDept, Grade = 95 },
                        new Student { Name = "Ahmed", Age = 24, Department = csDept, Grade = 70 }
                    };

                    context.Students.AddRange(initialStudents);
                    context.SaveChanges(); 
                }

                Console.WriteLine("=== تم الاتصال بقاعدة البيانات وجلب البيانات عبر LINQ ===\n");

                var highGrades = context.Students.Where(s => s.Grade > 80).ToList();
                Console.WriteLine("Students with Grade > 80:");
                foreach (var std in highGrades)
                {
                    Console.WriteLine(std.Name);
                }
                Console.WriteLine("-------------------------------------");

                var studentNames = context.Students.Select(s => s.Name).ToList();
                Console.WriteLine("All Student Names:");
                foreach (var name in studentNames)
                {
                    Console.WriteLine(name);
                }
                Console.WriteLine("-------------------------------------");

                var firstInCS = context.Students
                    .Include(s => s.Department)
                    .FirstOrDefault(s => s.Department != null && s.Department.Name == "CS");
                Console.WriteLine($"First student in CS: {firstInCS?.Name}");
                Console.WriteLine("-------------------------------------");

                var sortedStudents = context.Students.OrderByDescending(s => s.Grade).ToList();
                Console.WriteLine("Students sorted by grade (Descending):");
                foreach (var std in sortedStudents)
                {
                    Console.WriteLine($"{std.Name} - {std.Grade}");
                }
                Console.WriteLine("-------------------------------------");

                double averageGrade = context.Students.Average(s => s.Grade);
                Console.WriteLine($"Average Grade: {averageGrade:F1}");
                Console.WriteLine("-------------------------------------");

                int itCount = context.Students.Count(s => s.Department != null && s.Department.Name == "IT");
                Console.WriteLine($"Number of students in IT: {itCount}");
                Console.WriteLine("-------------------------------------");

                var topStudent = context.Students.OrderByDescending(s => s.Grade).FirstOrDefault();
                Console.WriteLine($"Top Student: {topStudent?.Name} with Grade: {topStudent?.Grade}");
                Console.WriteLine("-------------------------------------");
            }

            Console.ReadLine(); 
        }
    }
}