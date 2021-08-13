using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Classroom
{
    public class Classroom
    {
        private readonly ICollection<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; private set; }

        public int Count { get => this.students.Count(); }

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > this.Count)
            {
                this.students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = this.students.SingleOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }

            this.students.Remove(student);

            return $"Dismissed student {firstName} {lastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            var sb = new StringBuilder();

            var list = this.students
                .Where(s => s.Subject == subject)
                .ToList();

            if (list.Any() == false)
            {
                return "No students enrolled for the subject";
            }

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in list)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            var student = this.students.SingleOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            return student;
        }
    }
}
