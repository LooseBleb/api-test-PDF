using Microsoft.EntityFrameworkCore;
using Trabs_BLL.Models;
using Trabs_DAO.Mapping;

namespace Trabs_DAO
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Work> Works { get; set; }
        public DbSet<Matter> Matters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
             
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new WorkMap());
            builder.ApplyConfiguration(new MatterMap());

        }
    }
}