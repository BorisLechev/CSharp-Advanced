using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count => this.heroes.Count;

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = 
                this.heroes
                .FirstOrDefault(h => h.Name == name);

            this.heroes.Remove(hero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = 
                this.heroes
                .OrderByDescending(h => h.Item.Strength)
                .FirstOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = 
                this.heroes
                .OrderByDescending(h => h.Item.Ability)
                .FirstOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = 
                this.heroes
                .OrderByDescending(h => h.Item.Intelligence)
                .FirstOrDefault();

            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Hero hero in this.heroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString();
        }
    }
}
