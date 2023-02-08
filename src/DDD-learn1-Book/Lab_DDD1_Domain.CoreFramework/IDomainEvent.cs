namespace Lab_DDD1_Domain.CoreFramework
{
    public interface IDomainEvent
    {
        IList<object> Results { get; }
        T GetTypedResult<T>();
        IList<T> GetTypedResults<T>();
    }
}
