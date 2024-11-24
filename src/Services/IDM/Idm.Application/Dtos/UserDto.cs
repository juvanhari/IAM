

namespace Idm.Application.Dtos
{
    public record UserDto(Guid Id, string Firstname, string Lastname, string Department, DateTime Joindate, string Manager, EmployeeType EmployeeType, bool Status);
}
