using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class ApplicationContext: DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Engagement> engagements { get; set; }
    }
}