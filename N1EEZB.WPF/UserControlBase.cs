using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using N1EEZB.Data;

namespace N1EEZB.WPF
{
    public class UserControlBase : UserControl
    {
        #region Properties
        protected DatabaseProvider databaseProvider { get; set; }
        #endregion

        #region Constructors
        public UserControlBase() { }

        public UserControlBase(DatabaseProvider databaseProvider)
        {
            this.databaseProvider = databaseProvider;
        }
        #endregion
    }
}
