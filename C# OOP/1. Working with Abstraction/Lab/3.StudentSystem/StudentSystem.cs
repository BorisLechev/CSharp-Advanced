using System;
using System.Collections.Generic;

namespace _3.StudentSystem
{
    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo { get; private set; }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            switch (args[0]?.ToLower()) // ? защото може да е null
            {
                case "create":
                    CreateStudent(args);
                    break;
                case "show":
                    ShowStudent(args);
                    break;
                case "exit":
                    Exit();
                    break;
                default:
                    break;
            }
        }

        private void CreateStudent(string[] args)
        {
            string name = args[1];
            int age = int.Parse(args[2]);
            double grade = double.Parse(args[3]);

            if (!Repo.ContainsKey(name))
            {
                Student student = new Student(name, age, grade);
                Repo[name] = student;
            }
        }

        private void ShowStudent(string[] args)
        {
            string name = args[1];

            if (Repo.ContainsKey(name))
            {
                Student student = Repo[name];

                Console.WriteLine(student);
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
