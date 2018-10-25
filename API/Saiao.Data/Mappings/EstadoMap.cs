using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable(nameof(Estado));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Descricao).IsRequired();
        }
    }
}
