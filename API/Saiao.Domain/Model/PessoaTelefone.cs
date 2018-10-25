using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class PessoaTelefone : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public int DDD { get; set; }
        public int  Telefone { get; set; }
        public bool Principal { get; set; }
        public Guid PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
