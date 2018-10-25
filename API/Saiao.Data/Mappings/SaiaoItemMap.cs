using Saiao.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class SaiaoItemMap : EntityTypeConfiguration<SaiaoItem>
    {
        public SaiaoItemMap()
        {
            ToTable(nameof(SaiaoItem));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(coluna => coluna.ItemId).IsRequired();
            Property(coluna => coluna.Quantidade).IsRequired();
            Property(coluna => coluna.SaiaoId).IsRequired();

            HasRequired(coluna => coluna.Item);
            HasRequired(coluna => coluna.Saiao);
        }
    }
}
