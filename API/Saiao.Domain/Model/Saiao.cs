using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Saiao : IRepositoryClass
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public string Motivo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
