using Flash_Cards.Database;
using Flash_Cards.Model;
using Flash_Cards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flash_Cards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool edit = true;
        private List<CardDeck> decks { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            RecieveDecksFromDatabase();
        }

        #region EventHandle
        //On click of ListViewItem, Edit/Create new deck
        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            //if editing the item
            if (edit)
            {
                if (item.Name == "NewCardDeck" && item.IsSelected)
                {
                    openCreateNewDeck();
                }
                else
                {
                    if (DeckList.SelectedItem != null)
                    {
                        openEditDeck();
                    }
                }
            }
            //if using the item
            else
            {
                if (item.Name != "NewCardDeck")
                    setUpDeckPractice();
            }
        }

        //On Right click of ListViewItem, Delete Deck
        private void ListViewItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (((sender as ContentControl).Content as CardDeck) != null)
            {
                if (MessageBox.Show("Are you sure you want to delete deck?", "WARNING!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DeleteDeck(((sender as ContentControl).Content as CardDeck).id);
                    RecieveDecksFromDatabase();
                }
            }
        }

        //On Click Button, Switch mode to Edit|Practice
        private void ModeSwitch(object sender, RoutedEventArgs e)
        {
            CloseDataContextWindow();
            edit = !edit;

            if (edit)
            {
                ModeSwitching.Content = "MODE: EDIT";
            }
            else
            {
                ModeSwitching.Content = "MODE: PRACTICE";
            }
        }
        #endregion

        private void RecieveDecksFromDatabase()
        {
            decks = new List<CardDeck>();
            IDataConnection data = new DataConnectionImpl();
            AddDecks(data.GetCardDecks());
        }

        private void CloseDataContextWindow()
        {
            DataContext = null;
            DisplayWindow = null;
            RecieveDecksFromDatabase();
            DeckList.Items.Refresh();
            DeckList.IsEnabled = true;
        }

        private void AddDecks(List<CardDeck> temDecks)
        {
            ClearListView();
            foreach(CardDeck deck in temDecks)
            {
                DeckList.Items.Add(deck);
            }
            decks = temDecks;
        }

        private void AddDeck(CardDeck deck, List<int> cardsToDelete = null)
        {
            IDataConnection data = new DataConnectionImpl();
            decks.Add(data.AddDeck(deck));

            DeckList.Items.Add(deck);

            //update decks from database
            RecieveDecksFromDatabase();
        }

        private void DeleteDeck(int id)
        {
            IDataConnection data = new DataConnectionImpl();
            data.DeleteDeck(id);
        }

        private void updateDeck(CardDeck deck, List<int> cardsToDelete)
        {
            IDataConnection data = new DataConnectionImpl();

            if(cardsToDelete != null)
            {
                foreach (int cardID in cardsToDelete)
                {
                    data.DeleteCard(cardID);
                }
            }

            foreach(Card card in deck.cards)
            {
                if(card.id == 0)
                {
                    data.AddCard(deck, card);
                }
            }

            data.UpdateDeck(deck);

            RecieveDecksFromDatabase();
        }

        private void openEditDeck()
        {
            DataContext = new CardCreate((CardDeck)DeckList.SelectedItem);
            setUpDeckEditing(true);
        }

        private void openCreateNewDeck()
        {
            
            DataContext = new CardCreate();
            setUpDeckEditing(false);
        }

        private void setUpDeckEditing(bool editing)
        {
            DeckList.IsEnabled = false;
            (DataContext as CardCreate).CloseThis += CloseDataContextWindow;
            if(editing)
            {
                (DataContext as CardCreate).SaveDeck += updateDeck;
            }else
            {
                (DataContext as CardCreate).SaveDeck += AddDeck;
            }
            
        }

        private void setUpDeckPractice()
        {
            DeckList.IsEnabled = false;
            DataContext = new CardPractice((CardDeck)DeckList.SelectedItem);
        }

        private void ClearListView()
        {
            DeckList.Items.Clear();

            ListViewItem lvi = new ListViewItem();
            lvi.Content = "Create new card deck";
            lvi.Foreground = Brushes.Green;
            lvi.Name = "NewCardDeck";
            lvi.HorizontalAlignment = HorizontalAlignment.Center;

            DeckList.Items.Add(lvi);

            DeckList.Items.Refresh();
        }

        

    }
}
