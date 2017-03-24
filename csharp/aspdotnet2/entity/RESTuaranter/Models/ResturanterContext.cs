using Microsoft.EntityFrameworkCore;


namespace Resturanter.Models{

    public class ResturanterContext : DbContext{
        
        // base() calls the parent class' constructor passing the "options" parameter along
        public ResturanterContext(DbContextOptions<ResturanterContext> options):base(options){

        }

        // This DbSet contains "Person" objects and is called "Users"
        public DbSet<Person> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}