using Saiao.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class PessoaTelefoneMap : EntityTypeConfiguration<PessoaTelefone>
    {
        public PessoaTelefoneMap()
        {
            ToTable(nameof(PessoaTelefone));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(coluna => coluna.DDD).IsRequired();
            Property(coluna => coluna.Telefone).IsRequired();
            Property(coluna => coluna.Principal).IsRequired();
            Property(coluna => coluna.PessoaId).IsRequired();

            HasRequired(coluna => coluna.Pessoa);
        }
    }
}
