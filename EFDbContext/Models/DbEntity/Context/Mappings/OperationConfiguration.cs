using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFDbContext.Models.DbEntity.Context.Mappings
{
    internal class OperationConfiguration : EntityTypeConfiguration<Operations>
    {
        public OperationConfiguration()
        {
            ToTable("Operations", "dbo");
            HasKey(x => x.OperationId);

            Property(x => x.OperationId)
                .HasColumnName(@"OperationID")
                .HasColumnType("bigint")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OutId)
                .HasColumnName(@"OutID")
                .HasColumnType("char")
                .IsRequired()
                .IsFixedLength()
                .IsUnicode(false)
                .HasMaxLength(16);
            Property(x => x.InId)
                .HasColumnName(@"InID")
                .HasColumnType("char")
                .IsRequired()
                .IsFixedLength()
                .IsUnicode(false)
                .HasMaxLength(16);
            Property(x => x.Amount)
                .HasColumnName(@"Amount")
                .HasColumnType("money")
                .IsRequired()
                .HasPrecision(19, 4);
            Property(x => x.OperationTime)
                .HasColumnName(@"OperationTime")
                .HasColumnType("datetime2")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            
            // Foreign keys
            HasRequired(a => a.InCard).WithMany(b => b.InOperations).HasForeignKey(c => c.InId).WillCascadeOnDelete(false); // FK_Operations_Cards1
            HasRequired(a => a.OutCard).WithMany(b => b.OutOperations).HasForeignKey(c => c.OutId).WillCascadeOnDelete(false); // FK_Operations_Cards
            
        }
    }
}