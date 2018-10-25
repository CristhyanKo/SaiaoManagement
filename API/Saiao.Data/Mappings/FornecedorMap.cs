using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable(nameof(Cargo));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.PessoaId).IsRequired();
            Property(coluna => coluna.Descricao).IsRequired();

            HasRequired(coluna => coluna.Pessoa);
        }
    }
}
