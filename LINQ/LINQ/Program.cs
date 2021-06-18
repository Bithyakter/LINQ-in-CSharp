using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] Students = new Student[]
            {
                new Student { StudentID = 1, StudentName = "Shammi", StudentGender = "Female", StudentAge = 23, DepartmentID = 1, CourseCode = 101},
                new Student { StudentID = 2, StudentName = "Trisha", StudentGender = "Female", StudentAge = 23, DepartmentID = 2, CourseCode = 103},
                new Student { StudentID = 3, StudentName = "Radee", StudentGender = "Male", StudentAge = 10, DepartmentID = 1, CourseCode = 103},
                new Student { StudentID = 4, StudentName = "Nitu", StudentGender = "Female", StudentAge = 16, DepartmentID = 3, CourseCode = 104},
                new Student { StudentID = 5, StudentName = "Nafiya", StudentGender = "Female", StudentAge = 18, DepartmentID = 1, CourseCode = 102},
                new Student { StudentID = 6, StudentName = "Shuvo", StudentGender = "Male", StudentAge = 26, DepartmentID = 2, CourseCode = 105},
                new Student { StudentID = 7, StudentName = "Jelly", StudentGender = "Female", StudentAge = 28, DepartmentID = 1, CourseCode = 101},
                new Student { StudentID = 8, StudentName = "Suparna", StudentGender = "Female", StudentAge = 25, DepartmentID = 2, CourseCode = 105},
                new Student { StudentID = 9, StudentName = "Raj", StudentGender = "Male", StudentAge = 21, DepartmentID = 1, CourseCode = 102},
                new Student { StudentID = 10, StudentName = "Sharmin", StudentGender = "Female", StudentAge = 30, DepartmentID = 3, CourseCode = 104}
            };

            Department[] Departments = new Department[]
            {
                new Department { DepartmentID = 1, DepartmentName = "CSE" },
                new Department { DepartmentID = 2, DepartmentName = "EEE" },
                new Department { DepartmentID = 3, DepartmentName = "English" }
             };

            Course[] Courses = new Course[]
            {
                new Course { CourseCode = 101, CourseName = "C#" },
                new Course { CourseCode = 102, CourseName = "ASP.NET" },
                new Course { CourseCode = 103, CourseName = "SQL" },
                new Course { CourseCode = 104, CourseName = "English For Today" },
                new Course { CourseCode = 105, CourseName = "Electronics" }
             };


            /*=========================Select,where======================*/
            var StudentInfo = Students
            .Where(sg => String.Equals(sg.StudentGender, "Female"))
            .Select(std => new { 
                std.StudentName, 
                std.StudentID, 
               std.StudentGender, 
                std.StudentAge, 
                std.DepartmentID,  
                std.CourseCode });


            /*=========================Joining==========================*/
           /*Console.WriteLine("--------Join in SQL Query Syntax--------");
            var StudentInfo2 = from std in Students
                               join dpt in Departments on std.DepartmentID equals dpt.DepartmentID
				join c in Courses on std.DepartmentID equals c.CourseCode 
                               select new { std.StudentName, std.StudentID, std.StudentGender, dpt.DepartmentName, c.CourseCode };

            foreach (var info in StudentInfo2)
            {
                //Console.WriteLine(info.StudentName + " = " + info.DepartmentName);
                Console.WriteLine(info);
            }
            Console.WriteLine('\n');

            Console.WriteLine("--------Join in Lambda Expression--------");
            var StudentInfo = Students

                .Select(std => new { std.StudentName, std.StudentID, std.DepartmentID, std.StudentGender, std.CourseCode })
                .Join(Departments, st => st.DepartmentID, dp => dp.DepartmentID, (st, dp) => new { st.StudentName, st.StudentID, st.StudentGender, Department = dp.DepartmentName })
                //.Join(Courses, s => s.CourseCode, c => c.CourseCode, (s, c) => new { s.StudentName, s.StudentID, CourseName = c.CourseName})
                .OrderBy(a => a.StudentName).ThenBy(a => a.StudentName);
           */
            foreach (var info in StudentInfo)
            {
                Console.WriteLine(info);
            }
            Console.WriteLine('\n');


            /*=============================Where==========================*/
            Console.WriteLine("--------Where in SQL Query Syntax--------");
            var stdName = from student in Students
                               where student.StudentName.StartsWith("S")
                               select student.StudentName;

            foreach (var s in stdName)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine("--------Where in Lambda Expression--------");
            var stdName1 = Students.Where(e => e.StudentName.StartsWith("S"));

            foreach (var s in stdName1)
            {
                Console.WriteLine(s.StudentName);
            }
            Console.WriteLine('\n');


            /*=========================Group By============================*/
            Console.WriteLine("--------Group By Gender in SQL Query Syntax--------");
            var groupStd = from std in Students
                           group std by std.StudentGender;

            foreach (var g in groupStd)
            {
                Console.WriteLine(g.Key + " = " + g.Count());
            }

            Console.WriteLine("--------Group By Gender in Lambda Expression--------");
            var groupStd1 = Students.GroupBy(e => e.StudentGender);

            foreach (var g in groupStd1)
            {
                Console.WriteLine(g.Key + " = " + g.Count());
            }

            Console.WriteLine('\n');


            /*=======================Use of Aggregate=======================*/
            Console.WriteLine("--------------Use of Aggregate-----------");
            //Count
            var totalStudents = Students.Count();

            Console.WriteLine("\nNumber of Total Students: {0}", totalStudents);

            int SumOfStudentsAge = Students.Aggregate<Student, int>(0,
                                                (totalAge, s) => totalAge += s.StudentAge);

            Console.WriteLine("\nSum of All Student Age: {0}", SumOfStudentsAge);

            //Average
            var avgAge = Students.Average(s => s.StudentAge);

            Console.WriteLine("\nAverage Age of Students: {0}", avgAge);

            //Min & Max
            var oldest = Students.Max(s => s.StudentAge);

            Console.WriteLine("\nOldest Student Age: {0}", oldest);

            var Smallest = Students.Min(s => s.StudentAge);

            Console.WriteLine("\nSmallest Student Age: {0}", Smallest);

            Console.ReadKey();
        }
    }
}
