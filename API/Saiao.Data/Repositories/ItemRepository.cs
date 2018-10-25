using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saiao.Data.Repositories
{
    public class ItemRepository : IRepositoryDefault
    {
        private SaiaoDataContext _db;
        public ItemRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClass Alterar(IRepositoryClass classe)
        {
            throw new NotImplementedException();
        }

        public List<IRepositoryClass> Buscar()
        {
            throw new NotImplementedException();
        }

        public IRepositoryClass Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IRepositoryClass Incluir(IRepositoryClass classe)
        {
            throw new NotImplementedException();
        }
    }
}
