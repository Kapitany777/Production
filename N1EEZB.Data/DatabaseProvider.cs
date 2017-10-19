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

        public IEnumerable<Storage> GetAllStorages()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.Storages.ToList();
            }
        }

        public IEnumerable<ItemType> GetAllItemTypes()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.ItemTypes.ToList();
            }
        }

        public IEnumerable<ItemType> GetAllItemTypesOrdered()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.ItemTypes.OrderBy(x => x.ItemTypeName).ToList();
            }
        }

        public void AddItem(Item item)
        {
            // https://msdn.microsoft.com/en-us/magazine/dn166926.aspx
            using (DbProductionContext context = new DbProductionContext())
            {
                context.Entry(item.ItemType).State = System.Data.Entity.EntityState.Unchanged;
                context.Items.Add(item);
                context.SaveChanges();
            }
        }

        public IEnumerable<Item> GetItemsByItemType(ItemType itemType)
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                var result =
                    (from t in context.Items
                     where t.ItemType.ItemTypeId == itemType.ItemTypeId
                     orderby t.ItemCode
                     select t).ToList();

                return result;
            }
        }
    }
}
