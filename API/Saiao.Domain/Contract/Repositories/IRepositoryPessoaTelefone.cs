using System;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryPessoaTelefone : IRepositoryBase
    {
        IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid telefoneId);
    }
}
