namespace TheBankProject.Models
{
    public class TransferDto
    {
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }


        public DateTime DateTime { get; set; }
        public string IncomingOutgoing { get; set; }
    }
}
