using Lab_DDD1_Domain.CoreFramework;

namespace Lab_DDD1_Domain.Entities
{
    public class LibraryAccount : AggregateRoot<UniqueId>
    {
        public LibraryAccount(string number)
            : this(new UniqueId(), number)
        {

        }

        public LibraryAccount(UniqueId id, string number)
            : base(id)
        {
            this.Number = number;
        }

        public string Number { get; private set; }
        public string OwnerName { get; set; } = string.Empty;
        public bool IsLocked { get; set; }
    }
}
