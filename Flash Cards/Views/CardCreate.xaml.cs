using Flash_Cards.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Flash_Cards.Views
{
    /// <summary>
    /// Interaction logic for CardCreate.xaml
    /// </summary>
    public partial class CardCreate : UserControl
    {
        
        public CardCreate()
        {
            InitializeComponent();
        }

        #region events
        private void CancelDeck_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to cancel?", "WARNING!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                (this.DataContext as ViewModels.CardCreate).CloseThis.Invoke();
            }
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(Front.Text) && !String.IsNullOrEmpty(Back.Text))
            {
                Card card = new Card(Front.Text, Back.Text);
                (DataContext as ViewModels.CardCreate).addCard(card);
                CardList.Items.Add(card);
                clearTextBox();
            }
        }


        private void AddDeck_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ViewModels.CardCreate).deck.name = CardDeckName.Text;
            (this.DataContext as ViewModels.CardCreate).saveThisDeck();
        }
        #endregion

        private void clearTextBox()
        {
            Front.Text = "";
            Back.Text = "";
        }
    }
}
