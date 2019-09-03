namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;

    public abstract class Card : ICard
    {
        private string name;

        private int damagePoints;

        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.INVALID_CARD_NAME);

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return this.damagePoints;
            }

            set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.INVALID_CARD_DAMAGE_POINTS);

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            private set
            {
                Validator.ThrowIfIntegerIsBelowZero(value, ExceptionMessages.INVALID_CARD_HEALTH_POINTS);

                this.healthPoints = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                ConstantMessages.CardReportInfo,
                this.Name,
                this.DamagePoints);
        }
    }
}
