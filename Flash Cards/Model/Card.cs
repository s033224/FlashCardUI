using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flash_Cards.Model
{
    class Card
    {
        public string front { get; set; }
        public string back{ get; set; }
        public bool favorite { get; set; }

        public Card()
        {
            front = "";
            back = "";
            favorite = false;
        }

        public Card(string text, string answer)
        {
            this.front = text;
            this.back = answer;
            favorite = false;
        }
    }
}
