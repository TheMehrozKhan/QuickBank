using BankCrudOperationsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankCrudOperationsApp.Data
{
    public class TransactionDbContext:DbContext
    {
        public TransactionDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <BankTransactions> Transactions  { get; set; }
        public DbSet <User> Users { get; set; }    
    }
}
