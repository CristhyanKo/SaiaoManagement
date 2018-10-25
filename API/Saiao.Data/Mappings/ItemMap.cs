using Saiao.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            ToTable(nameof(Item));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(coluna => coluna.Descricao).IsRequired();
            Property(coluna => coluna.FornecedorId).IsRequired();

            HasRequired(coluna => coluna.Fornecedor);
        }
    }
}
