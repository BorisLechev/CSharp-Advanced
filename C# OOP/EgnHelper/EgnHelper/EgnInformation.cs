using System;
using System.Globalization;

namespace EgnHelper
{
    public class EgnInformation
    {
        public EgnInformation(string placeOfBirth, DateTime dateOfBirth, Sex sex)
        {
            this.PlaceOfBirth = placeOfBirth;
            this.DateOfBirth = dateOfBirth;
            this.Sex = sex;
        }

        public string PlaceOfBirth { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Sex Sex { get; set; }

        public override string ToString()
        {
            // C# 8.0
            var sexAsText = this.Sex switch
            {
                Sex.Unknown => "неизвестен",
                Sex.Male => "мъж",
                Sex.Female => "жена",
                _ => string.Empty,
            };

            var sexSufix = this.Sex switch
            {
                Sex.Unknown => string.Empty,
                Sex.Male => string.Empty,
                Sex.Female => "а",
                _ => string.Empty,
            };

            return $"ЕГН на {sexAsText}, роден{sexSufix} на {this.DateOfBirth.ToString("d MMMM yyyy", new CultureInfo("bg-BG"))} г. в регион {this.PlaceOfBirth}";
        }
    }
}