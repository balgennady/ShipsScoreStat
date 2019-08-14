using System;
using System.Windows.Forms;

namespace ScoreView
{
    static class Program
	{
        /// <summary>
        /// Основная точка входа для приложения.
        /// </summary>
        [STAThread]
		static void Main()
		{
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			return;
		}
	}
}
