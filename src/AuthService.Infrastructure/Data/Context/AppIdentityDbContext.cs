using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AuthService.Infrastructure.Identity;

namespace AuthService.Infrastructure.Data.Context;

public class AppIdentityDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public AppIdentityDbContext() { }
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }
    
    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("AuthService");
        
        // Customize table names for clarity and to follow specific naming conventions within the database.
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Roles");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

        // Seed initial roles into the database from the RoleType enum.
        foreach (var role in Enum.GetNames(typeof(RoleTypes)))
        {
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Roles").HasData(new IdentityRole<Guid>
            {
                Name = role,
                NormalizedName = role.ToUpper(),
                Id = Guid.NewGuid(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            });
        }
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}