
using System.Net;

namespace Idm.Domain.Models
{
    public class Request : Aggregate<RequestId>
    {
        private readonly List<RequestDetail> _requestDetails = new();

        public IReadOnlyList<RequestDetail> RequestDetails => _requestDetails.AsReadOnly();

        public string RequestorName { get; set; } = default!;

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public RequestStatus RequestStatus { get; set; }

        public static Request Create(RequestId id,  string requestorName, DateTime requestDate, RequestStatus status)
        {
            var request = new Request
            {
                Id = id,
                RequestorName = requestorName,
                RequestDate = requestDate,
                RequestStatus = status
            };

            return request;
        }

        public void Add(RequestId id,TargetSystemId targetSystemId, AdhocActionType adhocActionType)
        {
            ArgumentNullException.ThrowIfNull(id);
            ArgumentNullException.ThrowIfNull(targetSystemId);

            var requestDetail = new RequestDetail(id, targetSystemId, adhocActionType);

            _requestDetails.Add(requestDetail);
        }
    }


}
