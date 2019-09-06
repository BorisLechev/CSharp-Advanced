namespace ViceCity.Models.Guns
{
    using ViceCity.Models.Guns.Contracts;

    public class Rifle : Gun, IGun
    {
        private const int BULLETS_PER_BARREL = 50;

        private const int TOTAL_BULLETS = 500;

        private const int BULLETS_PER_SHOOT = 5;

        public Rifle(string name)
          : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel == 0)
            {
                if (this.TotalBullets > BULLETS_PER_BARREL)
                {
                    this.BulletsPerBarrel = BULLETS_PER_BARREL;
                    this.TotalBullets -= this.BulletsPerBarrel;
                }

                else
                {
                    this.BulletsPerBarrel = this.TotalBullets;
                    this.TotalBullets -= this.BulletsPerBarrel;
                }
            }

            if (BULLETS_PER_SHOOT > this.BulletsPerBarrel)
            {
                int bulletsToReturn = this.BulletsPerBarrel;

                this.BulletsPerBarrel = 0;

                return bulletsToReturn;
            }

            this.BulletsPerBarrel -= BULLETS_PER_SHOOT;

            return BULLETS_PER_SHOOT;
        }
    }
}
