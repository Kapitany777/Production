using N1EEZB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.Data
{
    public class DataLoader
    {
        public static void LoadDefaultData()
        {
            using (DbProductionContext context = new DbProductionContext())
            {
                context.ItemTypes.Add(
                    new ItemType
                    {
                        ItemTypeName = "Ice Cream"
                    });

                context.ItemTypes.Add(
                    new ItemType
                    {
                        ItemTypeName = "Chocolate"
                    });

                context.SaveChanges();

                context.Items.Add(
                    new Item
                    {
                        ItemCode = "T00001",
                        ItemName = "Chocolate Ice Cream",
                        GTIN14 = "05997099967220",
                        ItemType = context.ItemTypes.Single(x => x.ItemTypeName == "Ice Cream")
                    });

                context.SaveChanges();

                context.Storages.Add(
                    new Storage
                    {
                        StorageName = "Storage 1."
                    });

                context.SaveChanges();
            }
        }
    }
}
