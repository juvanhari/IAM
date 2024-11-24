namespace Idm.Domain.Models
{
    public class TargetSystemDetail : Entity<TargetSystemDetailId>
    {
        public TargetSystemDetail() { }
        internal TargetSystemDetail(TargetSystemDetailId targetSystemDetailId, TargetSystemId targetSystemId, string code, string value)
        {
            this.Id = targetSystemDetailId;
            this.TargetSystemId = targetSystemId;
            this.Code = code;
            this.Value = value;
        }

        public TargetSystemId TargetSystemId { get; set; } = default!;

        public string Code { get; set; } = default!;

        public string Value { get; set; } = default!;

    }
}
