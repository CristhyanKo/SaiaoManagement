using Saiao.Domain.Contract.Repositories;

namespace Saiao.Domain.Model
{
    public class Cargo : IRepositoryClass
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
