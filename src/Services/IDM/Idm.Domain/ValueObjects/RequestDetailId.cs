

namespace Idm.Domain.ValueObjects
{
    public record RequestDetailId
    {
        public Guid Value { get; set; } = default!;
        private RequestDetailId(Guid value) => Value = value;
        public static RequestDetailId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("RequestDetailId cannot be empty.");
            }

            return new RequestDetailId(value);
        }
    }
}
