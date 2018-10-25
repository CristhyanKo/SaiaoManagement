using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Item : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Guid FornecedorId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
    }
}
