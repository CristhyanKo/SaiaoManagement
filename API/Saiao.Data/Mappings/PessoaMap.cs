using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable(nameof(Pessoa));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.CPF_CNPJ).IsRequired();
            Property(coluna => coluna.Nome).HasMaxLength(150).IsRequired();
            Property(coluna => coluna.Sobrenome).HasMaxLength(255).IsRequired();
        }
    }
}
