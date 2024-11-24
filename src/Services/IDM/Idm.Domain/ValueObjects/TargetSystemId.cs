

namespace Idm.Domain.ValueObjects
{
    public record TargetSystemId
    {
        public Guid Value { get; set; } = default!;
        private TargetSystemId(Guid value) => Value = value;
        public static TargetSystemId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("TargetSystemId cannot be empty.");
            }

            return new TargetSystemId(value);
        }
    }
}
