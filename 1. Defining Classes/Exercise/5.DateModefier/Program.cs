using System;

public class Program
{
    public static void Main()
    {
        string firstDateAsString = Console.ReadLine();
        string secondDateAsString = Console.ReadLine();

        DateModifier modifier = new DateModifier();

        int diff = modifier.DifferenceBetweenTwoDates(firstDateAsString, secondDateAsString);

        Console.WriteLine(diff);
    }
}