using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using Saiao.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class CargoRepository : IRepositoryDefault
    {
        private SaiaoDataContext _db;
        public CargoRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClass Alterar(IRepositoryClass classe)
        {
            var cargo = (Cargo)classe; // Usar uma interface vazia e fazer coverão explicita ou usar generics e fazer reflection para a conversão ???
            //ValidaClasse
            //ValidaDuplicidade

            _db.Entry(cargo).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return cargo;
        }

        public List<IRepositoryClass> Buscar() { return _db.Cargos.ToList<IRepositoryClass>(); }
        public IRepositoryClass Buscar(int id) { return _db.Cargos.FirstOrDefault(coluna => coluna.Id == id); }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Excluir(int id) {
            _db.Cargos.Remove(_db.Cargos.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClass Incluir(IRepositoryClass classe)
        {
            var cargo = (Cargo)classe;
            //ValidaClasse
            //ValidaDuplicidade

            _db.Cargos.Add(cargo);
            _db.SaveChanges();

            return cargo;
        }
    }
}
