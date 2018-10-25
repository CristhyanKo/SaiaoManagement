using Saiao.Domain.Model;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase
    {
        void AutenticaUsuario(Usuario usuario);
    }
}
