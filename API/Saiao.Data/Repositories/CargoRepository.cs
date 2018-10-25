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
    public class CargoRepository : IRepositoryBase
    {
        private readonly SaiaoDataContext _db;
        public CargoRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var cargo = (Cargo)classe;
            ValidaDuplicidade(cargo);

            _db.Entry(cargo).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return cargo;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.Cargos.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.Cargos.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id) {
            _db.Cargos.Remove(_db.Cargos.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var cargo = (Cargo)classe;
            ValidaDuplicidade(cargo);

            _db.Cargos.Add(cargo);
            _db.SaveChanges();

            return cargo;
        }

        private void ValidaDuplicidade(Cargo cargo)
        {
            var result = (from item in _db.Cargos
                          where item.Descricao == cargo.Descricao && item.Id != cargo.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new DuplicidadeRegistroException(ErrorMessage.RegistroDuplicado);
        }
    }
}
