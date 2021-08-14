using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Bombs
{
    public class Bomb
    {
        public Bomb(string name, int count)
        {
            this.Name = name;
            this.Count = count;
        }

        public string Name { get; set; }

        public int Damage { get; set; }

        public int Count { get; set; }
    }
}
