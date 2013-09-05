using PsyTrance.DataLayer.Models;

namespace PsyTrance.DataLayer
{
    public class MySqlDbContext : System.Data.Entity.DbContext
    {
        public MySqlDbContext()
            : base("MySqlDbContext")
        {
            Configuration.AutoDetectChangesEnabled = false;
        }
    }
}