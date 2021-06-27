namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    // Factory pattern
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            // Reflection
            Type cardType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.StartsWith(type));

            ICard card = Activator.CreateInstance(cardType, name) as ICard;

            return card;

            //ICard card = null;

            //switch (type)
            //{
            //    case "Trap":
            //        card = new TrapCard(name);
            //        break;
            //    case "Magic":
            //        card = new MagicCard(name);
            //        break;
            //    default:
            //        break;
            //}

            //return card;
        }
    }
}
