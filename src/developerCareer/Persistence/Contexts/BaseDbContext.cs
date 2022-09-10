using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DeveloperCareerConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(p => p.ProgrammingTechnologies);
            });

            modelBuilder.Entity<ProgrammingTechnology>(a =>
            {
                a.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingTechnologiesId");

                a.HasOne(p => p.ProgrammingLanguage);
            });

            ProgrammingLanguage[] programmingLanguageSeed = { new(1, "Assembly"), new(2, "C") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeed);

            ProgrammingTechnology[] programmingTechnologies = { new(1, "WFP", 3), new(2, "Pygame", 7) };
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologies);
        }
    }
}
