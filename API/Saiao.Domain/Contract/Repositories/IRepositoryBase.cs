using System.Collections.Generic;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryDefault
    {
        List<IRepositoryClass> Buscar();
        IRepositoryClass Buscar(int id);
        IRepositoryClass Incluir(IRepositoryClass classe);
        IRepositoryClass Alterar(IRepositoryClass classe);
        void Excluir(int id);
        void Dispose();
    }
}
