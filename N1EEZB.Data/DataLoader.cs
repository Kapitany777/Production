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
                // Item Types
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

                // Items - Ice Creams
                context.Items.Add(
                    new Item
                    {
                        ItemCode = "I00001",
                        ItemName = "Cherry Ice Cream",
                        GTIN14 = "05991234500013",
                        ItemType = context.ItemTypes.SingleOrDefault(x => x.ItemTypeName == "Ice Cream")
                    });

                context.Items.Add(
                    new Item
                    {
                        ItemCode = "I00002",
                        ItemName = "Chocolate Ice Cream",
                        GTIN14 = "05991234500020",
                        ItemType = context.ItemTypes.SingleOrDefault(x => x.ItemTypeName == "Ice Cream")
                    });

                context.Items.Add(
                    new Item
                    {
                        ItemCode = "I00003",
                        ItemName = "Mango Ice Cream",
                        GTIN14 = "05991234500037",
                        ItemType = context.ItemTypes.SingleOrDefault(x => x.ItemTypeName == "Ice Cream")
                    });

                context.Items.Add(
                    new Item
                    {
                        ItemCode = "I00004",
                        ItemName = "Raspberry Ice Cream",
                        GTIN14 = "05991234500044",
                        ItemType = context.ItemTypes.SingleOrDefault(x => x.ItemTypeName == "Ice Cream")
                    });

                context.Items.Add(
                    new Item
                    {
                        ItemCode = "I00005",
                        ItemName = "Vanilla Ice Cream",
                        GTIN14 = "05991234500051",
                        ItemType = context.ItemTypes.SingleOrDefault(x => x.ItemTypeName == "Ice Cream")
                    });

                // Items - Chocolates
                context.Items.Add(
                    new Item
                    {
                        ItemCode = "C00001",
                        ItemName = "Dark Chocolate",
                        GTIN14 = "05991234500068",
                        ItemType = context.ItemTypes.SingleOrDefault(x => x.ItemTypeName == "Chocolate")
                    });

                context.Items.Add(
                    new Item
                    {
                        ItemCode = "C00002",
                        ItemName = "Milk Chocolate",
                        GTIN14 = "05991234500075",
                        ItemType = context.ItemTypes.SingleOrDefault(x => x.ItemTypeName == "Chocolate")
                    });

                context.Items.Add(
                    new Item
                    {
                        ItemCode = "C00003",
                        ItemName = "White Chocolate",
                        GTIN14 = "05991234500082",
                        ItemType = context.ItemTypes.SingleOrDefault(x => x.ItemTypeName == "Chocolate")
                    });

                context.SaveChanges();

                // Storages
                context.Storages.Add(
                    new Storage
                    {
                        StorageName = "Ice Cream Storage"
                    });

                context.Storages.Add(
                    new Storage
                    {
                        StorageName = "Chocolate Storage"
                    });

                context.SaveChanges();
            }
        }
    }
}
