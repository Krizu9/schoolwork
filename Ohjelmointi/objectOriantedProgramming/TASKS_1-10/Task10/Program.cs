using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Specialization { get; set; }

    public Student(string name, int age, string specialization)
    {
        Name = name;
        Age = age;
        Specialization = specialization;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        students.Add(new Student("Daniel", 23, "Computer Science"));
        students.Add(new Student("Jarkko", 19, "Mathematics"));
        students.Add(new Student("Tenho", 19, "Physics"));
        students.Add(new Student("Taneli", 26, "Chemistry"));
        students.Add(new Student("Eve", 18, "Biology"));

        foreach (Student student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Specialization: {student.Specialization}");
        }
    }
}