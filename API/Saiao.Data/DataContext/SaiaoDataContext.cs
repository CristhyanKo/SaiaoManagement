using Saiao.Data.Mappings;
using Saiao.Domain.Model;
using System.Data.Entity;

namespace Saiao.Data.DataContext
{
    public class SaiaoDataContext : DbContext
    {
        public SaiaoDataContext() : base("SaiaoConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Domain.Model.Saiao> Saioes { get; set; }
        public DbSet<SaiaoItem> SaiaoItems { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new SaiaoMap());
            modelBuilder.Configurations.Add(new SaiaoItemMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
