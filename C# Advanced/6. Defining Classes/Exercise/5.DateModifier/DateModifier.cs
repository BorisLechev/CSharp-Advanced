using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DefiningClasses
{
    public class DateModifier
    {
        private string firstDate;

        private string secondDate;

        public DateModifier(string firstDate, string secondDate)
        {
            this.firstDate = firstDate;
            this.secondDate = secondDate;
        }

        public double CalculateDiffBetweenDates()
        {
            DateTime firstDate = DateTime.ParseExact(
                this.firstDate,
                "yyyy MM dd",
                System.Globalization.CultureInfo.InvariantCulture);

            DateTime secondDate = DateTime.ParseExact(
                this.secondDate,
                "yyyy MM dd",
                System.Globalization.CultureInfo.InvariantCulture);

            return Math.Abs((secondDate - firstDate).TotalDays);
        }
    }
}
