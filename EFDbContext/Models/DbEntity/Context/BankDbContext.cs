using System.Data.Entity;
using EFDbContext.Models.DbEntity.Context.Mappings;

namespace EFDbContext.Models.DbEntity.Context
{
    public class BankDbContext : DbContext, IBankContext
    {
        

        public BankDbContext() : base("Name=LocalATM")
        {
        }
        static BankDbContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BankDbContext>());
        }
        
        public IDbSet<Clients> Clients { get; set; }
        public IDbSet<Card> Cards { get; set; }
        public IDbSet<Addresses> Addresseses { get; set; }
        public IDbSet<Operations> Operations { get; set; }
        public IDbSet<OperationsDetails> OperationDetails { get; set; }
        public IDbSet<OperationsType> OperationsType { get; set; }

        public int Save()
        {
            return SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CardConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new OperationConfiguration());
            modelBuilder.Configurations.Add(new AddressesConfiguration());
            modelBuilder.Configurations.Add(new OperationDetailsConfiguration());
            modelBuilder.Configurations.Add(new OperationsTypeConfiguration());

        }
    }
}
