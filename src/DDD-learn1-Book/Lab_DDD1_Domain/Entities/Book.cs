using Lab_DDD1_Domain.CoreFramework;

namespace Lab_DDD1_Domain.Entities
{
    public class Book : AggregateRoot<UniqueId>
    {
        public Book() : this(new UniqueId())
        {

        }

        public Book(UniqueId id) : base(id)
        {

        }

        public string BookName { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
