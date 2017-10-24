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
    /// Interaction logic for UserControlModifyItem.xaml
    /// </summary>
    public partial class UserControlModifyItem : UserControlBase
    {
        public UserControlModifyItem(DatabaseProvider databaseProvider) : base(databaseProvider)
        {
            InitializeComponent();

            ComboBoxItem.ItemsSource = databaseProvider.GetAllItemsOrdered();
            ComboBoxItem.SelectedIndex = 0;
        }

        private void FillControls()
        {
            Item item = ComboBoxItem.SelectedItem as Item;

            if (item != null)
            {
                TextBlockItemCode.Text = item.ItemCode;
                TextBoxItemName.Text = item.ItemName;
                TextBoxGTIN14.Text = item.GTIN14;
                TextBoxQuantityPerItem.Text = item.QuantityPerItem.ToString();
            }
        }

        private void ComboBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillControls();
        }

        private bool CheckTextBoxes()
        {
            if (string.IsNullOrEmpty(TextBoxItemName.Text))
            {
                WPFMessageBox.MsgError("Item Name is required!");
                return false;
            }

            if (string.IsNullOrEmpty(TextBoxGTIN14.Text))
            {
                WPFMessageBox.MsgError("GTIN-14 is required!");
                return false;
            }

            if (string.IsNullOrEmpty(TextBoxQuantityPerItem.Text))
            {
                WPFMessageBox.MsgError("Quantity Per Item is required!");
                return false;
            }

            return true;
        }

        private void ButtonModify_Click(object sender, RoutedEventArgs e)
        {
            if (WPFMessageBox.MsgYesNo("Are you sure you want to modify this item?") == MessageBoxResult.No)
            {
                return;
            }

            if (!CheckTextBoxes())
            {
                return;
            }

            try
            {
                Item selectedItem = ComboBoxItem.SelectedItem as Item;
                selectedItem.ItemName = TextBoxItemName.Text;
                selectedItem.GTIN14 = TextBoxGTIN14.Text;
                selectedItem.QuantityPerItem = int.Parse(TextBoxQuantityPerItem.Text);
                databaseProvider.ModifyItem(selectedItem);

                WPFMessageBox.MsgInfo("Item successfully updated!");

                ComboBoxItem.ItemsSource = databaseProvider.GetAllItemsOrdered();
                ComboBoxItem.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WPFMessageBox.MsgError(ex.Message);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (WPFMessageBox.MsgYesNo("Are you sure you want to delete this item?") == MessageBoxResult.No)
            {
                return;
            }

            try
            {
                Item selectedItem = ComboBoxItem.SelectedItem as Item;
                databaseProvider.DeleteItem(selectedItem);

                WPFMessageBox.MsgInfo("Item successfully deleted!");

                ComboBoxItem.ItemsSource = databaseProvider.GetAllItemsOrdered();
                ComboBoxItem.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WPFMessageBox.MsgError(ex.Message);
            }
        }
    }
}
