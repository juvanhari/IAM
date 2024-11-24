

namespace Idm.Domain.Models
{
    public class RequestItem : Entity<RequestItemId>
    {
        public RequestItem() { }
        internal RequestItem(RequestDetailId requestdetailId, string code, string value)
        {
            this.RequestDetailId = requestdetailId;
            this.Code = code;
            this.Value = value;
        }

        public RequestDetailId RequestDetailId { get; set; } = default!;

        public string Code { get; set; } = default!;

        public string Value { get; set; } = default!;
    }
}
