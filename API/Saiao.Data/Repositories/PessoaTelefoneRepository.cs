using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using Saiao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class PessoaTelefoneRepository : IRepositoryBase
    {
        private readonly SaiaoDataContext _db;
        public PessoaTelefoneRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var pessoaTelefone = (PessoaTelefone)classe;

            _db.Entry(pessoaTelefone).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return pessoaTelefone;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.PessoaTelefones.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.PessoaTelefones.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id) {
            _db.PessoaTelefones.Remove(_db.PessoaTelefones.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var pessoaTelefone = (PessoaTelefone)classe;

            _db.PessoaTelefones.Add(pessoaTelefone);
            _db.SaveChanges();

            return pessoaTelefone;
        }

        public IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid telefoneId)
        {
            var telefones = _db.PessoaTelefones.Where(coluna => coluna.PessoaId == pessoaId).ToList();
            telefones.ForEach(item => AlteraTagPrincipal(item, false));

            var telefone = _db.PessoaTelefones.Find(telefoneId);
            AlteraTagPrincipal(telefone, true);

            return telefone;
        }

        private void AlteraTagPrincipal(PessoaTelefone pessoaTelefone, bool principal)
        {
            pessoaTelefone.Principal = principal;
            _db.Entry(pessoaTelefone).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
