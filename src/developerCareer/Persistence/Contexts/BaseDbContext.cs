using Core.Security.Entities;
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

        public DbSet<User> Users { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<UserGit> UserGits { get; set; }

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

            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("Users").HasKey(k => k.Id);
                u.Property(y => y.Id).HasColumnName("Id");
                u.Property(y => y.FirstName).HasColumnName("FirstName");
                u.Property(y => y.LastName).HasColumnName("LastName");
                u.Property(y => y.Email).HasColumnName("Email");
                u.Property(y => y.PasswordHash).HasColumnName("PasswordHash");
                u.Property(y => y.PasswordSalt).HasColumnName("PasswordSalt");
                u.Property(y => y.Status).HasColumnName("Status");
                u.Property(y => y.AuthenticatorType).HasColumnName("AuthenticatorType");

                u.HasMany(y => y.UserOperationClaims);
                u.HasMany(y => y.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(o =>
            {
                o.ToTable("OperationClaims").HasKey(p => p.Id);
                o.Property(p => p.Id).HasColumnName("Id");
                o.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(o =>
            {
                o.ToTable("UserOperationClaims").HasKey(p => p.Id);
                o.Property(p => p.Id).HasColumnName("Id");
                o.Property(p => p.UserId).HasColumnName("UserId");
                o.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");

                o.HasOne(p => p.User);
                o.HasOne(p => p.OperationClaim);
            });

            modelBuilder.Entity<RefreshToken>(r =>
            {
                r.ToTable("RefreshTokens").HasKey(i => i.Id);
                r.Property(i => i.Id).HasColumnName("Id");
                r.Property(i => i.UserId).HasColumnName("UserId");
                r.Property(i => i.Token).HasColumnName("Token");
                r.Property(i => i.Expires).HasColumnName("Expires");
                r.Property(i => i.Created).HasColumnName("Created");
                r.Property(i => i.CreatedByIp).HasColumnName("CreatedByIp");
                r.Property(i => i.Revoked).HasColumnName("Revoked");
                r.Property(i => i.RevokedByIp).HasColumnName("RevokedByIp");
                r.Property(i => i.ReplacedByToken).HasColumnName("ReplacedByToken");
                r.Property(i => i.ReasonRevoked).HasColumnName("ReasonRevoked");

                r.HasOne(i => i.User);
            });

            modelBuilder.Entity<UserGit>(g =>
            {
                g.ToTable("UserGits").HasKey(i => i.Id);
                g.Property(g => g.Id).HasColumnName("Id");
                g.Property(i => i.UserId).HasColumnName("UserId");
                g.Property(i => i.GitLink).HasColumnName("GitLink");

                g.HasOne(o => o.User);
            });

            ProgrammingLanguage[] programmingLanguageSeed = { new(1, "Assembly"), new(2, "C") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeed);

            ProgrammingTechnology[] programmingTechnologies = { new(1, "WFP", 3), new(2, "Pygame", 7) };
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologies);

            OperationClaim[] operationClaims = { new(1, "Admin"), new(2, "Add"), new(3, "Remove"), new(4, "Update"), new(5, "Get"), new(6, "GetList"), new(7, "BlackList") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaims);
        }
    }
}
