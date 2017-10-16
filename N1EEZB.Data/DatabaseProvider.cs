using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1EEZB.Data
{
    public class DatabaseProvider
    {
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
    }
}
