
namespace Idm.Domain.ValueObjects
{
    public record RequestId
    {
        public Guid Value { get; set; } = default!;
        private RequestId(Guid value) => Value = value;
        public static RequestId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("RequestId cannot be empty.");
            }

            return new RequestId(value);
        }
    }
}
