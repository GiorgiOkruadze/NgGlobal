using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NgGlobal.DatabaseModels.Models;

namespace NgGlobal.DatabaseEntity.DB
{
    public class ApplicationDbContext : IdentityDbContext<User, UserRole,int>
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CompanyInfo> CompanyIntos { get; set;}
        public DbSet<CompanyService> CompanyService { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<DailyDataset> DailyDataset { get; set; }


        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
