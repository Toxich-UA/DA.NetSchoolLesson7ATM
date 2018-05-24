using System.Data.Entity.ModelConfiguration;

namespace EFDbContext.Models.DbEntity.Context.Mappings
{
    internal class ClientConfiguration : EntityTypeConfiguration<Clients>
    {
        public ClientConfiguration()
        {
            ToTable("Clients", "dbo");
            HasKey(x => x.ClientId);

            Property(x => x.ClientId)
                .HasColumnName(@"ClientID")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName)
                .HasColumnName(@"FirstName")
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(x => x.LastName)
                .HasColumnName(@"LastName")
                .HasColumnType("nvarchar")
                .IsRequired()
                .HasMaxLength(50);
            Property(x => x.Birthday)
                .HasColumnName(@"Birthday")
                .HasColumnType("date")
                .IsRequired();
            Property(x => x.PhoneNamber)
                .HasColumnName(@"Phone")
                .HasColumnType("varchar")
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(20);
            HasRequired(x => x.Address).WithRequiredPrincipal(a => a.Client);
        }

    }
}