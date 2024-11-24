
using Idm.Domain.Enums;

namespace Idm.Domain.Models
{
    public class User : Entity<UserId>
    {
       
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Email { get; private set; } = default!;

        public string Department { get; set; } = default!;

        public bool Status { get; set; } = true;

        public DateTime JoinDate { get; set; } = default!;

        public string Manager { get; set; } = default!;

        public EmployeeType EmployeeType { get; set; }

        public static User Create(UserId id, string firstname, string lastname,string department, DateTime joindate, string manager, EmployeeType employeeType)
        {
            ArgumentException.ThrowIfNullOrEmpty(firstname);
            ArgumentException.ThrowIfNullOrEmpty(lastname);

            var user = new User
            {
                Id = id,
                FirstName = firstname,
                LastName = lastname,
                Department = department,
                JoinDate = joindate,
                Manager = manager,
                EmployeeType = employeeType
            };
            user.GenerateEmail();
            return user;
        }


        private void GenerateEmail()
        {
            if(string.IsNullOrWhiteSpace(this.FirstName) || string.IsNullOrWhiteSpace(this.LastName))
            {
                ArgumentNullException.ThrowIfNullOrEmpty("First name, last name, and domain cannot be null or empty.");
            }
            // Get the first letter of the first name
            char firstInitial = this.FirstName[0];

            string empType = this.EmployeeType.ToString();

            // Combine first letter and last name
            string emailPrefix = this.EmployeeType == EmployeeType.Staff ? $"{firstInitial}{this.LastName}" : $"{firstInitial}{this.LastName}.{empType}";

            // Generate full email
            this.Email = $"{emailPrefix}@{"adb.org"}";

        }

    }
}
