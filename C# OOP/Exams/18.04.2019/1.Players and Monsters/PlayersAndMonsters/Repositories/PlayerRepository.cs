namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> playersByName;

        public PlayerRepository()
        {
            this.playersByName = new Dictionary<string, IPlayer>();
        }

        public int Count => this.playersByName.Count;

        public IReadOnlyCollection<IPlayer> Players => this.playersByName.Values.ToList();

        public void Add(IPlayer player)
        {
            Validator.ThrowIfPlayerIsNull(player, ExceptionMessages.NULL_PLAYER);

            if (this.playersByName.ContainsKey(player.Username))
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.PLAYER_ALREADY_EXISTS,
                    player.Username)
                    );
            }

            this.playersByName.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;

            if (this.playersByName.ContainsKey(username))
            {
                player = this.playersByName[username];
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            Validator.ThrowIfPlayerIsNull(player, ExceptionMessages.NULL_PLAYER);

            return this.playersByName.Remove(player.Username);
        }
    }
}
