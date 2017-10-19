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
    /// Interaction logic for UserControlCreateItem.xaml
    /// </summary>
    public partial class UserControlCreateItem : UserControlBase
    {
        public UserControlCreateItem(DatabaseProvider databaseProvider) : base(databaseProvider)
        {
            InitializeComponent();

            ComboBoxItemType.ItemsSource = databaseProvider.GetAllItemTypesOrdered();
            ComboBoxItemType.SelectedIndex = 0;
        }

        private bool CheckTextBoxes()
        {
            if (string.IsNullOrEmpty(TextBoxItemCode.Text))
            {
                WPFMessageBox.MsgError("Item Code is required!");
                return false;
            }

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

            return true;
        }

        private void CreateNewItem()
        {
            databaseProvider.AddItem(
                new Item
                {
                    ItemCode = TextBoxItemCode.Text,
                    ItemName = TextBoxItemName.Text,
                    GTIN14 = TextBoxGTIN14.Text,
                    ItemType = ComboBoxItemType.SelectedItem as ItemType
                }
                );
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckTextBoxes())
            {
                return;
            }

            try
            {
                CreateNewItem();

                TextBoxItemCode.Clear();
                TextBoxItemName.Clear();
                TextBoxGTIN14.Clear();
                ComboBoxItemType.SelectedIndex = 0;

                WPFMessageBox.MsgInfo("Item successfully created!");
            }
            catch (Exception ex)
            {
                WPFMessageBox.MsgError(ex.Message);
            }
        }
    }
}
