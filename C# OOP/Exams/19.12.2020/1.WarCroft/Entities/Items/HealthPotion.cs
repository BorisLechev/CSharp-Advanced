using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int WEIGHT = 5;

        public HealthPotion() 
            : base(WEIGHT)
        {
        }

        public override void AffectCharacter(Character character)
        {
            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
