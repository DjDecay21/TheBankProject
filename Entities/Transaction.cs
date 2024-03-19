using System.ComponentModel.DataAnnotations.Schema;

namespace TheBankProject.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FromAccountId { get; set; }
        public virtual Account FromAccount { get; set; }

        public int ToAccountId { get; set; }
        public virtual Account ToAccount { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public bool Status { get; set; }
    }
}
