using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14HM
{
    public class Karta : IComparable<Karta>
    {
        public Suit Suit { get; }
        public Rank Rank { get; }
        public Karta(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
        public int CompareTo(Karta other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Rank.CompareTo(other.Rank);
        }
    }

}
