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
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaEmail> PessoaEmails { get; set; }
        public DbSet<PessoaEndereco> PessoaEnderecos { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefones { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CargoMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new SaiaoMap());
            modelBuilder.Configurations.Add(new SaiaoItemMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new PessoaEnderecoMap());
            modelBuilder.Configurations.Add(new PessoaTelefoneMap());
            modelBuilder.Configurations.Add(new PessoaEmailMap());
            modelBuilder.Configurations.Add(new FornecedorMap());
            modelBuilder.Configurations.Add(new CidadeMap());
            modelBuilder.Configurations.Add(new EstadoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
