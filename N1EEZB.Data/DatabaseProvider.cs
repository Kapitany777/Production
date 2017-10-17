using N1EEZB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.Data
{
    public class DatabaseProvider
    {
        #region Constructors
        public DatabaseProvider()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                if (!context.Database.Exists())
                {
                    context.Database.Initialize(true);

                    DataLoader.LoadDefaultData();
                }
            }
        }
        #endregion

        public IEnumerable<ItemType> GetAllItemTypes()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.ItemTypes.ToList();
            }
        }

        public IEnumerable<Storage> GetAllStorages()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.Storages.ToList();
            }
        }
    }
}
