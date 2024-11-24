

namespace Idm.Domain.ValueObjects
{
    public class RequestItemId
    {
        public Guid Value { get; set; } = default!;
        private RequestItemId(Guid value) => Value = value;
        public static RequestItemId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("RequestItemId cannot be empty.");
            }

            return new RequestItemId(value);
        }
    }
}
