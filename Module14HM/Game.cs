using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14HM
{
    public class Game
    {
        private List<Player> players;
        private List<Karta> deck;

        public Game(params string[] playerNames)
        {
            if (playerNames.Length < 2)
            {
                throw new ArgumentException("Для начала игры требуется два игрока.");
            }

            players = playerNames.Select(name => new Player(name)).ToList();
            InitializeDeck();
            ShuffleDeck();
            DealCards();
        }

        private void InitializeDeck()
        {
            deck = new List<Karta>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Karta(suit, rank));
                }
            }
        }

        private void ShuffleDeck()
        {
            Random random = new Random();
            deck = deck.OrderBy(card => random.Next()).ToList();
        }

        private void DealCards()
        {
            int cardsPerPlayer = deck.Count / players.Count;
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Hand.AddRange(deck.GetRange(i * cardsPerPlayer, cardsPerPlayer));
            }
        }

        public void Play()
        {
            while (players.Count > 1)
            {
                List<Karta> cardsInPlay = players.Select(player => player.Hand.First()).ToList();
                int maxRankIndex = cardsInPlay.IndexOf(cardsInPlay.Max());

                Player winner = players[maxRankIndex];
                Console.WriteLine($"{winner.Name} takes the cards:");

                foreach (var card in cardsInPlay)
                {
                    winner.Hand.Add(card);
                    Console.WriteLine(card);
                }

                players.ForEach(player => player.Hand.RemoveAt(0));

                if (players.Any(player => player.Hand.Count == 0))
                {
                    players.RemoveAll(player => player.Hand.Count == 0);
                }
            }

            Console.WriteLine($"{players[0].Name} выйграл!");
        }
    }
}
