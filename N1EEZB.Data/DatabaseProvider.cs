using N1EEZB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace N1EEZB.Data
{
    /// <summary>
    /// Database operations
    /// </summary>
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

        #region Storage methods
        /// <summary>
        /// Get all storage data
        /// </summary>
        /// <returns>List of storages</returns>
        public IEnumerable<Storage> GetAllStorages()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.Storages.OrderBy(x => x.StorageId).ToList();
            }
        }

        /// <summary>
        /// Get all storage data, ordered by name
        /// </summary>
        /// <returns>List of storages</returns>
        public IEnumerable<Storage> GetAllStoragesOrdered()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.Storages.OrderBy(x => x.StorageName).ToList();
            }
        }
        #endregion

        #region Item type methods
        /// <summary>
        /// Get all item type data
        /// </summary>
        /// <returns>List of item types</returns>
        public IEnumerable<ItemType> GetAllItemTypes()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.ItemTypes.OrderBy(x => x.ItemTypeId).ToList();
            }
        }

        /// <summary>
        /// Get all item type data, ordered by name
        /// </summary>
        /// <returns>Ordered list of item types</returns>
        public IEnumerable<ItemType> GetAllItemTypesOrdered()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.ItemTypes.OrderBy(x => x.ItemTypeName).ToList();
            }
        }
        #endregion

        #region Item methods
        /// <summary>
        /// Add a new item
        /// </summary>
        /// <param name="item">The new item</param>
        public void AddItem(Item item)
        {
            // https://msdn.microsoft.com/en-us/magazine/dn166926.aspx
            using (DbProductionContext context = new DbProductionContext())
            {
                context.Entry(item.ItemType).State = EntityState.Unchanged;
                context.Items.Add(item);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Modify an existing item
        /// </summary>
        /// <param name="item">The item</param>
        public void ModifyItem(Item item)
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete an existing item
        /// </summary>
        /// <param name="item">The item</param>
        public void DeleteItem(Item item)
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                context.Items.Attach(item);
                context.Items.Remove(item);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get items list, ordered by name
        /// </summary>
        /// <returns>Ordered list of items</returns>
        public IEnumerable<Item> GetAllItemsOrdered()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                return context.Items.OrderBy(x => x.ItemName).ToList();
            }
        }

        /// <summary>
        /// Get items list, filtered by item type
        /// </summary>
        /// <param name="itemType">The item type</param>
        /// <returns>Ordered list of items</returns>
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

        /// <summary>
        /// Get item with a given GTIN-14
        /// </summary>
        /// <param name="GTIN14">GTIN-14</param>
        /// <returns>The item</returns>
        public Item GetItemByGTIN14(string GTIN14)
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                var result =
                    (from t in context.Items
                     where t.GTIN14 == GTIN14
                     select t).SingleOrDefault();

                return result;
            }
        }
        #endregion

        #region Production methods
        /// <summary>
        /// Add production data
        /// </summary>
        /// <param name="productionData">Production data</param>
        public void AddProduction(ProductionData productionData)
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                context.Entry(productionData.Item).State = EntityState.Unchanged;
                context.Entry(productionData.Storage).State = EntityState.Unchanged;
                context.ProductionDatas.Add(productionData);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get production list, filtered by item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>The list of productions</returns>
        public IEnumerable<ProductionData> GetProductionByItem(Item item)
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                var result =
                    (from t in context.ProductionDatas
                     where t.Item.ItemId == item.ItemId
                     orderby t.ProductionId
                     select t).ToList();

                return result;
            }
        }
        #endregion
    }
}
