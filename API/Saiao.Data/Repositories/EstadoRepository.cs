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
    public class EstadoRepository : IRepositoryBase
    {
        private readonly SaiaoDataContext _db;
        public EstadoRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var estado = (Estado)classe;
            ValidaDuplicidade(estado);

            _db.Entry(estado).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return estado;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.Estados.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.Estados.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id)
        {
            ExcluiDependencias(id);

            _db.Estados.Remove(_db.Estados.Find(id));
            _db.SaveChanges();
        }

        private void ExcluiDependencias(Guid id)
        {
            var listaCidades =_db.Cidades.Where(coluna => coluna.EstadoId == id).ToList();
            listaCidades.ForEach(item => _db.Cidades.Remove(item));

            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var estado = (Estado)classe;
            ValidaDuplicidade(estado);

            _db.Estados.Add(estado);
            _db.SaveChanges();

            return estado;
        }

        private void ValidaDuplicidade(Estado estado)
        {
            var result = (from item in _db.Estados
                          where item.Descricao == estado.Descricao
                          && item.Ibge == estado.Ibge
                          && item.Id != estado.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new DuplicidadeRegistroException(ErrorMessage.RegistroDuplicado);
        }
    }
}
