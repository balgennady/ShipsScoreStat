using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ScoreView
{
	public partial class TankOverView : UserControl
	{
		public TankOverView()
		{
			InitializeComponent();
		}

		private void TankDetail_Load(object sender, EventArgs e)
		{

		}

		private Tanks.All StatsData;
		private Encyclopedia.Data TankData;
		private int Tank_id;

		public void Init(Tanks.Data[] data, Dictionary<string, Encyclopedia.Data> listOfVehicles, int tank_id)
		{
			Tank_id = tank_id;
			StatsData = data.FirstOrDefault(x => x.tank_id == tank_id).all;
			TankData = listOfVehicles[tank_id.ToString()];

			tankNameLabel.Text = TankData.name_i18n;
			TierLabel.Text = TankData.nation_i18n + " Tier " + TankData.level + " " + TankData.type_i18n;

			winrateLabel.Text = "勝率 : " + (StatsData.wins*100.0 / StatsData.battles).ToString("F2");
			WN8Label.Text = "WN8 : " + Analyzer.calculateWN8(Tank_id, StatsData).ToString("F2");

			InitTankImage();
			InitWinRateGraph();
		}

		private void InitTankImage()
		{
			string imageName = @"cache\" + Tank_id.ToString() + ".img";
			if (!File.Exists(imageName)) Network.SendGET(TankData.image, imageName);
			tankImagePictureBox.Image = Image.FromFile(imageName);
		}

		private void InitWinRateGraph()
		{
			var leg = new string[] { "勝利", "引き分け", "敗北" };
			chart1.Series.Clear();
			foreach (var item in leg)
			{
				chart1.Series.Add(item);
				chart1.Series[item].ChartType = SeriesChartType.StackedBar100;
				chart1.Series[item].LegendText = item;
			}

			string xAxis = StatsData.battles.ToString() + "戦";
			int[] yAxis = new int[] { StatsData.wins, StatsData.draws, StatsData.losses };
			for (int i = 0; i < yAxis.Length; i++)
			{
				//グラフに追加するデータクラスを生成
				var dp = new DataPoint();
				dp.SetValueXY(xAxis, yAxis[i]);  //XとYの値を設定
												 //dp.IsValueShownAsLabel = true;  //グラフに値を表示するように指定
				chart1.Series[leg[i]].Points.Add(dp);   //グラフにデータ追加
			}
		}

		private void chart1_Click(object sender, EventArgs e)
		{

		}
	}
}
