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
		private int threshold;
		private readonly SliderDialogType type;
		private int prev = 3;
		public SliderDialog(SliderDialogType type)
		{
			InitializeComponent();
			this.threshold = new int();
			this.type = type;
			switch(type)
			{
				case SliderDialogType.Threshold:
					{
						tbThreshold.Minimum = 0;
						tbThreshold.Maximum = 255;
						tbThreshold.Value = 0;
						tbThreshold.TickFrequency = 1;
						tbThreshold.SmallChange = 2;
						break;
					}
				case SliderDialogType.Posterize:
					{
						tbThreshold.Minimum = 1;
						tbThreshold.Maximum = 16;
						tbThreshold.Value = 1;
						tbThreshold.TickFrequency = 1;
						tbThreshold.SmallChange = 2;
						break;
					}
				default:
					{
						tbThreshold.Minimum = 3;
						tbThreshold.Maximum = 255;
						tbThreshold.Value = 3;
						tbThreshold.TickFrequency = 2;
						tbThreshold.SmallChange = 2;
						break;
					}
			}
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
			switch(type)
			{
				// Preventing setting an even number.
				case SliderDialogType.GaussBlur:
				case SliderDialogType.AdaptiveThreshold:
				case SliderDialogType.MedianBlur:
					{
						if(tbThreshold.Value % 2 == 0)
						{
							if (prev < tbThreshold.Value) tbThreshold.Value++;
							else if (prev > tbThreshold.Value) tbThreshold.Value--;
						}
						prev = tbThreshold.Value;
						break;
					}
			}
			txtDisplay.Text = tbThreshold.Value.ToString();
		}

		private void tbThreshold_MouseUp(object sender, MouseEventArgs e)
		{
			this.threshold = tbThreshold.Value;
			PictureList.Focused.Revert();
			switch(type)
			{
				case SliderDialogType.Blur:
					{
						PictureList.Focused.Blur(threshold);
						break;
					}
				case SliderDialogType.GaussBlur:
					{
						PictureList.Focused.GaussianBlur(threshold);
						break;
					}
				case SliderDialogType.Threshold:
					{
						PictureList.Focused.Thresholding(threshold);
						break;
					}
				case SliderDialogType.AdaptiveThreshold:
					{
						PictureList.Focused.AdaptiveThresholding(threshold);
						break;
					}
				case SliderDialogType.Posterize:
					{
						PictureList.Focused.Posterize(threshold);
						break;
					}
				case SliderDialogType.MedianBlur:
					{
						PictureList.Focused.MedianBlur(threshold);
						break;
					}
			}
		}

		private void tbThreshold_KeyUp(object sender, KeyEventArgs e)
		{
			tbThreshold_MouseUp(null, null);
		}
	}
}
