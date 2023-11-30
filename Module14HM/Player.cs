using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14HM
{
    public class Player
    {
        public string Name { get; }
        public List<Karta> Hand { get; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Karta>();
        }

        public void DisplayHand()
        {
            Console.WriteLine($"Рука {Name}':");
            foreach (var card in Hand)
            {
                Console.WriteLine(card);
            }
        }
    }
}
