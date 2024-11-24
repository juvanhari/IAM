
namespace Idm.Domain.Models
{
    public class TargetSystem : Aggregate<TargetSystemId>
    {
        private readonly List<TargetSystemDetail> _targetSystemConfigDetails = new();

        public IReadOnlyList<TargetSystemDetail> TargetSystemConfigurationDetails => _targetSystemConfigDetails.AsReadOnly();

        public TargetSystemType TargetSystemType { get; set; }
        public string Name { get; set; } = default!;

        public string ApplicationCode { get; set; } = default!;

        public string ApplicationDescription { get; set; } = default!;

        public static TargetSystem Create(TargetSystemId id, TargetSystemType targetSystemType, string name, string code, string description)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentException.ThrowIfNullOrEmpty(code);

            var targetSystem = new TargetSystem
            {
                Id = id,
                Name = name,
                ApplicationCode = code,
                ApplicationDescription = description,
                TargetSystemType = targetSystemType,
            };
            return targetSystem;
        }

        public void Add(TargetSystemId targetSystemId, string code, string value)
        {
            ArgumentNullException.ThrowIfNull(targetSystemId);
            ArgumentNullException.ThrowIfNullOrEmpty(code);
            //ArgumentNullException.ThrowIfNullOrEmpty(value);

            var targetSystemConfig = new TargetSystemDetail(TargetSystemDetailId.Of(Guid.NewGuid()), targetSystemId, code, value);

            _targetSystemConfigDetails.Add(targetSystemConfig);
        }
    }

    
}
