using System.Collections.Generic;

namespace ScoreView.Expected
{
    public class Header
	{
		public int version { get; set; }
	}

	public class Data
	{
		public int IDNum { get; set; }
		public double expFrag { get; set; }
		public double expDamage { get; set; }
		public double expSpot { get; set; }
		public double expDef { get; set; }
		public double expWinRate { get; set; }
	}

	public class Tanks
	{
		public Header header { get; set; }
		public List<Data> data { get; set; }
	}
}
