using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = Student.GetStudents();

            // Es1

            List<Student> es1 = students.Where(s => s.Grade >= 70).ToList();
            foreach(Student s in es1)
            {
                Console.WriteLine(s.Grade);
            }

            // Es2
            List<Student> es2 = students.Where(s => s.Branch == "Informatica").ToList();
            foreach (Student s in es2)
            {
                Console.WriteLine(s);
            }

            // Es3
            bool es3 = students.Any(s => s.Grade == 100);
            Console.WriteLine(es3);

            // Es4
            bool es4 = students.All(s => s.Grade > 40);
            Console.WriteLine(es4);

            // Es5
            Student es5 = students.FirstOrDefault(s => s.Branch == "Telecomunicazioni");
            Console.WriteLine(es5);

            // Es6
            Student es6 = students.SingleOrDefault(s => s.ID == 1001);
            Console.WriteLine(es6);


            // Es7
            List<string> es7 = students.Select(s => s.Name).ToList();
            foreach(string student in es7)
            {
                Console.WriteLine(student);
            }

            // Es8
            List<string> es8 = students.Select(s => s.Name.ToUpper()).ToList();

            // Es9
            var es9 = students
                .Select(s => new
                {
                    s.Name,
                    s.Grade,
                });

            // Es 10
            int es10 = students.Count(s => s.Branch == "Informatica");

            // Es11
            double es11 = students .Average(s => s.Grade);

            // Es12
            int es12 = students.Max(s => s.Grade);

            // Es13
            int es13 = students.Min(s => s.Grade);

            // Es14
            int es14 = students .Sum(s => s.Grade);

            Console.WriteLine("\nCAT 6 -------------------" + "\n" + es10 + "\n" + es11 + "\n" + es12 + "\n" + es13 + "\n" + es14 + "-----------------------");

            // Es15
            var es15 = students
                .OrderByDescending(s => s.Grade);

            // Es16
            var es16 = students
                .OrderBy(s => s.Branch)
                .ThenBy(s => s.Name);

            // Es17
            var es17 = students
                .OrderByDescending(s => s.Grade)
                .Take(3);

            // Es18
            var es18 = students
                .GroupBy(s => s.Subject);

            // Es19
            var es19 = students
                .GroupBy(s => s.Subject)
                .Select(g => new
                {
                    Subject = g.Key,
                    StudentCount = g.Count(),
                    AverageGrade = g.Average(s => s.Grade)
                });

            // Es20
            var es20 = students
                .SelectMany(s => s.Programming);

            // Es21
            var es21 = students 
                .SelectMany (s => s.Programming)
                .Distinct();

            // Es22
            var es22 = students
                .SelectMany(s => s.Programming)
                .Distinct()
                .OrderBy(language => language);

            // Es23
            bool es23 = students
                .SelectMany(s => s.Programming)
                .Contains("C#");

            // Es 24
            List<Student> es24 = students
                .Where(s => s.Grade > 80)
                .ToList();

            // Es25
            string[] es25 = students
                .Select(s => s.Name)
                .ToArray();

            // Es26
            foreach(var name in students.Select(s => s.Name))
            {
                Console.WriteLine(name);
            }

            // Es27
            var es27 = students
                .FirstOrDefault(s => s.ID == 999);

            // Es28
            string es28 = es27?.Name;

            // Es29
            string es29 = es27?.Name ?? "Id non trovato...";

            // Es30
            var es30 = students
                .Where(s => s.Grade > 70)
                .OrderByDescending(s => s.Grade)
                .Take(3)
                .Select(s => s.Name);

            // Es31
            var es31 = students
                .SelectMany(s => s.Programming)
                .Distinct()
                .OrderBy(language => language);

        }
    }
}
