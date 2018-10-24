using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Nome).IsRequired();
            Property(coluna => coluna.Sobrenome).IsRequired();
            Property(coluna => coluna.Senha).IsRequired();
            Property(coluna => coluna.Email).IsRequired();
            Property(coluna => coluna.CargoId).IsRequired();

            HasRequired(coluna => coluna.Cargo);
        }
    }
}
