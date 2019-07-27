using System;

public class Person
{
    private string name;

    private int age;

    public virtual string Name
    {
        get { return this.name; }
        set
        {
            if (value.Length<3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }

            this.name = value;
        }
    }

    public virtual int Age
    {
        get { return this.age; }
        set
        {
            if (value<0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            else if (value>15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }

            this.age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Name: {this.Name}, Age: {this.Age}";
    }
}