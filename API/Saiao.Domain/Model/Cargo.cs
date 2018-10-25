using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class Cargo : IRepositoryClass
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}
