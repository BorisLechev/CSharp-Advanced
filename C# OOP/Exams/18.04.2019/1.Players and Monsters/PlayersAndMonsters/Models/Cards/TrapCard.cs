namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class TrapCard : Card, ICard
    {
        private const int INITIAL_DAMAGE_POINTS = 120;

        private const int INITIAL_HEALTH_POINTS = 5;

        public TrapCard(string name) 
            : base(name, INITIAL_DAMAGE_POINTS, INITIAL_HEALTH_POINTS)
        {
        }
    }
}
