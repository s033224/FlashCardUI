using Flash_Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Cards.Database
{
    public interface IDataConnection
    {
        CardDeck SaveDeck(CardDeck deck);
        CardDeck AddCard(CardDeck deck, Card card);
    }
}
