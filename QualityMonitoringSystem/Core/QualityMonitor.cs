using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QualityMonitoringSystem.Mocks;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QualityMonitoringSystem.Core
{
    public class QualityMonitor
    {
        private static List<Data> _qualityDatas;
        public static List<Data> QualityDatas
        {
            get
            {
                if (_qualityDatas != null)
                {
                    return _qualityDatas;
                }
                LoadData();

                return _qualityDatas;
            }
            set
            {
                _qualityDatas = value;
            }
        }

        private static void LoadData()
        {
            List<string> dataStrings = CheckPointData.getCheckPointDatas();
            QualityDatas = new List<Data>();
            foreach (string dataString in dataStrings)
            {
                QualityDatas.Add(JsonSerializer.Deserialize<Data>(dataString));
            }
        }



        public static List<Data> GetDataFilterdByArticleCode(string articleCode)
        {
            return QualityDatas.Where(qd => qd.ArticleDescriptions.Equals(articleCode)).ToList();
        }

        public static List<Data> GetDataFilterdByQuality(Quality qualityCode)
        {
            return QualityDatas.Where(qd => qd.Qualitaet.Equals(qualityCode)).ToList();
        }
    }
}

