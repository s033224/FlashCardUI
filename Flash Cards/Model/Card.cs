using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Cards.Model
{
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

        public override string ToString()
        {
            return front + "  |  " + back;
        }

        public Card Copy()
        {
            Card card = new Card();
            card.front = front;
            card.back = back;
            return card;
        }
    }
}
