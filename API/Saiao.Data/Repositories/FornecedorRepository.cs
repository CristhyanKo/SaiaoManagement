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
    public class FornecedorRepository : IRepositoryBase
    {
        private readonly SaiaoDataContext _db;
        public FornecedorRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var fornecedor = (Fornecedor)classe;
            ValidaDuplicidade(fornecedor);

            _db.Entry(fornecedor).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return fornecedor;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.Fornecedores.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.Fornecedores.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id)
        {
            _db.Fornecedores.Remove(_db.Fornecedores.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var fornecedor = (Fornecedor)classe;

            ValidaDuplicidade(fornecedor);

            _db.Fornecedores.Add(fornecedor);
            _db.SaveChanges();

            return fornecedor;
        }

        private void ValidaDuplicidade(Fornecedor fornecedor)
        {
            var result = (from item in _db.Fornecedores
                          where item.PessoaId == fornecedor.PessoaId
                          && item.Descricao == fornecedor.Descricao
                          && item.Id != fornecedor.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new DuplicidadeRegistroException(ErrorMessage.RegistroDuplicado);
        }
    }
}
