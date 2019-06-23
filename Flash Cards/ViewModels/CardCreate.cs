using Flash_Cards.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Flash_Cards.ViewModels
{
    public class CardCreate
    {
        public delegate void closeThis();
        public closeThis CloseThis;
        public delegate void saveDeck(CardDeck deck, List<int> cardsToDelete);
        public saveDeck SaveDeck;

        public bool _updating { get; set; }
        public CardDeck deck { get; set;}
        public CardDeck _initialDeck { get; set; }
        public List<int> cardsToDelete { get; set; }

        public CardCreate()
        {
            deck = new CardDeck();
            _updating = false;
            cardsToDelete = new List<int>();
        }

        public CardCreate(CardDeck deck)
        {
            this.deck = deck;
            _initialDeck = deck.Copy();
            _updating = true;
            cardsToDelete = new List<int>();
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
                    SaveDeck.Invoke(deck, cardsToDelete);
                    CloseThis.Invoke();
                }
                else
                    MessageBox.Show("Deck doesn't have a name", "Error!");
                
            }else
                MessageBox.Show("No cards in the deck", "Warning!");
        }
    }
}
