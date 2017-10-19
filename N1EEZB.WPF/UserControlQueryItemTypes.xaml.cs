using N1EEZB.Data;
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
    /// Interaction logic for UserControlQueryItemTypes.xaml
    /// </summary>
    public partial class UserControlQueryItemTypes : UserControlBase
    {
        public UserControlQueryItemTypes(DatabaseProvider databaseProvider) : base(databaseProvider)
        {
            InitializeComponent();

            DataGridMain.ItemsSource = databaseProvider.GetAllItemTypes();
        }
    }
}
