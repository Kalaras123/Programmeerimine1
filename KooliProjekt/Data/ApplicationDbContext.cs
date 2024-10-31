using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet <Operation> Operations { get; set; }
        public DbSet <Car> Cars { get; set; }
        public DbSet <Worker> Workers { get; set; }
    }
}