

namespace Idm.Domain.ValueObjects
{
    public record RequestUserId
    {
        public Guid Value { get; set; } = default!;
        private RequestUserId(Guid value) => Value = value;
        public static RequestUserId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("RequestUserId cannot be empty.");
            }

            return new RequestUserId(value);
        }
    }
}
