using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Estado : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public int Ibge { get; set; }
    }
}
