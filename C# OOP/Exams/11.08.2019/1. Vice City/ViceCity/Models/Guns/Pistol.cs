namespace ViceCity.Models.Guns
{
    using ViceCity.Models.Guns.Contracts;

    public class Pistol : Gun, IGun
    {
        private const int BULLETS_PER_BARREL = 10;

        private const int TOTAL_BULLETS = 100;

        private const int BULLETS_PER_SHOOT = 1;

        public Pistol(string name) 
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
