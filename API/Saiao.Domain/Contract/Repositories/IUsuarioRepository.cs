using Saiao.Domain.Model;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario AutenticaUsuario(Usuario usuario);
    }
}
