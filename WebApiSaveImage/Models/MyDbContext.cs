using Microsoft.EntityFrameworkCore;

namespace WebApiSaveImage.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }  
    }
}
