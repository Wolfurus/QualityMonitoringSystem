using Microsoft.EntityFrameworkCore;
using QualityMonitoringSystem.Core.Data;
using QualityMonitoringSystem.Models;

namespace QualityMonitoringSystem.Core
{
    public class QualityMonitorEfRepository : IQualityMonitorEfRepository
    {
        public readonly IDbContextFactory<QualityMonitoringSystemContext> dbContextFactory;

        public QualityMonitorEfRepository(IDbContextFactory<QualityMonitoringSystemContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public void AddData(QualityData data)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            dbContext.QualityDatas.Add(data);
            dbContext.SaveChanges();
        }

        public void DeleteData(int id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var data = dbContext.QualityDatas.Find(id);
            if (data != null)
            {
                dbContext.QualityDatas.Remove(data);
                dbContext.SaveChanges();
            }
        }

        public List<QualityData> GetData()
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return dbContext.QualityDatas.ToList();
        }

        public QualityData GetDataById(int id)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            var data = dbContext.QualityDatas.Find(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public List<QualityData> GetDatasByCode(string code)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            return dbContext.QualityDatas.Where(qd => qd.Dmc == code).ToList();
        }

        public void UpdateData(QualityData data)
        {
            if (data != null)
            {
                using var dbContext = dbContextFactory.CreateDbContext();
                dbContext.QualityDatas.Update(data);
                dbContext.SaveChanges();
            }
        }
    }
}
