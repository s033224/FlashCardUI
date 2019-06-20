using Flash_Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Cards.ViewModels
{
    public class CardPractice
    {
        public CardDeck deck { get; set; }

        public CardPractice(CardDeck deck)
        {
            this.deck = deck;
        }
    }
}
