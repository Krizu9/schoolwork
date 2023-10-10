using System;
using System.Collections.Generic;
using System.Linq;

namespace Task40
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Hanna", "Husso", "TTV19S1"));
            students.Add(new Student("Kirsi", "Kernell", "TTV19S2"));
            students.Add(new Student("Masa", "Niemi", "TTV19S3"));
            students.Add(new Student("Teppo", "Testaaja", "TTV19SM"));
            students.Add(new Student("Allan", "Aalto", "TTV19SM"));

            Console.WriteLine("The first student in the MiniPeppi:");
            Console.WriteLine(students[0]);

            Console.WriteLine("The last student in the MiniPeppi:");
            Console.WriteLine(students[students.Count - 1]);

            Console.WriteLine("\nThe all 5 students in the MiniPeppi:");
            foreach (Student student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\nThe all students in alphabetical order in the MiniPeppi:");
            foreach (Student student in students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName))
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            Console.WriteLine("Please, give data of new Student:");
            string sid, firstName, lastName, group;
            Console.Write("SID: ");
            sid = Console.ReadLine();
            Console.Write("First name: ");
            firstName = Console.ReadLine();
            Console.Write("Surname: ");
            lastName = Console.ReadLine();
            Console.Write("Group: ");
            group = Console.ReadLine();

            if (students.Any(s => s.SID == sid))
            {
                Console.WriteLine($"Error: There is already a student with SID {sid} in the register.");
            }
            else
            {
                Student newStudent = new Student(firstName, lastName, group, sid);
                students.Add(newStudent);
                Console.WriteLine($"{newStudent.FirstName} {newStudent.LastName} added succesfully. There are now {students.Count} students in MiniPeppi.");

                Console.WriteLine("\nThe all students in alphabetical order in the MiniPeppi:");
                foreach (Student student in students.OrderBy(s => s.LastName).ThenBy(s => s.FirstName))
                {
                    Console.WriteLine(student);
                }
            }

            Console.ReadKey();
        }
    }

    class Student
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string SID { get; }
        public string Group { get; }

        private static int nextSIDNumber = 1;

        public Student(string firstName, string lastName, string group, string sid = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Group = group;

            if (sid == null)
            {
                string sidPrefix = $"{FirstName[0]}{LastName[0]}".ToUpper();
                string sidNumberString = nextSIDNumber.ToString("D3");
                SID = $"{sidPrefix}{sidNumberString}";

                nextSIDNumber++;
            }
            else
            {
                SID = sid;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {SID} {Group}";
        }
    }
}
