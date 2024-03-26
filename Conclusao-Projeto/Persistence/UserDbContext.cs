using Conclusao_Projeto.Domain;
using Microsoft.EntityFrameworkCore;

namespace Conclusao_Projeto.Persistence
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(tabela =>
            {
                tabela.HasKey(e => e.Id);
            });

        }
    }
}
