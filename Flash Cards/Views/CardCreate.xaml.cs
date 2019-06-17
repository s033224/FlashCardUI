using Flash_Cards.Model;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Flash_Cards.Views
{
    /// <summary>
    /// Interaction logic for CardCreate.xaml
    /// </summary>
    public partial class CardCreate : UserControl
    {
        ViewModels.CardCreate _base;
        public CardCreate()
        {
            InitializeComponent();
        }

        #region events
        private void CancelDeck_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to cancel?", "WARNING!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if(_base._updating)
                    _base.deck.Paste(_base._initialDeck);
                _base.CloseThis.Invoke();
            }
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(Front.Text) && !String.IsNullOrEmpty(Back.Text))
            {
                if (CardList.SelectedItems.Count == 0)
                {
                    addCard(Front.Text, Back.Text);
                }else
                {
                    updateCard((CardList.SelectedItem as Card), Front.Text, Back.Text);
                    CardList.Items.Refresh();
                    CardList.SelectedItem = null;
                    AddCard.Content = "Add Card";
                }

                clearTextBox();
            }
        }

        private void AddDeck_Click(object sender, RoutedEventArgs e)
        {
            SaveDeck();
        }

        //if editing load deck
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //set base datacontext as cardcreate
            _base = DataContext as ViewModels.CardCreate;

            if ((this.DataContext as ViewModels.CardCreate)._updating)
                LoadDeck();
        }

        //prepare card for update
        private void ListViewItem_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            prepareCardToUpdate((ListViewItem)sender);
        }

        #endregion

        private void prepareCardToUpdate(ListViewItem sender)
        {
            AddCard.Content = "Update";
            Front.Text = ((sender).Content as Card).front;
            Back.Text =  ((sender).Content as Card).back;
        }

        private void clearTextBox()
        {
            //clear textboxes
            Front.Text = "";
            Back.Text = "";
        }

        private void addCard(string front, string back)
        {
            //add card to list
            Card card = new Card(front, back);
            _base.addCard(card);
            CardList.Items.Add(card);
        }

        private void updateCard(Card card, string front, string back)
        {
            //Set back and front of a card
            card.front = front;
            card.back = back;
        }
        
        private void LoadDeck()
        {
            //add cards to list
            foreach (Card card in _base.deck.cards)
                CardList.Items.Add(card);

            //set deck name
            CardDeckName.Text = _base.deck.name;

            //set add deck to update deck
            AddDeck.Content = "Update deck";
        }

        private void SaveDeck()
        {
            //set deck name
            _base.deck.name = CardDeckName.Text;
            //request to save the deck
            _base.saveThisDeck();
        }
       
    }
}
