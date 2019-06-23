using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Cards.Model
{
    /// <summary>
    /// Card model, used for storing information about a card
    /// </summary>
    public class Card
    {

        public int id { get; set; }
        public string back { get; set; }
        public string front { get; set; }
        

        public Card()
        {
            front = "";
            back = "";
        }

        public Card(string front, string back)
        {
            this.front = front;
            this.back = back;
        }

        /// <summary>
        /// Converts Card to string
        /// </summary>
        /// <returns>Card Front  | Back</returns>
        public override string ToString()
        {
            return front + "  |  " + back;
        }


        /// <summary>
        /// Copies card information and returns it as different object (different pointer)
        /// </summary>
        /// <returns>Copy of a card</returns>
        public Card Copy()
        {
            Card card = new Card();
            card.front = front;
            card.back = back;
            return card;
        }
    }
}
