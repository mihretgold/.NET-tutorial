using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    //This Code First approach 
    // We need to create a method to create the table for every model here
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options)
        {  
        }

        public DbSet<Category> Categories { get; set; }
    }
}
