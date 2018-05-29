using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDbContext.Models.DbEntity.Context.Mappings
{
    public class OperationDetailsConfiguration : EntityTypeConfiguration<OperationsDetails>
    {
        public OperationDetailsConfiguration()
        {
            ToTable("OperationsDetails", "dbo");
            HasKey(x => x.ID);
            
            Property(x => x.ID)
                .HasColumnName(@"ID")
                .HasColumnType("bigint")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Amount)
                .HasColumnName(@"Amount")
                .HasColumnType("money")
                .IsRequired();
            Property(x => x.Balance)
                .HasColumnName(@"Balance")
                .HasColumnType("money")
                .IsRequired();

            HasRequired(x => x.OperationsType).WithMany(x => x.OperationDetails).Map(x => x.MapKey("OperationType"));
            HasRequired(x => x.Operations).WithMany(x => x.OperationDetailses).Map(x => x.MapKey("OperationID"));

        }
    }
}
