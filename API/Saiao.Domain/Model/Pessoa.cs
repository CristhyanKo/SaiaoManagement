using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Pessoa : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int CPF_CNPJ { get; set; }
    }
}
