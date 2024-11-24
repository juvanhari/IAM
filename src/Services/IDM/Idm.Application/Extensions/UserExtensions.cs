using Mapster;

namespace Idm.Application.Extensions
{
    public static class UserExtensions
    {
        public static IEnumerable<UserDto> ToUserDtoList(this IEnumerable<User> users)
        {
            return users.Select(user => user.ToUserDto());
        }

        public static UserDto ToUserDto(this User user)
        {
            return DtoFromUser(user);
        }

        private static UserDto DtoFromUser(User user)
        {
            //return user.Adapt<UserDto>();
            return new UserDto(
                        Id: user.Id.Value,
                        Firstname: user.FirstName,
                        Lastname: user.LastName,
                        Department: user.Department,
                        Joindate: user.JoinDate,
                        Manager: user.Manager,
                        EmployeeType: user.EmployeeType,
                        Status: user.Status
                    );
        }
    }
}
