using Idm.Domain.Models;

namespace Idm.Api
{
    public static class MapsterConfiguration
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<User, UserDto>
                .NewConfig();
        }
    }
}