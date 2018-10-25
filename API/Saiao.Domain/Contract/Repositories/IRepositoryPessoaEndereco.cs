using System;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryPessoaEndereco : IRepositoryBase
    {
        IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid enderecoId);
    }
}
