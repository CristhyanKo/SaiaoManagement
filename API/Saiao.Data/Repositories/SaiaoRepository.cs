using Saiao.Common.Resources;
using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class SaiaoRepository : IRepositoryDefault
    {
        private readonly SaiaoDataContext _db;
        public SaiaoRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClass Alterar(IRepositoryClass classe)
        {
            var saiao = (Domain.Model.Saiao)classe;
            ValidaDuplicidade(saiao);

            _db.Entry(saiao).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return saiao;
        }

        public List<IRepositoryClass> Buscar() { return _db.Saioes.ToList<IRepositoryClass>(); }
        public IRepositoryClass Buscar(Guid id) { return _db.Saioes.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id)
        {
            ExcluiDependencias(id);

            _db.Saioes.Remove(_db.Saioes.Find(id));
            _db.SaveChanges();
        }

        private void ExcluiDependencias(Guid id)
        {
            var itensSaioes =_db.SaiaoItems.Where(coluna => coluna.SaiaoId == id).ToList();
            itensSaioes.ForEach(item => _db.SaiaoItems.Remove(item));

            _db.SaveChanges();
        }

        public IRepositoryClass Incluir(IRepositoryClass classe)
        {
            var saiao = (Domain.Model.Saiao)classe;
            ValidaDuplicidade(saiao);

            _db.Saioes.Add(saiao);
            _db.SaveChanges();

            return saiao;
        }

        private void ValidaDuplicidade(Domain.Model.Saiao saiao)
        {
            var result = (from item in _db.Saioes
                          where item.Data == saiao.Data 
                          && item.UsuarioId == saiao.UsuarioId
                          && item.Motivo == saiao.Motivo
                          && item.Id != saiao.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new Exception(ErrorMessage.RegistroDuplicado);
        }
    }
}
