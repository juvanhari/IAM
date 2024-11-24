

namespace Idm.Domain.Models
{
    public class RequestDetail : Entity<RequestDetailId>
    {
        public RequestDetail() { }
        internal RequestDetail(RequestId requestId, TargetSystemId targetSystemId, AdhocActionType adhocActionType)
        {
            this.RequestId = requestId;
            this.TargetSystemId = targetSystemId;
            this.AdhocActionType = adhocActionType;
        }
        private readonly List<RequestItem> _requestItems = new();

        public IReadOnlyList<RequestItem> RequestItems => _requestItems.AsReadOnly();

        private readonly List<RequestUser> _requestUsers = new();

        public IReadOnlyList<RequestUser> RequestUsers => _requestUsers.AsReadOnly();

        public RequestId RequestId { get; set; } = default!;

        public TargetSystemId TargetSystemId { get; set; } = default!;

        public AdhocActionType AdhocActionType { get; set; }

        public void AddRequestItem(RequestDetailId requestdetailId, string code, string value)
        {
            ArgumentNullException.ThrowIfNull(requestdetailId);
            ArgumentNullException.ThrowIfNullOrEmpty(code);
            ArgumentNullException.ThrowIfNullOrEmpty(value);

            var requestItem = new RequestItem(requestdetailId, code, value);

            _requestItems.Add(requestItem);
        }
        public void AddRequestUser(RequestDetailId requestdetailId, DateTime validfrom, DateTime validto)
        {
            ArgumentNullException.ThrowIfNull(requestdetailId);

            var requestUser = new RequestUser(requestdetailId, validfrom, validto);

            _requestUsers.Add(requestUser);
        }

    }
}
