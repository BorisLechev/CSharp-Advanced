namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private IDictionary<string, ICard> cardsByName;

        public CardRepository()
        {
            this.cardsByName = new Dictionary<string, ICard>();
        }

        public int Count => this.cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardsByName.Values.ToList();

        public void Add(ICard card)
        {
            Validator.ThrowIfCardIsNull(card, ExceptionMessages.NULL_CARD);

            if (this.cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException(String.Format(
                    ExceptionMessages.CARD_ALREADY_EXISTS,
                    card.Name)
                    );
            }

            this.cardsByName.Add(card.Name, card);
        }


        public ICard Find(string name)
        {
            ICard card = null;

            if (this.cardsByName.ContainsKey(name))
            {
                card = this.cardsByName[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            Validator.ThrowIfCardIsNull(card, ExceptionMessages.NULL_CARD);

            return this.cardsByName.Remove(card.Name);
        }
    }
}
