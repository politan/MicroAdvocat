namespace MicroAdvocate.Persistence.Database.Entities
{
    public interface IIdentity<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}