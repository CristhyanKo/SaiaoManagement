using System;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryPessoaTelefone : IRepositoryClassBase
    {
        IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid telefoneId);
    }
}
