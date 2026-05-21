using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Ali", Age = 20, Department = "CS", Grade = 90 },
            new Student { Id = 2, Name = "Sara", Age = 22, Department = "IT", Grade = 75 },
            new Student { Id = 3, Name = "Mona", Age = 21, Department = "CS", Grade = 88 },
            new Student { Id = 4, Name = "Omar", Age = 23, Department = "IS", Grade = 60 },
            new Student { Id = 5, Name = "Lina", Age = 20, Department = "IT", Grade = 95 },
            new Student { Id = 6, Name = "Ahmed", Age = 24, Department = "CS", Grade = 70 }
        };

        Console.WriteLine("=== LINQ Operations Results ===");
        Console.WriteLine();

     
        var highGrades = students.Where(s => s.Grade > 80);
        Console.WriteLine("Students with Grade > 80:");
        foreach (var student in highGrades)
        {
            Console.WriteLine($"- {student.Name} ({student.Grade})");
        }
        Console.WriteLine();

    
        var studentNames = students.Select(s => s.Name);
        Console.WriteLine("All Student Names:");
        foreach (var name in studentNames)
        {
            Console.WriteLine($"- {name}");
        }
        Console.WriteLine();

      
        var firstCsStudent = students.FirstOrDefault(s => s.Department == "CS");
        Console.WriteLine("First student in CS department:");
        if (firstCsStudent != null)
        {
            Console.WriteLine($"- {firstCsStudent.Name}");
        }
        Console.WriteLine();

        var sortedStudents = students.OrderByDescending(s => s.Grade);
        Console.WriteLine("Students sorted by grade descending:");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"- {student.Name}: {student.Grade}");
        }
        Console.WriteLine();


        double averageGrade = students.Average(s => s.Grade);
        Console.WriteLine($"Average Grade: {averageGrade:F1}");
        Console.WriteLine();

        int itCount = students.Count(s => s.Department == "IT");
        Console.WriteLine($"Number of students in IT: {itCount}");
        Console.WriteLine();

      
        var topStudent = students.OrderByDescending(s => s.Grade).FirstOrDefault();
        Console.WriteLine($"Top Student: {topStudent?.Name} with Grade: {topStudent?.Grade}");

        Console.ReadKey();
    }
}