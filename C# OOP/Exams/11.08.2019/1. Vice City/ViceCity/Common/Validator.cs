namespace ViceCity
{
    using System;

    public class Validator
    {
        public static void PlayerNameIsNull(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void GunNameIsNull(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValueIsLowerThanZero(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
