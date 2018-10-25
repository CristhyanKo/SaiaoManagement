using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Fornecedor : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid PessoaId{ get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
