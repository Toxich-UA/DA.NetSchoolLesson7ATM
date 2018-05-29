using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDbContext.Models.DbEntity.Context.Mappings
{
    public class OperationsTypeConfiguration : EntityTypeConfiguration<OperationsType>
    {
        public OperationsTypeConfiguration()
        {
            ToTable("OperationsType", "dbo");
            HasKey(x => x.ID);

            Property(x => x.ID)
                .HasColumnName(@"ID")
                .HasColumnType("int")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Type)
                .HasColumnName(@"Type")
                .HasColumnType("char")
                .IsRequired()
                .IsFixedLength()
                .IsUnicode(false)
                .HasMaxLength(1);
        }
    }
}
