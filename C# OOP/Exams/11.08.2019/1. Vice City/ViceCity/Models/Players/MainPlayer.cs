namespace ViceCity.Models.Players
{
    using ViceCity.Models.Players.Contracts;

    public class MainPlayer : Player, IPlayer
    {
        private const int INITIAL_LIFE_POINTS = 100;

        private const string MAIN_PLAYER_NAME = "Tommy Vercetti";

        public MainPlayer() 
            : base(MAIN_PLAYER_NAME, INITIAL_LIFE_POINTS)
        {
        }
    }
}
