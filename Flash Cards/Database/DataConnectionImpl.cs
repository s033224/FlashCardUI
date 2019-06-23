using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flash_Cards.Model;
using System.Data.SQLite;
using System.Configuration;
using System.Data;
using Dapper;

namespace Flash_Cards.Database
{
    public class DataConnectionImpl : IDataConnection
    {
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
        
        #region INSERT
        public CardDeck AddDeck(CardDeck deck)
        {
            Int64 lastId;
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                lastId = (Int64)connection.ExecuteScalar(@"INSERT into Deck(name) VALUES(@name); SELECT Last_Insert_Rowid();", deck);
            }

            deck.id = (int)lastId;  

            for (int i = 0; i < deck.cards.Count; i++)
            {
                deck.cards[i] = AddCard(deck, deck.cards[i]);
            }
            
            return deck;
        }

        public Card AddCard(CardDeck deck, Card card)
        {
            Int64 lastId;
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                lastId = (Int64)connection.ExecuteScalar($"INSERT INTO Card (front, back, DeckID) VALUES (@front, @back, {deck.id}); SELECT Last_Insert_Rowid();", card);
            }

            card = GetCard((int)lastId);

            return card;
        }
        #endregion
        #region SELECT
        public List<CardDeck> GetCardDecks()
        {
            IEnumerable<CardDeck> output;
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                output = connection.Query<CardDeck>("Select * From Deck");
            }

            foreach (CardDeck deck in output)
            {
                deck.cards = GetCards(deck.id);
            }
            
            return output.ToList();
        }

        public List<Card> GetCards(int ID)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<Card>($"Select ID, back, front From Card where DeckID = {ID}");
                return output.ToList();
            }
        }

        public Card GetCard(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                var output = connection.Query<Card>($"Select ID, back, front From Card where id = {id}");
                return output.FirstOrDefault();
            }
        }

        public CardDeck GetDeck(int id)
        {
            IEnumerable<CardDeck> output;
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                output = connection.Query<CardDeck>($"Select * From Deck where id = {id}");
            }

            output.FirstOrDefault().cards = GetCards(output.FirstOrDefault().id);
            
            return output.FirstOrDefault();
        }
        #endregion
        #region DELETE
        public void DeleteCard(int id)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Query($"DELETE FROM Card WHERE id = {id}");
            }
        }

        public void DeleteDeck(int id)
        {
            CardDeck deck = GetDeck(id);

            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Query($"DELETE FROM Deck WHERE id = {id}");
            }

            foreach(Card card in deck.cards)
            {
                DeleteCard(card.id);
            }
        }
        #endregion
        #region UPDATE
        public CardDeck UpdateDeck(CardDeck deck)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Query($"UPDATE Deck set name = @name where id = @id", deck);
            }

            return GetDeck((int)deck.id);
        }

        public Card UpdateCard(Card card)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Query($"UPDATE Card set Front = @front, Back = @back where id = @id", card);
            }

            return GetCard((int)card.id);
        }
        #endregion
    }
}
