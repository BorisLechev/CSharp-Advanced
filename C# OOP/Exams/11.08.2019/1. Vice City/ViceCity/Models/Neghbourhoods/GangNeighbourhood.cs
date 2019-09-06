namespace ViceCity.Models.Neghbourhoods
{
    using System.Collections.Generic;
    using System.Linq;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (IPlayer civilPlayer in civilPlayers)
            {
                while (civilPlayer.IsAlive)
                {
                    var currentGun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

                    if (currentGun == null)
                    {
                        break;
                    }

                    while (currentGun.CanFire)
                    {
                        int lifePointsToTake = currentGun.Fire();

                        civilPlayer.TakeLifePoints(lifePointsToTake);
                    }
                }
            }

            foreach (IPlayer civilPlayer in civilPlayers.Where(cp => cp.IsAlive))
            {
                while (mainPlayer.IsAlive)
                {
                    var currentGun = civilPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire);

                    if (currentGun == null)
                    {
                        break;
                    }

                    while (currentGun.CanFire)
                    {
                        int lifePointsToTake = currentGun.Fire();

                        mainPlayer.TakeLifePoints(lifePointsToTake);
                    }
                }
            }
        }
    }
}
