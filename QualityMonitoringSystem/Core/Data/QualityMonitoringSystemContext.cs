using Microsoft.EntityFrameworkCore;
using QualityMonitoringSystem.Models;

namespace QualityMonitoringSystem.Core.Data
{
    public class QualityMonitoringSystemContext :DbContext
    {
        public QualityMonitoringSystemContext(DbContextOptions<QualityMonitoringSystemContext> options) : base(options) { }

        public DbSet<QualityData> QualityDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<QualityData>().HasData(QualityMonitor.QualityDatas);
        }
    }
}
