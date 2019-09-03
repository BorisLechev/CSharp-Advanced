namespace PlayersAndMonsters.Common
{
    public class ExceptionMessages
    {
        public const string INVALID_USERNAME = "Player's username cannot be null or an empty string.";

        public const string INVALID_HEALTH = "Player's health bonus cannot be less than zero.";

        public const string INVALID_PLAYER_DAMAGE_POINTS = "Damage points cannot be less than zero.";

        public const string INVALID_CARD_NAME = "Card's name cannot be null or an empty string.";

        public const string INVALID_CARD_DAMAGE_POINTS = "Card's damage points cannot be less than zero.";

        public const string INVALID_CARD_HEALTH_POINTS = "Card's HP cannot be less than zero.";

        public const string DEAD_PLAYER = "Player is dead!";

        public const string NULL_CARD = "Card cannot be null!";

        public const string CARD_ALREADY_EXISTS = "Card {0} already exists!";

        public const string NULL_PLAYER = "Player cannot be null";

        public const string PLAYER_ALREADY_EXISTS = "Player {0} already exists!";

    }
}
