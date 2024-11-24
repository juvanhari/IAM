
namespace Idm.Domain.ValueObjects
{
    public record TargetSystemDetailId
    {
        public Guid Value { get; set; } = default!;
        private TargetSystemDetailId(Guid value) => Value = value;
        public static TargetSystemDetailId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("TargetSystemDetailId cannot be empty.");
            }

            return new TargetSystemDetailId(value);
        }
    }
}
