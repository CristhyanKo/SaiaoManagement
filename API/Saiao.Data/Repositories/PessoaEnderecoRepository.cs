using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using Saiao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class PessoaEnderecoRepository : IRepositoryPessoaEndereco
    {
        private readonly SaiaoDataContext _db;
        public PessoaEnderecoRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var pessoaEndereco = (PessoaEndereco)classe;

            _db.Entry(pessoaEndereco).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return pessoaEndereco;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.PessoaEnderecos.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.PessoaEnderecos.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id) {
            _db.PessoaEnderecos.Remove(_db.PessoaEnderecos.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var pessoaEndereco = (PessoaEndereco)classe;

            _db.PessoaEnderecos.Add(pessoaEndereco);
            _db.SaveChanges();

            return pessoaEndereco;
        }

        public IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid enderecoId)
        {
            var enderecos = _db.PessoaEnderecos.Where(coluna => coluna.PessoaId == pessoaId).ToList();
            enderecos.ForEach(item => AlteraTagPrincipal(item, false));

            var endereco = _db.PessoaEnderecos.Find(enderecoId);
            AlteraTagPrincipal(endereco, true);

            return endereco;
        }

        private void AlteraTagPrincipal(PessoaEndereco pessoaEndereco, bool principal)
        {
            pessoaEndereco.Principal = principal;
            _db.Entry(pessoaEndereco).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
