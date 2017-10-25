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
using N1EEZB.GS1Barcodes;
using N1EEZB.MessageBoxes;

namespace N1EEZB.WPF
{
    /// <summary>
    /// Interaction logic for UserControlProduction.xaml
    /// </summary>
    public partial class UserControlProduction : UserControlBase
    {
        public UserControlProduction(DatabaseProvider databaseProvider) : base(databaseProvider)
        {
            InitializeComponent();

            ComboBoxStorage.ItemsSource = databaseProvider.GetAllStoragesOrdered();
            ComboBoxStorage.SelectedIndex = 0;
        }

        private void TextBlockLotNumber_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxBarcode.Focus();
        }

        private void HandleBarcode(string barcodeString)
        {
            try
            {
                GS1Barcode barcode = new GS1Barcode(barcodeString);

                Item item = databaseProvider.GetItemByGTIN14(barcode.GlobalTradeItemNumber);

                TextBlockItemCode.Text = item.ItemCode;
                TextBlockItemName.Text = item.ItemName;

                if (barcode.BestBeforeDate != DateTime.MinValue)
                {
                    TextBlockExpDate.Text = barcode.BestBeforeDate.ToString("D");
                }
                else if (barcode.ExpirationDate != DateTime.MinValue)
                {
                    TextBlockExpDate.Text = barcode.ExpirationDate.ToString("D");
                }
                else
                {
                    TextBlockExpDate.Text = string.Empty;
                }

                TextBlockLotNumber.Text = barcode.BatchOrLotNumber;

                Storage storage = ComboBoxStorage.SelectedItem as Storage;

                databaseProvider.AddProduction(
                    new ProductionData
                    {
                        GS1Barcode = TextBoxBarcode.Text,
                        Storage = storage,
                        Item = item,
                        Quantity = item.QuantityPerItem,
                        ProductionDate = DateTime.Now
                    }
                    );
            }
            catch (Exception ex)
            {
                WPFMessageBox.MsgError("Barcode Error!", ex.Message);
            }
        }

        private void TextBoxBarcode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxBarcode.Text))
            {
                HandleBarcode(TextBoxBarcode.Text);
                TextBoxBarcode.Clear();
                TextBoxBarcode.Focus();
            }
        }

        private void TextBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                if (!string.IsNullOrEmpty(TextBoxBarcode.Text))
                {
                    HandleBarcode(TextBoxBarcode.Text);
                    TextBoxBarcode.Clear();
                    TextBoxBarcode.Focus();
                }
            }
        }
    }
}
