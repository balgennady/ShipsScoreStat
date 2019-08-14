namespace ScoreView
{
	partial class TankOverView
	{
        /// <summary> 
        /// Обязательная дизайнерская переменная.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Очистить все используемые ресурсы
        /// </summary>
        /// <param name="disposing">Укажите true, чтобы уничтожить управляемый ресурс, в противном случае укажите false.</param>
        protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Код, созданный дизайнером компонентов

        /// <summary> 
        /// Этот метод необходим для поддержки дизайнера. 
        /// Не изменяйте содержимое этого метода в редакторе кода.
        /// </summary>
        private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			this.tankImagePictureBox = new System.Windows.Forms.PictureBox();
			this.tankNameLabel = new System.Windows.Forms.Label();
			this.TierLabel = new System.Windows.Forms.Label();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.WN8Label = new System.Windows.Forms.Label();
			this.winrateLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.tankImagePictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// tankImagePictureBox
			// 
			this.tankImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tankImagePictureBox.Location = new System.Drawing.Point(3, 3);
			this.tankImagePictureBox.MaximumSize = new System.Drawing.Size(160, 100);
			this.tankImagePictureBox.Name = "tankImagePictureBox";
			this.tankImagePictureBox.Size = new System.Drawing.Size(160, 100);
			this.tankImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.tankImagePictureBox.TabIndex = 0;
			this.tankImagePictureBox.TabStop = false;
			// 
			// tankNameLabel
			// 
			this.tankNameLabel.AutoSize = true;
			this.tankNameLabel.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.tankNameLabel.Location = new System.Drawing.Point(169, 3);
			this.tankNameLabel.Name = "tankNameLabel";
			this.tankNameLabel.Size = new System.Drawing.Size(61, 21);
			this.tankNameLabel.TabIndex = 1;
			this.tankNameLabel.Text = "name";
			// 
			// TierLabel
			// 
			this.TierLabel.AutoSize = true;
			this.TierLabel.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.TierLabel.Location = new System.Drawing.Point(169, 24);
			this.TierLabel.Name = "TierLabel";
			this.TierLabel.Size = new System.Drawing.Size(43, 21);
			this.TierLabel.TabIndex = 2;
			this.TierLabel.Text = "tier";
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.Transparent;
			chartArea1.BackColor = System.Drawing.Color.Transparent;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Enabled = false;
			legend1.Name = "Legend1";
			legend2.Enabled = false;
			legend2.Name = "Legend2";
			this.chart1.Legends.Add(legend1);
			this.chart1.Legends.Add(legend2);
			this.chart1.Location = new System.Drawing.Point(173, 48);
			this.chart1.Name = "chart1";
			this.chart1.Size = new System.Drawing.Size(510, 55);
			this.chart1.TabIndex = 3;
			this.chart1.Text = "chart1";
			this.chart1.Click += new System.EventHandler(this.chart1_Click);
			// 
			// WN8Label
			// 
			this.WN8Label.AutoSize = true;
			this.WN8Label.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.WN8Label.Location = new System.Drawing.Point(404, 24);
			this.WN8Label.Name = "WN8Label";
			this.WN8Label.Size = new System.Drawing.Size(49, 21);
			this.WN8Label.TabIndex = 5;
			this.WN8Label.Text = "wn8";
			// 
			// winrateLabel
			// 
			this.winrateLabel.AutoSize = true;
			this.winrateLabel.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.winrateLabel.Location = new System.Drawing.Point(404, 3);
			this.winrateLabel.Name = "winrateLabel";
			this.winrateLabel.Size = new System.Drawing.Size(33, 21);
			this.winrateLabel.TabIndex = 4;
			this.winrateLabel.Text = "wr";
			// 
			// TankOverView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.WN8Label);
			this.Controls.Add(this.winrateLabel);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.TierLabel);
			this.Controls.Add(this.tankNameLabel);
			this.Controls.Add(this.tankImagePictureBox);
			this.Name = "TankOverView";
			this.Size = new System.Drawing.Size(686, 106);
			this.Load += new System.EventHandler(this.TankDetail_Load);
			((System.ComponentModel.ISupportInitialize)(this.tankImagePictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox tankImagePictureBox;
		private System.Windows.Forms.Label tankNameLabel;
		private System.Windows.Forms.Label TierLabel;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label WN8Label;
		private System.Windows.Forms.Label winrateLabel;
	}
}
