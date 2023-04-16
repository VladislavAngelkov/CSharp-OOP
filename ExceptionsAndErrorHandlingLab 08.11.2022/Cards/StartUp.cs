namespace Cards
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Card> cards = new List<Card>();
            string[] cardsInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var card in cardsInfo)
            {
                string[] currentCardInfo = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string face = currentCardInfo[0];
                string suit = currentCardInfo[1];

                try
                {
                    Card currentCard = new Card(face, suit);
                    cards.Add(currentCard);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }

    public class Card
    {
        private readonly List<string> faces = new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly Dictionary<string, string> suits = new Dictionary<string, string>
        {
            { "S", "\u2660" },
            { "H", "\u2665" },
            { "D", "\u2666" },
            { "C", "\u2663" },
        };
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get { return face; } 
            set 
            {
                if (!faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                face = value;
            }
        }
        public string Suit
        {
            get { return suit; }
            set
            {
                if (!suits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }
                suit = value;
            }
        }

        public override string ToString()
        {
            return $"[{face}{suits[suit]}]";
        }
    }
}
