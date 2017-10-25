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
using N1EEZB.Data;
using N1EEZB.Data.Models;
using N1EEZB.MessageBoxes;

namespace N1EEZB.WPF
{
    /// <summary>
    /// Interaction logic for UserControlQueryProduction.xaml
    /// </summary>
    public partial class UserControlQueryProduction : UserControlBase
    {
        public UserControlQueryProduction(DatabaseProvider databaseProvider) : base(databaseProvider)
        {
            InitializeComponent();

            ComboBoxItems.ItemsSource = databaseProvider.GetAllItemsOrdered();
            ComboBoxItems.SelectedIndex = 0;
        }

        private void ComboBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Item item = ComboBoxItems.SelectedItem as Item;
                DataGridMain.ItemsSource = databaseProvider.GetProductionByItem(item);
            }
            catch (Exception ex)
            {
                WPFMessageBox.MsgError($"Error: {ex.Message}");
            }
        }
    }
}
