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
            decks = new List<CardDeck>();
            IDataConnection data = new DataConnectionImpl();
            AddDecks(data.GetCardDecks());
        }

        private void CloseDataContextWindow()
        {
            DataContext = null;
            DisplayWindow = null;
            DeckList.Items.Refresh();
            DeckList.IsEnabled = true;
        }

        private void AddDecks(List<CardDeck> temDecks)
        {
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

            DeckList.Items.Remove(DeckList.SelectedItem);
            DeckList.Items.Add(deck);
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            //if editing the item
            if(edit)
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

        private void ModeSwitch(object sender, RoutedEventArgs e)
        {
            CloseDataContextWindow();
            edit = !edit;

            if(edit)
            {
                ModeSwitching.Content = "MODE: EDIT";
            }else
            {
                ModeSwitching.Content = "MODE: PRACTICE";
            }
        }
    }
}
