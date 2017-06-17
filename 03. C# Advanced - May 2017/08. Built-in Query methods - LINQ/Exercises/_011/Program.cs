namespace _011
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<StudentSpecialty> studentSpecialtys = new List<StudentSpecialty>();
            List<Student> students = new List<Student>();

            bool studentsRead = false;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Students:")
                {
                    studentsRead = true;
                    continue;
                }

                if (input == "END")
                {
                    break;
                }
                else if (!studentsRead)
                {
                    string[] data = input.Split();
                    studentSpecialtys.Add(new StudentSpecialty
                    {
                        SpecialtyName = data[0] + " " + data[1],
                        FacultyNumber = int.Parse(data[2])
                    });
                }
                else
                {
                    string[] data = input.Split();
                    students.Add(new Student
                    {
                        StudentName = data[1] + " " + data[2],
                        FacultyNumber = int.Parse(data[0])
                    });
                }
            }

            var sort = from ss in studentSpecialtys
                       join s in students on ss.FacultyNumber equals s.FacultyNumber
                       select new
                       {
                           StudentName = s.StudentName,
                           StudnetInfo = ss.FacultyNumber + " " + ss.SpecialtyName
                       };

            foreach (var group in sort.OrderBy(c => c.StudentName))
            {
                Console.WriteLine("{0} {1}", group.StudentName, group.StudnetInfo);
            }
        }
    }

    class StudentSpecialty
    {
        public string SpecialtyName { get; set; }

        public int FacultyNumber { get; set; }
    }

    class Student
    {
        public string StudentName { get; set; }

        public int FacultyNumber { get; set; }
    }
}