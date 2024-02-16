using in_memory_InvestFund.DataBase.Tables;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace in_memory_InvestFund
{
    public class DataBaseInvestFund : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Investments> Investments { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder()
                {
                    DataSource = "InvestDataBase.sqlite"
                };
                var connectionString = connectionStringBuilder.ToString();
                var connection = new SqliteConnection(connectionString);

                optionsBuilder.UseSqlite(connection);
            }
        }
    }
}
