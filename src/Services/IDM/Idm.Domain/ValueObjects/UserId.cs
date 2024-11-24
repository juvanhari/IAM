

namespace Idm.Domain.ValueObjects
{
    public record UserId
    {
        public Guid Value { get; set; } = default!;
        private UserId(Guid value) => Value = value;
        public static UserId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("UserId cannot be empty.");
            }

            return new UserId(value);
        }
    }
}
