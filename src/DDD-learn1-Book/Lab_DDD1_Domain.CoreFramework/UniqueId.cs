﻿namespace Lab_DDD1_Domain.CoreFramework
{
    public class UniqueId : TValueObject<UniqueId>
    {
        public UniqueId() : this(Guid.NewGuid())
        {

        }

        public UniqueId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(value));
            }
            this.Value = value;
        }

        public Guid Value { get; private set; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
