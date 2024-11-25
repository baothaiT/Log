
using Log.Contract.Entities;
using Log.Contract.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace Log.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<LogEntity> LogTable { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<LogEntity>()
            .HasKey(x => new { x.Id});

        // modelBuilder = SeedingData(modelBuilder);
    }

    private ModelBuilder SeedingData(ModelBuilder modelBuilder)
    {
        //Seeding Proxy
        #region Log table
        Guid productId1 = Guid.NewGuid();

        LogEntity logEntity = new LogEntity()
        {
            Id = productId1,
            StartDateTime = DateTime.Now,
            ComponentName = "",
            Code = LogCodeEnum.Success,
            Message = ""

        };
        modelBuilder.Entity<LogEntity>().HasData(
            logEntity
        );
        #endregion
        return modelBuilder;
    }
}