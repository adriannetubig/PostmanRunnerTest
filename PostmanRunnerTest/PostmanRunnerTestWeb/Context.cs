using Microsoft.EntityFrameworkCore;
using PostmanRunnerTestWeb.Entities;

namespace PostmanRunnerTestWeb
{
    public class Context: DbContext
    {
        public Context()
        { }

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<ETest> ETests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
    }
}
