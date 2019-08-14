using System.Collections.Generic;

namespace ScoreView.Encyclopedia
{
    public class Meta
	{
		public int count { get; set; }
	}

	public class Data
	{
		public string nation_i18n { get; set; }
		public string name { get; set; }
		public int level { get; set; }
		public string image { get; set; }
		public string image_small { get; set; }
		public string nation { get; set; }
		public bool is_premium { get; set; }
		public string type_i18n { get; set; }
		public string contour_image { get; set; }
		public string short_name_i18n { get; set; }
		public string name_i18n { get; set; }
		public string type { get; set; }
		public int tank_id { get; set; }
	}

	public class Tanks
	{
		public string status { get; set; }
		public Meta meta { get; set; }
		public Dictionary<string,Data> data { get; set; }
	}

}
