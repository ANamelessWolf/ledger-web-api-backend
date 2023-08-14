using Microsoft.EntityFrameworkCore;
using static Nameless.Ledger.BI.Context.CatalogueContext;
namespace Nameless.Ledger.BI
{
    public class NamelessBIContext : DbContext
    {
        private readonly string _connectionString = "";

        public NamelessBIContext(DbContextOptions<NamelessBIContext> options)
         : base(options)
        {

        }

        public NamelessBIContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(_connectionString,
                providerOptions => providerOptions.CommandTimeout(60)).EnableSensitiveDataLogging(true);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            //Catalogos
            modelBuilder.CreateFinancingEntityContext();
            modelBuilder.CreateCreditCardContext();
            //Tablas
            //Views
            base.OnModelCreating(modelBuilder);
        }

    }
}