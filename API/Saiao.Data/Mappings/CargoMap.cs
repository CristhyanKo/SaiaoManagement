using Saiao.Domain.Model;
using System.Data.Entity.ModelConfiguration;

namespace Saiao.Data.Mappings
{
    public class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            ToTable("Cargo");

            HasKey(coluna => coluna.Id);
            Property(coluna => coluna.Descricao).IsRequired();
        }
    }
}
