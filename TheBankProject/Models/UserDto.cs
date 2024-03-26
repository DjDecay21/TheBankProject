using TheBankProject.Entities;

namespace TheBankProject.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public List<AccountDto>Accounts { get; set; }
    }
}
