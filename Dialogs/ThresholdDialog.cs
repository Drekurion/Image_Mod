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
	public partial class ThresholdDialog : Form
	{
		List<TextBox> tbValues = new List<TextBox>();
		List<TextBox> tbThresholds = new List<TextBox>();
		List<CheckBox> cbPosterize = new List<CheckBox>();
		Point startLocation = new Point(16, 12);
		List<int> p = new List<int>();
		List<int> q = new List<int>();
		public ThresholdDialog()
		{
			InitializeComponent();
			tbValues.Add(tbV1);
			tbThresholds.Add(tbT1);
			cbPosterize.Add(cb0);
		}

		private void AddThreshold()
		{
			startLocation.Y += 30;
			Label x = new Label();
			x.Location = new Point(startLocation.X, startLocation.Y + 4);
			x.Size = new Size(37, 13);
			x.Text = "Value:";
			x.Name = "labelV" + tbValues.Count;
			TextBox v = new TextBox();
			v.Location = new Point(startLocation.X + x.Width + 6, startLocation.Y);
			v.Size = new Size(100,20);
			v.Name = "tbV" + tbValues.Count;
			tbValues.Add(v);
			Label y = new Label();
			y.Location = new Point(startLocation.X + x.Width + v.Width + 12, startLocation.Y + 4);
			y.Size = new Size(57, 13);
			y.Text = "Threshold:";
			y.Name = "labelT" + tbThresholds.Count;
			TextBox t = new TextBox();
			t.Location = new Point(startLocation.X + x.Width + v.Width + y.Width + 18, startLocation.Y);
			t.Size = new Size(100, 20);
			t.Name = "tbT" + tbThresholds.Count;
			tbThresholds.Add(t);
			CheckBox p = new CheckBox();
			p.Location = new Point(startLocation.X + y.Width + v.Width + y.Width + t.Width + 18, startLocation.Y + 2);
			p.Size = new Size(69, 17);
			p.Name = "cb" + cbPosterize.Count;
			p.Text = "Posterize";
			p.CheckedChanged += new EventHandler(cb_CheckedChanged);
			cbPosterize.Add(p);
			this.Height += 30;
			this.Controls.Add(x);
			this.Controls.Add(v);
			this.Controls.Add(y);
			this.Controls.Add(t);
			this.Controls.Add(p);
		}

		private bool isSorted(List<int> list)
		{
			if (list.Count <= 1) return true;
			for(int i = 0; i < list.Count - 1; ++i)
			{
				if(list[i] > list[i + 1])
				{
					return false;
				}
			}
			return true;
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			try
			{
				for(int i = 0; i < tbValues.Count; ++i)
				{
					try
					{
						p.Add(int.Parse(tbThresholds[i].Text));
						if(cbPosterize[i].Checked)
						{
							q.Add(-1);
						}
						else
						{
							q.Add(int.Parse(tbValues[i].Text));
						}
					}
					catch(ArgumentNullException) {}
				}
				PictureList.Focused.Threshold(p.ToArray(),q.ToArray());
				this.DialogResult = DialogResult.OK;
			}
			catch(ArgumentException)
			{
				MessageBox.Show("Wrong values");
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void btAdd_Click(object sender, EventArgs e)
		{
			AddThreshold();
		}

		private void cb_CheckedChanged(object sender, EventArgs e)
		{
			int index = cbPosterize.IndexOf((CheckBox)sender);
			if(cbPosterize[index].Checked)
			{
				tbValues[index].Enabled = false;
			}
			else
			{
				tbValues[index].Enabled = true;
			}
		}
	}
}
