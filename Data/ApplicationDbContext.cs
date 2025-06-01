using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAl1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1b8e92c7-6cd0-4f24-b53e-c2b6a110a67d",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            },
                new IdentityRole
                {
                    Id = "833fc580-1c54-49e8-89bf-3dd66dac69db",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "3389c9d2-0835-47a7-846f-258a00182a1d",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
                );

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "bcc2dfed-07c8-40ef-a859-a8ec736d3a70",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    UserName = "admin@example.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "3389c9d2-0835-47a7-846f-258a00182a1d",
                    UserId = "bcc2dfed-07c8-40ef-a859-a8ec736d3a70",
                }
                );
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
    }
}
