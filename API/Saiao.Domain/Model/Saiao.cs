using System;

namespace Saiao.Domain.Model
{
    public class Saiao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public string Motivo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
