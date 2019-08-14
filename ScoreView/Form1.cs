using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreView
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		

		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				var r = Network.GetPlayerID(consts.nickname);
				var lv = Network.GetListOfVehicles();
				Tanks.Stats vs;
				UpdateVehicleStatistics(r);

				string[] vehicleStatisticsJsons = Directory.GetFiles(@"data\");
				Array.Sort(vehicleStatisticsJsons);

				using (var sr = new StreamReader(vehicleStatisticsJsons.LastOrDefault()))
				{
					vs = Analyzer.DeserializeVehicleStatistics(sr.ReadToEnd());
				}

				tankOverView1.Init(vs.data[r.ToString()], lv.data, 5377);
			}

			catch
			{
				return;
			}
		}

		private void UpdateVehicleStatistics(int account_id)
		{
			string[] vehicleStatisticsJsons = Directory.GetFiles(@"data\");
			Array.Sort(vehicleStatisticsJsons);
			string latestString = vehicleStatisticsJsons.LastOrDefault().Split('\\')[1].Split('.')[0];
			DateTime latest = DateTime.ParseExact(latestString, consts.DateFormat, null);
			TimeSpan diff = DateTime.Now - latest;
			if (diff > consts.UpdateInterval) Network.SaveVehicleStatistics(account_id);
		}

		private void tankDetail1_Load(object sender, EventArgs e)
		{

		}
	}
}
