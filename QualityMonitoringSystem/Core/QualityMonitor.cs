using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QualityMonitoringSystem.Mocks;
using QualityMonitoringSystem.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QualityMonitoringSystem.Core
{
    public class QualityMonitor
    {
        private static List<QualityData> _qualityDatas;
        public static List<QualityData> QualityDatas
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
            QualityDatas = new List<QualityData>();
            foreach (string dataString in dataStrings)
            {
                QualityDatas.Add(JsonSerializer.Deserialize<QualityData>(dataString));
            }
        }



        public static List<QualityData> GetDataFilterdByArticleCode(string articleCode)
        {
            return QualityDatas.Where(qd => qd.ArticleDescriptions.Equals(articleCode)).ToList();
        }

        public static List<QualityData> GetDataFilterdByQuality(Quality qualityCode)
        {
            return QualityDatas.Where(qd => qd.Qualitaet.Equals(qualityCode)).ToList();
        }

        public static List<QualityData> GetDataFilterdByQuality(List<QualityData> datas, Quality qualityCode)
        {
            return datas.Where(qd => qd.Qualitaet.Equals(qualityCode)).ToList();
        }

        public static List<QualityData> UpdateDatas(List<QualityData> datas)
        {
            //ToDo: EF Anbindung aufbauen!
            throw new NotImplementedException();
        }
    }
}

