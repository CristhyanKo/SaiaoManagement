using System;
using System.Collections.Generic;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryBase
    {
        List<IRepositoryClassBase> Buscar();
        IRepositoryClassBase Buscar(Guid id);
        IRepositoryClassBase Incluir(IRepositoryClassBase classe);
        IRepositoryClassBase Alterar(IRepositoryClassBase classe);
        void Excluir(Guid id);
        void Dispose();
    }
}
