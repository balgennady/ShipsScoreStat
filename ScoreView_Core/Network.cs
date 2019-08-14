using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ScoreView
{
    /// <summary>
    /// Связанные классы
    /// </summary>
    public static class Network
	{
        /// <summary>
        /// отправка запроса GET по адресу url и сохранение ответ в path
        /// </summary>
        /// <param name="url">Запрос места назначения</param>
        /// <param name="path">Адресат ответа</param>
        public static void SendGET(string url, string path)
		{
			HttpWebRequest request = WebRequest.CreateHttp(url);
			request.KeepAlive = true;
			Save(request, path);
		}

        /// <summary>
        /// отправка запроса GET по URL и сохранение ответ в path
        /// </summary>
        /// <param name="url">Запрос места назначения</param>
        /// <param name="parameters">Запросить содержание</param>
        /// <param name="path">Адресат ответа</param>
        public static void SendPOST(string url, Dictionary<string, string> parameters, string path)
		{
			string parameterString = "";
			byte[] parameterBytes;

			foreach (var d in parameters) parameterString += d.Key + "=" + d.Value + "&";
			parameterBytes = Encoding.ASCII.GetBytes(parameterString);

			HttpWebRequest request = WebRequest.CreateHttp(url);
			request.Method = "POST";
			request.ContentLength = parameterBytes.Length;

			Stream reqStream = request.GetRequestStream();
			reqStream.Write(parameterBytes, 0, parameterBytes.Length);
			reqStream.Close();

			Save(request, path);
		}

        /// <summary>
        /// Сохранить ответ отправленного запроса в path
        /// </summary>
        /// <param name="request">Отправленный HTTP-запрос</param>
        /// <param name="path">Адресат ответа</param>
        private static void Save(HttpWebRequest request, string path)
		{
			var resStream = request.GetResponse().GetResponseStream();
			using (var file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
			{
				int read;
				byte[] buffer = new byte[1024];
				while ((read = resStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					file.Write(buffer, 0, read);
				}
			}
		}

        /// <summary>
        /// Отправьте запрос POST по URL и верните ответ в виде string
        /// </summary>
        /// <param name="url">Запрос места назначения</param>
        /// <param name="parameters">Содержание запроса</param>
        /// <returns>ответ</returns>
        private static string APIRequest(string url, Dictionary<string, string> parameters)
		{
			string parameterString = "";
			byte[] parameterBytes;

			foreach (var d in parameters) parameterString += d.Key + "=" + d.Value + "&";
			parameterBytes = Encoding.ASCII.GetBytes(parameterString);

			HttpWebRequest request = WebRequest.CreateHttp(url);
			request.Method = "POST";
			request.ContentLength = parameterBytes.Length;

			Stream reqStream = request.GetRequestStream();
			reqStream.Write(parameterBytes, 0, parameterBytes.Length);
			reqStream.Close();

			Stream resStream = request.GetResponse().GetResponseStream();
			string result = (new StreamReader(resStream)).ReadToEnd();
			resStream.Close();

			return result;
		}

        /// <summary>
        /// Получить идентификатор игрока
        /// </summary>
        /// <param name="search">Ник</param>
        /// <returns>ID игрока</returns>
        public static int GetPlayerID(string search)
		{
			const string url = "https://api.worldoftanks.asia/wot/account/list/";
			var param = new Dictionary<string, string>();
			param.Add("application_id", consts.application_id);
			param.Add("search", search);
			param.Add("language", "en");
			string jsonString = APIRequest(url, param);
			dynamic parsedJson = JValue.Parse(jsonString);
			return parsedJson.data[0].account_id;
		}

        /// <summary>
        /// Получает данные боевой записи, сохраняет текущую дату и время в виде имени файла
        /// </summary>
        /// <param name="account_id"></param>
        public static void SaveVehicleStatistics(int account_id)
		{
			const string url = "https://api.worldoftanks.asia/wot/tanks/stats/";
			var param = new Dictionary<string, string>();
			param.Add("application_id", consts.application_id);
			param.Add("account_id", account_id.ToString());
			param.Add("language", "en");

			string path = @"data\" + DateTime.Now.ToString(consts.DateFormat) + ".json";
			SendPOST(url, param, path);
		}

        /// <summary>
        /// Получить список данных танка
        /// </summary>
        /// <returns></returns>
        public static Encyclopedia.Tanks GetListOfVehicles()
		{
			const string url = "https://api.worldoftanks.asia/wot/encyclopedia/tanks/";
			var param = new Dictionary<string, string>();
			param.Add("application_id", consts.application_id);
			param.Add("language", "en");
			string jsonString = APIRequest(url, param);

			return Analyzer.DeserializeListOfVehicles(jsonString);
		}

	}
}