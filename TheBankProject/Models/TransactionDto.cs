﻿using TheBankProject.Entities;

namespace TheBankProject.Models
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int FromAccountId { get; set; }
        public virtual Account FromAccount { get; set; }

        public int ToAccountId { get; set; }
        public virtual Account ToAccount { get; set; }
        public decimal Value { get; set; }
        public string Title { get; set; }

        public DateTime DateTime { get; set; }
        public string IncomingOutgoing { get; set; }
    }
}
