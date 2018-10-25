using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            ToTable(nameof(Cidade));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Descricao).IsRequired();
            Property(coluna => coluna.EstadoId).IsRequired();

            HasRequired(coluna => coluna.Estado);
        }
    }
}
