using System;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryPessoaEndereco : IRepositoryClassBase
    {
        IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid enderecoId);
    }
}
