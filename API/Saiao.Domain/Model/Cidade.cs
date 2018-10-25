using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Cidade : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
    }
}
