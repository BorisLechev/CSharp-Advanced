using System;

public class Program
{
    public static void Main()
    {
        try
        {
            var firstLine = Console.ReadLine().Split(" ");

            string studentFirstName = firstLine[0];
            string studentLastName = firstLine[1];
            string FacultyNumber = firstLine[2];

            Student student = new Student(studentFirstName, studentLastName, FacultyNumber);

            var secondLine = Console.ReadLine().Split(" ");

            string workerFirstName = secondLine[0];
            string workerLastName = secondLine[1];
            decimal weekSalary = decimal.Parse(secondLine[2]);
            double workHoursPerDay = double.Parse(secondLine[3]);

            Worker worker = new Worker(workerFirstName, workerLastName, weekSalary, workHoursPerDay);

            Console.WriteLine(student + Environment.NewLine);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}