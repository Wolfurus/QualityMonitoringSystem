using QualityMonitoringSystem.Mocks;

namespace QualityMonitoringSystem.Models
{
    public class QualityData
    {
        public string? Zeitstempel { get; set; }
        public string? Dmc { get; set; }
        public string? ArticleDescriptions { get; set; }
        public Quality? Qualitaet { get; set; }
    }
}
