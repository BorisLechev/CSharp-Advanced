namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;

    public abstract class Player : IPlayer
    {
        private string username;

        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.INVALID_USERNAME);

                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.INVALID_HEALTH);

                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsBelowZero(damagePoints, ExceptionMessages.INVALID_PLAYER_DAMAGE_POINTS);

            this.Health = Math.Max(this.Health - damagePoints, 0);
        }

        public override string ToString()
        {
            return string.Format(
                ConstantMessages.PlayerReportInfo,
                this.Username,
                this.Health,
                this.CardRepository.Count);
        }
    }
}
