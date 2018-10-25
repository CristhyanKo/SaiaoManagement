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
    public class CidadeRepository : IRepositoryBase
    {
        private readonly SaiaoDataContext _db;
        public CidadeRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var cidade = (Cidade)classe;
            ValidaDuplicidade(cidade);

            _db.Entry(cidade).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return cidade;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.Cidades.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.Cidades.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id)
        {
            _db.Cidades.Remove(_db.Cidades.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var cidade = (Cidade)classe;
            ValidaDuplicidade(cidade);

            _db.Cidades.Add(cidade);
            _db.SaveChanges();

            return cidade;
        }

        private void ValidaDuplicidade(Cidade cidade)
        {
            var result = (from item in _db.Cidades
                          where item.Descricao == cidade.Descricao
                          && item.EstadoId == cidade.EstadoId
                          && item.Id != cidade.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new DuplicidadeRegistroException(ErrorMessage.RegistroDuplicado);
        }
    }
}
