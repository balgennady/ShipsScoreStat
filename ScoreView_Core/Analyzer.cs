using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ScoreView
{
    /// <summary>
    /// Классы, связанные с десериализацией JSON
    /// </summary>
    public static class Analyzer
	{
		private static Expected.Tanks Expectedvalues = null;


        /// <summary>
        /// Десериализовать данные боевых записей
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static Tanks.Stats DeserializeVehicleStatistics(string jsonString)
		{
			return JsonConvert.DeserializeObject<Tanks.Stats>(jsonString);
		}

        /// <summary>
        /// Десериализовать список данных по танку
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static Encyclopedia.Tanks DeserializeListOfVehicles(string jsonString)
		{
			return JsonConvert.DeserializeObject<Encyclopedia.Tanks>(jsonString);
		}

		private static Expected.Tanks DeserializeExpectedValue()
		{
			Expected.Tanks result;
			using (var sr = new StreamReader(consts.ExpectedValueFile))
			{
				result = JsonConvert.DeserializeObject<Expected.Tanks>(sr.ReadToEnd());
			}
			return result;
		}

		public static double calculateWN8(int tank_id, Tanks.All StatsData)
		{
			if (Expectedvalues == null) Expectedvalues = DeserializeExpectedValue();
			Expected.Data exp = Expectedvalues.data.First(x => x.IDNum == tank_id);

			double rDAMAGE = (double)StatsData.damage_dealt / StatsData.battles / exp.expDamage;
			double rSPOT = (double)StatsData.spotted / StatsData.battles / exp.expSpot;
			double rFRAG = (double)StatsData.frags / StatsData.battles / exp.expFrag;
			double rDEF = (double)StatsData.dropped_capture_points / StatsData.battles / exp.expDef;
			double rWIN = (double)StatsData.wins*100.0 / StatsData.battles / exp.expWinRate;

			double rWINc = Math.Max(0, (rWIN - 0.71) / (1 - 0.71));
			double rDAMAGEc = Math.Max(0, (rDAMAGE - 0.22) / (1 - 0.22));
			double rFRAGc = Math.Max(0, Math.Min(rDAMAGEc + 0.2, (rFRAG - 0.12) / (1 - 0.12)));
			double rSPOTc = Math.Max(0, Math.Min(rDAMAGEc + 0.1, (rSPOT - 0.38) / (1 - 0.38)));
			double rDEFc = Math.Max(0, Math.Min(rDAMAGEc + 0.1, (rDEF - 0.10) / (1 - 0.10)));

			return 980.0 * rDAMAGEc + 210.0 * rDAMAGEc * rFRAGc + 155.0 * rFRAGc * rSPOTc + 75.0 * rDEFc * rFRAGc + 145.0 * Math.Min(1.8, rWINc);
		}
	}
}
