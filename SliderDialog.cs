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
	public partial class SliderDialog : Form
	{
		private int[] values = new int[]{ 0, 255 };
		private int threshold;
		SliderDialogType type;
		private int prev = 3;
		public SliderDialog(SliderDialogType type)
		{
			InitializeComponent();
			this.threshold = new int();
			this.type = type;

			tbThreshold.Value = 3;
			tbThreshold.Minimum = 3;
			tbThreshold.Maximum = 255;
			tbThreshold.TickFrequency = 2;
			tbThreshold.SmallChange = 2;
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			PictureList.Focused.ApproveChanges();
			this.DialogResult = DialogResult.OK;
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			this.DialogResult = DialogResult.Cancel;
		}

		private void tbThreshold_Scroll(object sender, EventArgs e)
		{
			if(tbThreshold.Value % 2 == 0)
			{
				if (prev < tbThreshold.Value) tbThreshold.Value++;
				else if (prev > tbThreshold.Value) tbThreshold.Value--;
			}
			prev = tbThreshold.Value;
			txtDisplay.Text = tbThreshold.Value.ToString();
		}

		private void tbThreshold_MouseUp(object sender, MouseEventArgs e)
		{
			this.threshold = tbThreshold.Value;
			PictureList.Focused.Revert();
			if(type == SliderDialogType.AdaptiveThreshold)
			{
				PictureList.Focused.AdaptiveThresholding(threshold);
			}
			if(type == SliderDialogType.MedianBlur)
			{
				PictureList.Focused.MedianBlur(threshold);
			}
			if(type == SliderDialogType.Blur)
			{
				PictureList.Focused.Blur(threshold);
			}
			if(type == SliderDialogType.GaussBlur)
			{
				PictureList.Focused.GaussianBlur(threshold);
			}
		}

		private void tbThreshold_KeyUp(object sender, KeyEventArgs e)
		{
			tbThreshold_MouseUp(null, null);
		}
	}
}
