

namespace Idm.Domain.Models
{
    public class RequestUser : Entity<RequestUserId>
    {
        public RequestUser() { }
        internal RequestUser(RequestDetailId requestdetailId, DateTime validfrom, DateTime validto)
        {
            this.RequestDetailId = requestdetailId;
            this.ValidFrom = validfrom;
            this.ValidTo = validto;
        }

        public RequestDetailId RequestDetailId { get; set; } = default!;

        public DateTime ValidFrom { get; set; } = default!;

        public DateTime ValidTo { get; set; } = default!;
    }
}
