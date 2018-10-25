using System;
using System.Collections.Generic;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryDefault
    {
        List<IRepositoryClass> Buscar();
        IRepositoryClass Buscar(Guid id);
        IRepositoryClass Incluir(IRepositoryClass classe);
        IRepositoryClass Alterar(IRepositoryClass classe);
        void Excluir(Guid id);
        void Dispose();
    }
}
