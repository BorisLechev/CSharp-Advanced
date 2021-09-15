using System;
using System.Collections.Generic;

namespace EgnHelper
{
    public class EgnInformationExtractor
    {
        private SortedDictionary<int, string> cities = new SortedDictionary<int, string>()
        {
            { 43, "Благоевград" },           /* от 000 до 043 */
            { 93, "Бургас"},                /* от 044 до 093 */
            { 139, "Варна"},                /* от 094 до 139 */
            { 169, "Велико Търново"},       /* от 140 до 169 */
            { 183, "Видин"},                /* от 170 до 183 */
            { 217, "Враца"},                /* от 184 до 217 */
            { 233, "Габрово"},              /* от 218 до 233 */
            { 281, "Кърджали"},             /* от 234 до 281 */
            { 301, "Кюстендил"},            /* от 282 до 301 */
            { 319, "Ловеч"},                /* от 302 до 319 */
            { 341, "Монтана"},              /* от 320 до 341 */
            { 377, "Пазарджик"},            /* от 342 до 377 */
            { 395, "Перник"},               /* от 378 до 395 */
            { 435, "Плевен"},               /* от 396 до 435 */
            { 501, "Пловдив"},              /* от 436 до 501 */
            { 527, "Разград"},              /* от 502 до 527 */
            { 555, "Русе"},                 /* от 528 до 555 */
            { 575, "Силистра"},             /* от 556 до 575 */
            { 601, "Сливен"},               /* от 576 до 601 */
            { 623, "Смолян"},               /* от 602 до 623 */
            { 721, "София - град"},         /* от 624 до 721 */
            { 751, "София - окръг"},        /* от 722 до 751 */
            { 789, "Стара Загора"},         /* от 752 до 789 */
            { 821, "Добрич (Толбухин)"},    /* от 790 до 821 */
            { 843, "Търговище"},            /* от 822 до 843 */
            { 871, "Хасково"},              /* от 844 до 871 */
            { 903, "Шумен"},                /* от 872 до 903 */
            { 925, "Ямбол"},                /* от 904 до 925 */
            { 999, "Друг/Неизвестен"},      /* от 926 до 999 - Такъв регион понякога се ползва при
                                                                родени преди 1900, за родени в чужбина
                                                                или ако в даден регион се родят повече
                                                                деца от предвиденото. */
        };

        public EgnInformation Extract(string egn)
        {
            var egnValidator = new EgnValidator();

            if (egnValidator.IsValid(egn) == false)
            {
                throw new ArgumentNullException("Invalid EGN provided", nameof(egn));
            }

            Sex sex = Sex.Unknown;

            if (int.Parse(egn[8].ToString()) % 2 == 0)
            {
                sex = Sex.Male;
            }
            else
            {
                sex = Sex.Female;
            }

            string placeOfBirth = string.Empty;
            int placeOfBirthCode = int.Parse(egn[6].ToString() + egn[7] + egn[8]);

            foreach (var city in this.cities)
            {
                if (placeOfBirthCode <= city.Key)
                {
                    placeOfBirth = city.Value;

                    break;
                }
            }

            int yearPart = int.Parse(egn.Substring(0, 2));
            int monthPart = int.Parse(egn.Substring(2, 2));
            int dayPart = int.Parse(egn.Substring(4, 2));

            int year = yearPart;
            int month = monthPart;
            int day = dayPart;

            if (monthPart >= 1 && monthPart <= 12)
            {
                // 1900 - 1999
                year = yearPart + 1900;
            }
            else if (monthPart >= 41 && monthPart <= 52)
            {
                // 2000 - 2099
                month = monthPart - 40;
                year = yearPart + 2000;
            }
            else if (monthPart >= 21 && monthPart <= 32)
            {
                // 1800 - 1899
                month = monthPart - 20;
                year = yearPart + 1800;
            }

            var dateOfBirth = new DateTime(year, month, day);

            return new EgnInformation(placeOfBirth, dateOfBirth, sex);
        }
    }
}