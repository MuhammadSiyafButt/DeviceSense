using Microsoft.EntityFrameworkCore;

namespace DeviceSense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<SnapshotRecord> SnapshotRecords => Set<SnapshotRecord>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=devicesense_history.db");
            }
        }
    }

    public class SnapshotRecord
    {
        public int Id { get; set; }
        public System.DateTime CapturedAt { get; set; }
        public double? CpuUsagePercent { get; set; }
        public double? RamUsagePercent { get; set; }
        public int? BatteryChargePercent { get; set; }
        public string? InsightsJson { get; set; }
    }
}