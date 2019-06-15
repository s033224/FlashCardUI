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

        private void CancelDeck_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to cancel?", "WARNING!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                (this.DataContext as ViewModels.CardCreate).CloseThis.Invoke();
            }
        }
    }
}
