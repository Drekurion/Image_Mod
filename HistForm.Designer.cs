
namespace APO_Projekt
{
	partial class HistForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.display = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// display
			// 
			chartArea1.AxisX.Maximum = 255D;
			chartArea1.AxisX.Minimum = 0D;
			chartArea1.Name = "ChartArea1";
			this.display.ChartAreas.Add(chartArea1);
			this.display.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Enabled = false;
			legend1.Name = "Legend1";
			this.display.Legends.Add(legend1);
			this.display.Location = new System.Drawing.Point(0, 24);
			this.display.Name = "display";
			series1.ChartArea = "ChartArea1";
			series1.Color = System.Drawing.Color.Black;
			series1.Legend = "Legend1";
			series1.Name = "Black";
			series2.ChartArea = "ChartArea1";
			series2.Color = System.Drawing.Color.Red;
			series2.Enabled = false;
			series2.Legend = "Legend1";
			series2.Name = "Red";
			series3.ChartArea = "ChartArea1";
			series3.Color = System.Drawing.Color.Green;
			series3.Enabled = false;
			series3.Legend = "Legend1";
			series3.Name = "Green";
			series4.ChartArea = "ChartArea1";
			series4.Color = System.Drawing.Color.Blue;
			series4.Enabled = false;
			series4.Legend = "Legend1";
			series4.Name = "Blue";
			this.display.Series.Add(series1);
			this.display.Series.Add(series2);
			this.display.Series.Add(series3);
			this.display.Series.Add(series4);
			this.display.Size = new System.Drawing.Size(531, 317);
			this.display.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.blueToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(531, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// redToolStripMenuItem
			// 
			this.redToolStripMenuItem.Enabled = false;
			this.redToolStripMenuItem.Name = "redToolStripMenuItem";
			this.redToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.redToolStripMenuItem.Text = "Red";
			this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
			// 
			// greenToolStripMenuItem
			// 
			this.greenToolStripMenuItem.Enabled = false;
			this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
			this.greenToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.greenToolStripMenuItem.Text = "Green";
			this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
			// 
			// blueToolStripMenuItem
			// 
			this.blueToolStripMenuItem.Enabled = false;
			this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
			this.blueToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.blueToolStripMenuItem.Text = "Blue";
			this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
			// 
			// HistForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(531, 341);
			this.Controls.Add(this.display);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "HistForm";
			this.Text = "Histogram View";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart display;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
	}
}