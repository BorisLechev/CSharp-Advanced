namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ViceCity.Common;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Guns;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;

    public class Controller : IController
    {
        private IList<IPlayer> civilPlayers;

        private GunRepository gunRepository;

        private MainPlayer tommy;

        private GangNeighbourhood neighbourhood;

        public Controller()
        {
            this.civilPlayers = new List<IPlayer>();
            this.gunRepository = new GunRepository();
            this.tommy = new MainPlayer();
            this.neighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;

            if (type == "Pistol")
            {
                gun = new Pistol(name);
            }

            else if (type == "Rifle")
            {
                gun = new Rifle(name);
            }

            else
            {
                return OutputMessages.INVALID_GUN;
            }

            this.gunRepository.Add(gun);

            return string.Format(OutputMessages.ADDED_GUN, name, type);
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepository.Models.Count == 0)
            {
                return OutputMessages.NO_GUNS_IN_THE_QUEUE;
            }

            IGun gun = this.gunRepository.Models.FirstOrDefault();

            if (name == "Vercetti")
            {
                this.tommy.GunRepository.Add(gun);
                this.gunRepository.Remove(gun);

                return string.Format(OutputMessages.ADDED_VECETTIS_GUN, gun.Name);
            }

            IPlayer civilPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);

            if (civilPlayer == null)
            {
                return OutputMessages.CIVIL_PLAYER_DOES_NOT_EXISTS;
            }

            civilPlayer.GunRepository.Add(gun);
            this.gunRepository.Remove(gun);

            return string.Format(OutputMessages.ADDED_GUN_SUCCESSFULLY, gun.Name, civilPlayer.Name);
        }

        public string AddPlayer(string name)
        {
            CivilPlayer civilPlayer = new CivilPlayer(name);

            this.civilPlayers.Add(civilPlayer);

            return string.Format(OutputMessages.ADDED_CIVIL_PLAYER, name);
        }

        public string Fight()
        {
            int tommysHealthBeforeFight = this.tommy.LifePoints;
            bool isEverybodyFine = true;
            this.neighbourhood.Action(this.tommy, this.civilPlayers);

            if (!this.civilPlayers.Any(cp => cp.IsAlive) || this.civilPlayers.Any(cp => cp.LifePoints != 50))
            {
                isEverybodyFine = false;
            }

            if (isEverybodyFine && tommysHealthBeforeFight == this.tommy.LifePoints)
            {
                return OutputMessages.IF_TOMMY_HAS_ALL_OF_HIS_POINTS;
            }

            else
            {
                StringBuilder sb = new StringBuilder();

                int deadCivilPlayersCount = this.civilPlayers
                    .Where(cp => cp.LifePoints == 0)
                    .Count();

                int civilPlayersCount = this.civilPlayers
                    .Where(cp => cp.IsAlive)
                    .Count();

                sb
                    .AppendLine("A fight happened:")
                    .AppendLine($"Tommy live points: {this.tommy.LifePoints}!")
                    .AppendLine($"Tommy has killed: {deadCivilPlayersCount} players!")
                    .AppendLine($"Left Civil Players: {civilPlayersCount}!");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
