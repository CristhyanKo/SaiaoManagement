using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable(nameof(Usuario));

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.PessoaId).IsRequired();
            Property(coluna => coluna.CargoId).IsRequired();
            Property(coluna => coluna.Senha).IsRequired();

            HasRequired(coluna => coluna.Cargo);
            HasRequired(coluna => coluna.Pessoa);
        }
    }
}
