using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeMaker.Models;


namespace ResumeMaker.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder _modelBuilder)
        {
            base.OnModelCreating(_modelBuilder);
       
            _modelBuilder.Entity<User>().HasMany(u => u.Experiences);
            _modelBuilder.Entity<User>().HasMany(u => u.Education);
            _modelBuilder.Entity<User>().HasMany(u => u.Languages);
            _modelBuilder.Entity<User>().HasMany(u => u.Skills);
            _modelBuilder.Entity<User>().HasMany(u => u.Cards);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
