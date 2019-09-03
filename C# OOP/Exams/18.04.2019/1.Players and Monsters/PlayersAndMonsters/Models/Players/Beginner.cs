namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class Beginner : Player, IPlayer
    {
        private const int BEGINNER_INITIAL_HEALTH = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, BEGINNER_INITIAL_HEALTH)
        {
        }
    }
}
