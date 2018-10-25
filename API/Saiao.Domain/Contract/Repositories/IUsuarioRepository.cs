using Saiao.Domain.Model;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IUsuarioRepository : IRepositoryClassBase
    {
        void AutenticaUsuario(Usuario usuario);
    }
}
