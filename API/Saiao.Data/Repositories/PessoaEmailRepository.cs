using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using Saiao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class PessoaEmailRepository : IRepositoryPessoaEmail
    {
        private readonly SaiaoDataContext _db;
        public PessoaEmailRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var pessoaEmail = (PessoaEmail)classe;

            _db.Entry(pessoaEmail).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return pessoaEmail;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.PessoaEmails.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.PessoaEmails.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id) {
            _db.PessoaEmails.Remove(_db.PessoaEmails.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var pessoaEmail = (PessoaEmail)classe;

            _db.PessoaEmails.Add(pessoaEmail);
            _db.SaveChanges();

            return pessoaEmail;
        }

        public IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid emailId)
        {
            var emails = _db.PessoaEmails.Where(coluna => coluna.PessoaId == pessoaId).ToList();
            emails.ForEach(item => AlteraTagPrincipal(item, false));

            var email = _db.PessoaEmails.Find(emailId);
            AlteraTagPrincipal(email, true);

            return email;
        }

        private void AlteraTagPrincipal(PessoaEmail pessoaEmail, bool principal)
        {
            pessoaEmail.Principal = principal;
            _db.Entry(pessoaEmail).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
