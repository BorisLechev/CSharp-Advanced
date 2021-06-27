using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    // Factory pattern
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            // Reflection
            Type playerType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            IPlayer player = Activator.CreateInstance(playerType, new CardRepository(), username) as IPlayer;

            return player;

            //IPlayer player = null;

            //switch (type)
            //{
            //    case "Beginner":
            //        player = new Beginner(name);
            //        break;
            //    case "Advanced":
            //        card = new Advanced(name);
            //        break;
            //    default:
            //        break;
            //}

            //return player;
        }
    }
}
