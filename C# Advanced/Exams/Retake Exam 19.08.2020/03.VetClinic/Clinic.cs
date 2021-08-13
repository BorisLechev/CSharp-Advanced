using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.VetClinic
{
    public class Clinic
    {
        private ICollection<Pet> pets;

        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Count
        {
            get => this.pets.Count;
        }

        public int Capacity { get; private set; }

        public void Add(Pet pet)
        {
            if (this.Count < this.Capacity)
            {
                this.pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.pets.FirstOrDefault(x => x.Name == name);

            if (pet != null)
            {
                this.pets.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = this.pets.OrderByDescending(x => x.Age).FirstOrDefault();

            return pet;
        }

        public string GetStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var item in this.pets)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
