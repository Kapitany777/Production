namespace N1EEZB.Data
{
    using N1EEZB.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DbProductionContext : DbContext
    {
        // Your context has been configured to use a 'DbProductionContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'N1EEZB.Data.DbProductionContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbProductionContext' 
        // connection string in the application configuration file.
        public DbProductionContext()
            : base("name=DbProductionContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<ProductionData> ProductionDatas { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}