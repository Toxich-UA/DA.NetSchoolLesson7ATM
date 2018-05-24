using System.Data.Entity.ModelConfiguration;

namespace EFDbContext.Models.DbEntity.Context.Mappings
{
    internal class CardConfiguration : EntityTypeConfiguration<Cards>
    {

        public CardConfiguration()
        {
            ToTable("Cards", "dbo");
            HasKey(x => x.CardId);

            Property(x => x.CardId)
                .HasColumnName(@"CardId")
                .HasColumnType("char")
                .IsRequired()
                .IsFixedLength()
                .IsUnicode(false)
                .HasMaxLength(16)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ClientId)
                .HasColumnName(@"ClientID")
                .HasColumnType("int")
                .IsRequired();
            Property(x => x.PinCode)
                .HasColumnName(@"PinCode")
                .HasColumnType("char")
                .IsRequired()
                .IsFixedLength()
                .IsUnicode(false)
                .HasMaxLength(4);
            Property(x => x.Ballance)
                .HasColumnName(@"Ballance")
                .HasColumnType("money")
                .IsRequired()
                .HasPrecision(19, 4);
            

            // Foreign keys
            HasRequired(a => a.Client).WithMany(b => b.Cards).HasForeignKey(c => c.ClientId).WillCascadeOnDelete(false); // FK_Cards_Clients
            HasRequired(x => x.OperationDetails).WithRequiredPrincipal(x => x.Cards).Map(x=>x.MapKey("CardID"));

        }
    }
}