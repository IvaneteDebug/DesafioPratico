using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(tabela =>
            {
                tabela.HasKey(e => e.Id);

            });
        }
    }
}