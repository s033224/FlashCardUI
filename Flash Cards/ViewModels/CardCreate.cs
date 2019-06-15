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
        public CardCreate()
        {

        }
    }
}
