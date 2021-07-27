using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_Projekt
{
	public partial class HistForm : Form
	{
		private Picture handle;

		public HistForm(Picture handle)
		{
			InitializeComponent();
			this.handle = handle;
			this.Text = "Histogram of " + handle.Filename;
			if(!handle.IsGreyscale)
			{
				display.Series["Black"].Enabled = false;
				display.Series["Red"].Enabled = true;
				redToolStripMenuItem.Enabled = true;
				greenToolStripMenuItem.Enabled = true;
				blueToolStripMenuItem.Enabled = true;
			}
			this.refresh();
		}

		public void refresh()
		{
			display.Series["Black"].Points.Clear();
			display.Series["Red"].Points.Clear();
			display.Series["Green"].Points.Clear();
			display.Series["Blue"].Points.Clear();
			for (int i = 0; i < 256; ++i)
			{
				display.Series["Black"].Points.AddXY(i, handle.RedHistogram[i]);
				display.Series["Red"].Points.AddXY(i, handle.RedHistogram[i]);
				display.Series["Green"].Points.AddXY(i, handle.GreenHistogram[i]);
				display.Series["Blue"].Points.AddXY(i, handle.BlueHistogram[i]);
			}
		}
		public void changeName()
		{
			this.Text = "Histogram of: " + handle.Filename;
		}
		private void redToolStripMenuItem_Click(object sender, EventArgs e)
		{
			display.Series["Red"].Enabled = true;
			display.Series["Green"].Enabled = false;
			display.Series["Blue"].Enabled = false;
		}

		private void greenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			display.Series["Red"].Enabled = false;
			display.Series["Green"].Enabled = true;
			display.Series["Blue"].Enabled = false;
		}

		private void blueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			display.Series["Red"].Enabled = false;
			display.Series["Green"].Enabled = false;
			display.Series["Blue"].Enabled = true;
		}

		private void HistForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			handle.CloseHistogram();
		}
	}
}
