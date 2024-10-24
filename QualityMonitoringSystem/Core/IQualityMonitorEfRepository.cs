using QualityMonitoringSystem.Models;

namespace QualityMonitoringSystem.Core
{
    public interface IQualityMonitorEfRepository
    {
        void AddData(QualityData data);
        void DeleteData(int id);
        void UpdateData(QualityData data);
        QualityData GetDataById(int id);
        List<QualityData> GetData();
        List<QualityData> GetDatasByCode(string code);
    }
}
