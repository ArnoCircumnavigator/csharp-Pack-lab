namespace Lab_DDD1_Domain.CoreFramework
{
    public interface IValueObject
    {
        IEnumerable<object> GetAtomicValues();
    }
}