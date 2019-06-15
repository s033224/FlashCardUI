﻿using Flash_Cards.Model;
using Flash_Cards.ViewModels;
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
        private List<CardDeck> decks { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            decks = new List<CardDeck>();
        }

        private void CreateNewCardDeckEvent(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item.Name == "NewCardDeck" && item.IsSelected)
            {
                DataContext = new CardCreate();
                (DataContext as CardCreate).CloseThis += CloseDataContextWindow;
                (DataContext as CardCreate).SaveDeck += AddDeck;
            }
        }

        private void CloseDataContextWindow()
        {
            DataContext = null;
        }

        private void AddDeck(CardDeck deck)
        {
            decks.Add(deck);
            DeckList.Items.Add(deck);
        }
    }
}
