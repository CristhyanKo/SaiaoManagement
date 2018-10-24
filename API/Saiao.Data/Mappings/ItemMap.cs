using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            ToTable(nameof(Item));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Descricao).IsRequired();
        }
    }
}
