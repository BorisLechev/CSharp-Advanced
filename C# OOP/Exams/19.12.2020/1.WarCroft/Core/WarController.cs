using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
	{
		private readonly IList<Item> items;
		private readonly IList<Character> characters;

		public WarController()
		{
			this.items = new List<Item>();
			this.characters = new List<Character>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

            switch (characterType)
            {
				case "Warrior":
					character = new Warrior(name);
					break;
				case "Priest":
					character = new Priest(name);
					break;
                default:
					string message = string.Format(ExceptionMessages.InvalidCharacterType, characterType);

					throw new ArgumentException(message);
            }

			this.characters.Add(character);

			string outputMessage = string.Format(SuccessMessages.JoinParty, name);

			return outputMessage;
        }

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = null;

			switch (itemName)
			{
				case "HealthPotion":
					item = new HealthPotion();
					break;
				case "FirePotion":
					item = new FirePotion();
					break;
				default:
					string message = string.Format(ExceptionMessages.InvalidItem, itemName);

					throw new ArgumentException(message);
			}

			this.items.Add(item);

			string outputMessage = string.Format(SuccessMessages.AddItemToPool, item);

			return outputMessage;
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

            if (this.characters.Any(c => c.Name == characterName) == false)
            {
				string message = string.Format(ExceptionMessages.CharacterNotInParty, characterName);

				throw new ArgumentException(message);
            }

            if (this.items.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}

			Character character = this.characters.SingleOrDefault(c => c.Name == characterName);
            Item lastItem = this.items.Last();

			this.items.RemoveAt(this.items.Count - 1);

			character.Bag.AddItem(lastItem);

			return string.Format(SuccessMessages.PickUpItem, characterName, lastItem.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			if (this.characters.Any(c => c.Name == characterName) == false)
			{
				string message = string.Format(ExceptionMessages.CharacterNotInParty, characterName);

				throw new ArgumentException(message);
			}

			Character character = this.characters.SingleOrDefault(c => c.Name == characterName);
			Item item = character.Bag.GetItem(itemName);

			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			var sortedCharacters = this.characters
				.OrderByDescending(c => c.IsAlive)
				.ThenByDescending(c => c.Health);

			StringBuilder sb = new StringBuilder();

			foreach (var character in sortedCharacters)
            {
				var status = character.IsAlive ? "Alive" : "Dead";

				sb.AppendLine(
					$"{character.Name} - " +
					$"HP: {character.Health}/{character.BaseHealth}," +
					$" AP: {character.Armor}/{character.BaseArmor}," +
					$" Status: {status}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Warrior attacker = this.characters
				.Where(c => c.GetType().Name == nameof(Warrior))
				.SingleOrDefault(c => c.Name == attackerName) as Warrior;

			Warrior receiver = this.characters
				.Where(c => c.GetType().Name == nameof(Warrior))
				.SingleOrDefault(c => c.Name == receiverName) as Warrior;

			if (attacker == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
			}

            if (receiver == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, receiverName);
			}

            if (this.characters.Where(c => c.GetType().Name == nameof(Warrior)).All(c => c.Name != attackerName))
            {
				throw new ArgumentException(ExceptionMessages.AttackFail, attackerName);
            }

			attacker.Attack(receiver);

			var message = $"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (receiver.IsAlive == false)
            {
				message += Environment.NewLine + $"{receiver.Name} is dead!";
			}

			return message;
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Priest healer = this.characters
				.Where(c => c.GetType().Name == nameof(Priest))
				.SingleOrDefault(c => c.Name == healerName) as Priest;

			Priest receiver = this.characters
				.Where(c => c.GetType().Name == nameof(Priest))
				.SingleOrDefault(c => c.Name == healingReceiverName) as Priest;

			if (healer == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
			}

			if (receiver == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healingReceiverName);
			}

            if (this.characters.Where(c => c.GetType().Name == nameof(Priest)).All(x => x.Name != healerName))
            {
				throw new ArgumentException(ExceptionMessages.HealerCannotHeal, healerName);
			}

			healer.Heal(receiver);

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
