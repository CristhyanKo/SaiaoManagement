using Saiao.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class PessoaEnderecoMap : EntityTypeConfiguration<PessoaEndereco>
    {
        public PessoaEnderecoMap()
        {
            ToTable(nameof(PessoaEndereco));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(coluna => coluna.Cep).IsRequired();
            Property(coluna => coluna.Bairro).IsRequired();
            Property(coluna => coluna.Logradouro).IsRequired();
            Property(coluna => coluna.Numero).IsRequired();
            Property(coluna => coluna.Principal).IsRequired();
            Property(coluna => coluna.Complemento).IsRequired();
            Property(coluna => coluna.EstadoId).IsRequired();
            Property(coluna => coluna.CidadeId).IsRequired();

            HasRequired(coluna => coluna.Estado).WithMany().WillCascadeOnDelete(false);
            HasRequired(coluna => coluna.Cidade);
        }
    }
}
