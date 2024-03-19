using Microsoft.EntityFrameworkCore;

namespace TheBankProject.Entities
{
    public class BankDbContext:DbContext
    {

        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=BankDb;Trusted_Connection=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.PhoneNumber)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.Pesel)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .IsRequired();


            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.FromAccount)
                .WithMany()
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ToAccount)
                .WithMany()
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.NoAction);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}

