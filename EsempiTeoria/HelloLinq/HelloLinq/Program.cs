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
            List<string> es9 = students.Select(s => s.Name).ToList();





        }
    }
}
