using Microsoft.EntityFrameworkCore;
using Webapi.Model;

namespace Webapi
{
    public class DataContext : DbContext
    {
        public DataContext() 
        {
            
        }

        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext) 
        {
        }

        public DbSet<MailRequest> mailRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cofiguration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = cofiguration.GetConnectionString("");
            //optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
