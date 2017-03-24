using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BankAccount.Models
{

    public class BankAccountContext : DbContext{
        
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankAccountContext(DbContextOptions<BankAccountContext> options):base(options){

        }

        // This DbSet contains "Person" objects and is called "Users"
        public DbSet<User> Users { get; set; }   
        public DbSet<Transaction> Transactions { get; set; }  

        public int getBalance(int userId){
             Transaction userTransactionDb = this.Transactions
                .OrderByDescending(key=>key.CreatedAt)
                .FirstOrDefault(record=>record.UserId == userId); 
                return userTransactionDb != null ? userTransactionDb.Balance : 0;
        }     
    }
}