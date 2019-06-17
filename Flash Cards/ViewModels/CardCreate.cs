using Flash_Cards.Model;
using System;
using System.Windows;

namespace Flash_Cards.ViewModels
{
    public class CardCreate
    {
        public delegate void closeThis();
        public closeThis CloseThis;
        public delegate void saveDeck(CardDeck deck);
        public saveDeck SaveDeck;

        public bool _updating { get; set; }
        public CardDeck deck { get; set;}
        public CardDeck _initialDeck { get; set; }

        public CardCreate()
        {
            deck = new CardDeck();
            _updating = false;
        }

        public CardCreate(CardDeck deck)
        {
            this.deck = deck;
            _initialDeck = deck.Copy();
            _updating = true;
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
