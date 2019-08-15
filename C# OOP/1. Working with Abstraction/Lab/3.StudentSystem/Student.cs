namespace _3.StudentSystem
{
    public class Student
    {
        public double Grade { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public override string ToString()
        {
            string view = $"{this.Name} is {this.Age} years old.";

            if (this.Grade >= 5.00)
            {
                view += " Excellent this.";
            }

            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                view += " Average this.";
            }

            else
            {
                view += " Very nice person.";
            }

            return view;
        }
    }
}