using System;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryPessoaEmail : IRepositoryClassBase
    {
        IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid emailId);
    }
}
