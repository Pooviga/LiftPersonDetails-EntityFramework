
using Microsoft.EntityFrameworkCore;
using PersonDetails.WebAPi.Model;

namespace PersonDetails.WebAPi.DataAccessLayer
{
    public class PersonDetailDBContext : DbContext
    {
        public PersonDetailDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PersonDetail> PersonDetails { get; set; }

        
    }
}
