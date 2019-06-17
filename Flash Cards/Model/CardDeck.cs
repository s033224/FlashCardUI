using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Cards.Model
{
    public class CardDeck
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
        

        /// <summary>
        /// This function is ment to return copy of deck
        /// </summary>
        /// <returns>Copy of deck</returns>
        public CardDeck Copy()
        {
            CardDeck deck = new CardDeck();

            deck.name = name;
            foreach(Card card in cards)
            {
                deck.cards.Add(card.Copy());
            }
            return deck;

        }


        /// <summary>
        /// Function sets deck to have same parameters as sent deck
        /// </summary>
        /// <param name="deck">Deck that you want to paste to calling deck</param>
        public void Paste(CardDeck deck)
        {
            name = deck.name;
            cards = deck.cards;
        }


        public override string ToString()
        {
            return name;
        }
    }
}
