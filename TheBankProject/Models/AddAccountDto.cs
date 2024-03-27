using TheBankProject.Entities;

namespace TheBankProject.Models
{
    public class AddAccountDto
    {
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public string NumberAccount { get; set; }
    }

}
