using System;

namespace Saiao.Domain.Contract.Repositories
{
    public interface IRepositoryPessoaEmail : IRepositoryBase
    {
        IRepositoryClassBase DefinirComoPrincipal(Guid pessoaId, Guid emailId);
    }
}
