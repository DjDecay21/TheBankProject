namespace TheBankProject.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public string Password { get; set; }
        public string Pesel { get; set; }
        public virtual List<Account> Accounts { get; set; }

    }
}
