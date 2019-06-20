using Flash_Cards.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flash_Cards.Views
{
    /// <summary>
    /// Interaction logic for CardPractice.xaml
    /// </summary>
    public partial class CardPractice : UserControl
    {
        private ViewModels.CardPractice _base { get; set; }
        private int cardID { get; set; }
        private bool isFront { get; set; }

        public CardPractice()
        {
            InitializeComponent();
            isFront = true;
            cardID = 0;
        }

        #region events
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //get base view model
            _base = DataContext as ViewModels.CardPractice;

            setCard(_base.deck.cards[cardID]);

        }

        private void CardBox_Click(object sender, RoutedEventArgs e)
        {
            flipCard();
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            goRight();
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            goLeft();
        }
        #endregion

        private void flipCard()
        {
            isFront = !isFront;
            setCard(_base.deck.cards[cardID]);
        }

        private void setCard(Card card)
        {
            if (isFront)
            {
                CardBoxBack.Visibility = Visibility.Hidden;
                CardBoxFront.Visibility = Visibility.Visible;

                CardBoxFront.Content = card.front;
            }
            else
            {
                CardBoxBack.Visibility = Visibility.Visible;
                CardBoxFront.Visibility = Visibility.Hidden;

                CardBoxBack.Content = card.back;
            }
        }

        private void goRight()
        {
            cardID++;
            if (cardID > _base.deck.cards.Count - 1)
                cardID = 0;

            setCard(_base.deck.cards[cardID]);
        }

        private void goLeft()
        {
            cardID--;
            if (cardID < 0)
                cardID = _base.deck.cards.Count - 1;

            setCard(_base.deck.cards[cardID]);
        }
    }
}
