using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TRunner.Domain.Entities;

namespace TRunner.Infrastructure.ConnectionStrings;

public class TRunnerDbContext : DbContext
{
    private readonly IConnectionStringService _connectionStringService;

    public TRunnerDbContext(DbContextOptions<TRunnerDbContext> options, IConnectionStringService connectionStringService) : base(options)
    {
        _connectionStringService = connectionStringService;
    }

    public virtual DbSet<SportType> SportTypes { get; set; }
    public virtual DbSet<Sport> Sports { get; set; }
    public virtual DbSet<GroupType> GroupTypes { get; set; } 
    public virtual DbSet<Group> Groups { get; set; } 
    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<ViewPermissionType> ViewPermissionTypes { get; set; }
    public virtual DbSet<WorkoutSummary> WorkoutSummaries { get; set; }
    public virtual DbSet<WorkoutImage> WorkoutImages { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _connectionStringService.Create();
        optionsBuilder.UseMySQL(
                connectionString,
                builder =>
                {
                    builder.CommandTimeout(25);
                    builder.EnableRetryOnFailure();
                    builder.MigrationsAssembly("TRunner.Infrastructure");
                })
            .UseLoggerFactory(LoggerFactory.Create(x => x.SetMinimumLevel(LogLevel.Information)))
            .EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<UserRole>(entity =>
        //{
        //    entity.HasIndex(b => b.RoleName).IsUnique();
        //    entity.HasMany(b => b.Users);
        //});

        //modelBuilder.Entity<User>(entity =>
        //{
        //    entity.HasIndex(b => new { b.Email, b.UserRoleId }).IsUnique();
        //});

        //modelBuilder.Entity<SportType>(entity =>
        //{
        //    entity.HasIndex(b => b.SportTypeName).IsUnique();
        //});

        //modelBuilder.Entity<Sport>(entity =>
        //{
        //    entity.HasIndex(b => b.SportName).IsUnique();
        //});

        //modelBuilder.Entity<GroupType>(entity =>
        //{
        //    entity.HasIndex(b => b.GroupTypeName).IsUnique();
        //});

        //modelBuilder.Entity<Group>(entity =>
        //{
        //    entity.HasIndex(b => b.GroupName).IsUnique();
        //});

        //modelBuilder.Entity<ViewPermissionType>(entity =>
        //{
        //    entity.HasIndex(b => b.ViewPermission).IsUnique();
        //});
    }
}