namespace PlayersAndMonsters.Common
{
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;

    public static class Validator
    {
        public static void ThrowIfIntegerIsBelowZero(int value, string message)
        {
            if (value < 0)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfStringIsNullOrEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfCardIsNull(ICard card, string message)
        {
            if (card == null)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfPlayerIsNull(IPlayer player, string message)
        {
            if (player == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
