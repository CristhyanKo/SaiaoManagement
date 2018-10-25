using Saiao.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable(nameof(Fornecedor));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(coluna => coluna.PessoaId).IsRequired();
            Property(coluna => coluna.Descricao).IsRequired();

            HasRequired(coluna => coluna.Pessoa);
        }
    }
}
