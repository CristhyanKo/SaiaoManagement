using Saiao.Domain.Contract.Repositories;
using System;

namespace Saiao.Domain.Model
{
    public class SaiaoItem : IRepositoryClassBase
    {
        public Guid Id { get; set; }
        public Guid SaiaoId { get; set; }
        public Guid ItemId  { get; set; }
        public int Quantidade { get; set; }

        public virtual Saiao Saiao { get; set; }
        public virtual Item Item { get; set; }
    }
}
