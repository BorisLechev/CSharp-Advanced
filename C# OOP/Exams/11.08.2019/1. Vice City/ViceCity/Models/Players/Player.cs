namespace ViceCity.Models.Players
{
    using System;
    using ViceCity.Common;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;
    using ViceCity.Repositories.Contracts;

    public abstract class Player : IPlayer
    {
        private string name;

        private int lifePoints;

        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
            this.GunRepository = new GunRepository();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.PlayerNameIsNull(value, ExceptionMessages.INVALID_PLAYER_NAME);

                this.name = value;
            }
        }

        public bool IsAlive => this.LifePoints > 0;

        public IRepository<IGun> GunRepository { get; }

        public int LifePoints
        {
            get
            {
                return this.lifePoints;
            }

            private set
            {
                Validator.ValueIsLowerThanZero(value, ExceptionMessages.INVALID_LIFE_POINTS);

                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            if (this.LifePoints > points)
            {
                this.LifePoints -= points;
            }

            else
            {
                this.LifePoints = 0;
            }
        }
    }
}
