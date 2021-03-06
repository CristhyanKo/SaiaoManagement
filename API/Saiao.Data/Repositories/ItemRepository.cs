﻿using Saiao.Common.Exception;
using Saiao.Common.Resources;
using Saiao.Data.DataContext;
using Saiao.Domain.Contract.Repositories;
using Saiao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saiao.Data.Repositories
{
    public class ItemRepository : IRepositoryBase
    {
        private readonly SaiaoDataContext _db;
        public ItemRepository(SaiaoDataContext context) => _db = context;

        public IRepositoryClassBase Alterar(IRepositoryClassBase classe)
        {
            var item = (Item)classe;
            ValidaDuplicidade(item);

            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            //_db.Entry(item.Fornecedor).State = System.Data.Entity.EntityState.Modified;
            //_db.Entry(item.Fornecedor.Pessoa).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return item;
        }

        public List<IRepositoryClassBase> Buscar() { return _db.Itens.ToList<IRepositoryClassBase>(); }
        public IRepositoryClassBase Buscar(Guid id) { return _db.Itens.FirstOrDefault(coluna => coluna.Id == id); }
        public void Dispose() => _db.Dispose();

        public void Excluir(Guid id)
        {
            _db.Itens.Remove(_db.Itens.Find(id));
            _db.SaveChanges();
        }

        public IRepositoryClassBase Incluir(IRepositoryClassBase classe)
        {
            var item = (Item)classe;

            ValidaDuplicidade(item);

            _db.Itens.Add(item);
            _db.SaveChanges();

            return item;
        }

        private void ValidaDuplicidade(Item itemClass)
        {
            var result = (from item in _db.Itens
                          where item.Descricao == itemClass.Descricao && item.Id != itemClass.Id
                          select item).FirstOrDefault();

            if (result != null)
                throw new DuplicidadeRegistroException(ErrorMessage.RegistroDuplicado);
        }
    }
}
