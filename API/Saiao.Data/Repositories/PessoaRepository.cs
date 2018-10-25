using Saiao.Common.Exception;
using Saiao.Common.Resources;
using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using Saiao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class PessoaRepository : IRepositoryBase
    {
        private readonly SaiaoDataContext _db;
        public PessoaRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var pessoa = (Pessoa)classe;
            ValidaDuplicidade(pessoa);

            _db.Entry(pessoa).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return pessoa;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.Pessoas.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.Pessoas.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id) {
            _db.Pessoas.Remove(_db.Pessoas.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var pessoa = (Pessoa)classe;
            ValidaDuplicidade(pessoa);

            _db.Pessoas.Add(pessoa);
            _db.SaveChanges();

            return pessoa;
        }

        private void ValidaDuplicidade(Pessoa pessoa)
        {
            var result = (from item in _db.Pessoas
                          where item.CPF_CNPJ == pessoa.CPF_CNPJ && item.Id != pessoa.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new DuplicidadeRegistroException(ErrorMessage.RegistroDuplicado);
        }
    }
}
