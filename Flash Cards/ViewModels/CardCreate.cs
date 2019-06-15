using Flash_Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flash_Cards.ViewModels
{
    class CardCreate
    {
        public delegate void closeThis();
        public closeThis CloseThis;
        public delegate void saveDeck(CardDeck deck);
        public saveDeck SaveDeck;

        public CardDeck deck { get; set; }

        public CardCreate()
        {
            deck = new CardDeck();
        }

        public void addCard(Card card)
        {
            deck.AddCard(card); 
        }

        public void saveThisDeck()
        {
            if(deck.cards.Count > 0)
            {
                if (!String.IsNullOrEmpty(deck.name))
                {
                    SaveDeck.Invoke(deck);
                    CloseThis.Invoke();
                }
                else
                    MessageBox.Show("Deck doesn't have a name", "Error!");
                
            }else
                MessageBox.Show("No cards in the deck", "Warning!");
        }
    }
}
