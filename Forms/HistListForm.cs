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
	/// <summary>
	/// Form for displaying histogram in list mode. Docked to Picture Class.
	/// </summary>
	public partial class HistListForm : Form
	{
		private Picture handle;
		public HistListForm(Picture handle)
		{
			InitializeComponent();
			this.handle = handle;
			this.Text = "Histogram of " + handle.Filename;
			if (handle.IsGreyscale)
			{
				display.Columns["Black"].Visible = true;
			}
			else
			{
				display.Columns["Red"].Visible = true;
				display.Columns["Green"].Visible = true;
				display.Columns["Blue"].Visible = true;
			}
			this.refresh();
		}

		public void refresh()
		{
			for (int i = 0; i < 256; ++i)
			{
				display.Rows.Insert(i, i, handle.RedHistogram[i], handle.GreenHistogram[i], handle.BlueHistogram[i], handle.RedHistogram[i]);
			}
		}

		public void changeName()
		{
			this.Text = "Histogram of: " + handle.Filename;
		}

		private void HistListForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			handle.CloseHistogramList();
		}
	}
}
