using Saiao.Common.Resources;
using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using Saiao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class SaiaoItemRepository : IRepositoryDefault
    {
        private readonly SaiaoDataContext _db;
        public SaiaoItemRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClass Alterar(IRepositoryClass classe)
        {
            var saiaoItem = (SaiaoItem)classe;
            ValidaDuplicidade(saiaoItem);

            _db.Entry(saiaoItem).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return saiaoItem;
        }

        public List<IRepositoryClass> Buscar() { return _db.SaiaoItems.ToList<IRepositoryClass>(); }
        public IRepositoryClass Buscar(Guid id) { return _db.SaiaoItems.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id)
        {
            _db.SaiaoItems.Remove(_db.SaiaoItems.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClass Incluir(IRepositoryClass classe)
        {
            var saiaoItem = (SaiaoItem)classe;
            ValidaDuplicidade(saiaoItem);

            _db.SaiaoItems.Add(saiaoItem);
            _db.SaveChanges();

            return saiaoItem;
        }

        private void ValidaDuplicidade(SaiaoItem saiaoItem)
        {
            var result = (from item in _db.SaiaoItems
                          where (item.ItemId == saiaoItem.ItemId 
                          && item.Quantidade == saiaoItem.Quantidade
                          && item.SaiaoId == saiaoItem.SaiaoId)
                          && item.Id != saiaoItem.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new Exception(ErrorMessage.RegistroDuplicado);
        }
    }
}
