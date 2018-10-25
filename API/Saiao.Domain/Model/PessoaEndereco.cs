using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class PessoaEndereco : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int  Numero { get; set; }
        public Guid EstadoId { get; set; }
        public Guid CidadeId { get; set; }
        public Guid PessoaId { get; set; }
        public bool Principal { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}
