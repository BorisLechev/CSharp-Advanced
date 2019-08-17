using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Engine
    {
        private Dictionary<string, List<string>> doctors;

        private Dictionary<string, List<List<string>>> departments;

        public Engine()
        {
            this.doctors = new Dictionary<string, List<string>>();
            this.departments = new Dictionary<string, List<List<string>>>();
        }
        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "Output")
            {
                string[] tokens = command.Split();

                string departament = tokens[0];
                string firstName = tokens[1];
                string secondName = tokens[2];
                string patient = tokens[3];

                string fullname = firstName + secondName;

                this.AddDoctor(fullname);
                this.AddDepartment(departament);

                bool isFree = this.departments[departament].SelectMany(x => x).Count() < 60;

                if (isFree)
                {
                    this.AddPatientToRoom(departament, patient, fullname);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    string departmentName = args[0];

                    this.PrintPatientsInDepartment(departmentName);
                }

                else if (args.Length == 2)
                {
                    bool isRoom = int.TryParse(args[1], out int room);

                    if (isRoom)
                    {
                        string departmentName = args[0];

                        this.PrintPatientsInRoom(room, departmentName);
                    }

                    else
                    {
                        string fullName = args[0] + args[1];

                        this.PrintAllPatientsDoctor(fullName);
                    }
                }

                command = Console.ReadLine();
            }
        }

        private void PrintAllPatientsDoctor(string fullName)
        {
            string[] allPatientsOfDoctor =
                                        doctors[fullName]
                                        .OrderBy(x => x)
                                        .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsOfDoctor));
        }

        private void PrintPatientsInRoom(int room, string departmentName)
        {
            string[] allPatientsInARoom =
                                        departments[departmentName][room - 1]
                                        .OrderBy(x => x)
                                        .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInARoom));
        }

        private void PrintPatientsInDepartment(string departmentName)
        {
            string[] allPatientsInDepartment =
                                    departments[departmentName]
                                    .Where(x => x.Count > 0)
                                    .SelectMany(x => x)
                                    .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, allPatientsInDepartment));
        }

        private void AddPatientToRoom(string departament, string patient, string fullname)
        {
            int room = 0;

            this.doctors[fullname].Add(patient);

            for (int currentRoom = 0; currentRoom < this.departments[departament].Count; currentRoom++)
            {
                if (this.departments[departament][currentRoom].Count < 3)
                {
                    room = currentRoom;
                    break;
                }
            }

            //int targetRoom = this.departments[departament].SelectMany(x => x).Where.Count();

            this.departments[departament][room].Add(patient);
        }

        private void AddDepartment(string departament)
        {
            if (!this.departments.ContainsKey(departament))
            {
                this.departments[departament] = new List<List<string>>();

                for (int room = 0; room < 20; room++)
                {
                    this.departments[departament].Add(new List<string>());
                }
            }
        }

        private void AddDoctor(string fullname)
        {
            if (!this.doctors.ContainsKey(fullname))
            {
                this.doctors[fullname] = new List<string>();
            }
        }
    }
}
