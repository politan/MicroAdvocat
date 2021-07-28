namespace MicroAdvocate.Persistence.Database
{
    public interface IIdentity<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}