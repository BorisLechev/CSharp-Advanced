namespace ViceCity.Models.Guns
{
    using ViceCity.Common;
    using ViceCity.Models.Guns.Contracts;

    public abstract class Gun : IGun
    {
        private string name;

        private int bulletsPerBarrel;

        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                Validator.GunNameIsNull(value, ExceptionMessages.INVALID_GUN_NAME);

                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get
            {
                return this.bulletsPerBarrel;
            }

            protected set
            {
                Validator.ValueIsLowerThanZero(value, ExceptionMessages.INVALID_BULLETS_PER_BARREL);

                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get
            {
                return this.totalBullets;
            }

            protected set
            {
                Validator.ValueIsLowerThanZero(value, ExceptionMessages.INVALID_TOTAL_NUMBER_OF_BULLETS);

                this.totalBullets = value;
            }
        }

        public bool CanFire => this.TotalBullets > 0;

        public abstract int Fire();
    }
}
