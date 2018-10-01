using System;
using System.Globalization;

public class DateModifier
{
    public int DifferenceBetweenTwoDates(string firstDateAsString, string secondDateAsString)
    {
        DateTime firstDate = DateTime.ParseExact(firstDateAsString, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime secondDate = DateTime.ParseExact(secondDateAsString, "yyyy MM dd", CultureInfo.InvariantCulture);

        return Math.Abs((firstDate - secondDate).Days);
    }
}