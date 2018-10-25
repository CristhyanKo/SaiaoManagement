using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class PessoaEmail : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Principal { get; set; }
        public Guid PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
