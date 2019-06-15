using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Cards.Model
{
    class CardDeck
    {
        public string name { get; set; }
        public List<Card> cards { get; set; }

        public CardDeck()
        {
            name = "";
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
