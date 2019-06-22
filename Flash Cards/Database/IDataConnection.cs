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
        CardDeck AddDeck(CardDeck deck);
        Card AddCard(CardDeck deck, Card card);

        void DeleteDeck(int id);
        void DeleteCard(int id);

        Card GetCard(int id);
        CardDeck GetDeck(int id);
        List<CardDeck> GetCardDecks();
        List<Card> GetCards(int ID);

        CardDeck UpdateDeck(CardDeck deck);
        Card UpdateCard(Card card);
    }
}
