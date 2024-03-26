namespace TheBankProject.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string NumberAccount { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }


    }
}
