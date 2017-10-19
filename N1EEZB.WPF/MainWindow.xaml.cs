using N1EEZB.Data;
using N1EEZB.WpfControlLibrary;
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

namespace N1EEZB.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowClass
    {
        private DatabaseProvider databaseProvider;

        public MainWindow()
        {
            InitializeComponent();

            databaseProvider = new DatabaseProvider();
        }

        private void MenuQueryStorages_Click(object sender, RoutedEventArgs e)
        {
            ContentControlMain.Content = new UserControlQueryStorages(databaseProvider);
        }

        private void MenuQueryItemTypes_Click(object sender, RoutedEventArgs e)
        {
            ContentControlMain.Content = new UserControlQueryItemTypes(databaseProvider);
        }

        private void MenuCreateItem_Click(object sender, RoutedEventArgs e)
        {
            ContentControlMain.Content = new UserControlCreateItem(databaseProvider);
        }

        private void MenuModifyItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuQueryItems_Click(object sender, RoutedEventArgs e)
        {
            ContentControlMain.Content = new UserControlQueryItems(databaseProvider);
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            DialogAbout dialogAbout = new DialogAbout();
            dialogAbout.ShowDialog();
        }
    }
}
