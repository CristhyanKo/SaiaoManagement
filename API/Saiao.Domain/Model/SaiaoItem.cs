namespace Saiao.Domain.Model
{
    public class SaiaoItem
    {
        public int Id { get; set; }
        public int SaiaoId { get; set; }
        public int ItemId  { get; set; }
        public int Quantidade { get; set; }

        public virtual Saiao Saiao { get; set; }
        public virtual Item Item { get; set; }
    }
}
