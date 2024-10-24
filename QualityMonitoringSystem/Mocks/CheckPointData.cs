﻿

// Ignore Spelling: Zeitstempel Dmc Qualitaet

using QualityMonitoringSystem.Models;
using System.Text.Json;

namespace QualityMonitoringSystem.Mocks
{
    public static class CheckPointData
    {
        public static List<string> getCheckPointDatas(int countOfProducts = 1000, int countOfArticleCode = 10)
        {
            List<string> datas = new List<string>();
            List<string> articleCode = new List<string>();
            Random rnd = new Random();

            for (int i = 0; i < countOfArticleCode; i++)
            {
                string code = "";
                for (int j = 0; j < 8; j++)
                {
                    code += rnd.Next(1, 10);
                }
                articleCode.Add(code);
            }

            for (int i = 0; i < countOfProducts; i++)
            {
                datas.Add(BuildJSON(articleCode[rnd.Next(0, articleCode.Count)], rnd.Next(0,2)));
            }
            return datas;
        }

        private static string BuildJSON(string articleCode, int qualityNumber)
        {
            QualityData data = new QualityData() { Dmc = articleCode, ArticleDescriptions=articleCode, Qualitaet = qualityNumber == 0 ? Quality.Schlecht : Quality.Gut, Zeitstempel = DateTime.Now.ToLongDateString()};
            return JsonSerializer.Serialize(data);
        }
    }



    public enum Quality
    {
        Gut,
        Schlecht
    }
}
