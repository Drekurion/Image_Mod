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
	public partial class MorphologyDialog : Form
	{
		Dictionary<string, Emgu.CV.CvEnum.MorphOp> operations = new Dictionary<string, Emgu.CV.CvEnum.MorphOp>() 
		{
			{"Erode", Emgu.CV.CvEnum.MorphOp.Erode},
			{"Dilate", Emgu.CV.CvEnum.MorphOp.Dilate },
			{"Open",  Emgu.CV.CvEnum.MorphOp.Open},
			{"Close", Emgu.CV.CvEnum.MorphOp.Close }
		};
		Dictionary<string, Emgu.CV.CvEnum.ElementShape> shapes = new Dictionary<string, Emgu.CV.CvEnum.ElementShape>()
		{
			{ "Cross", Emgu.CV.CvEnum.ElementShape.Cross },
			{"Ellipse", Emgu.CV.CvEnum.ElementShape.Ellipse},
			{"Rectangle", Emgu.CV.CvEnum.ElementShape.Rectangle }
		};
		Dictionary<string, Emgu.CV.CvEnum.BorderType> borderTypes = new Dictionary<string, Emgu.CV.CvEnum.BorderType>()
		{
			{ "Isolated", Emgu.CV.CvEnum.BorderType.Isolated},
			{ "Replicate", Emgu.CV.CvEnum.BorderType.Replicate },
			{ "Constant", Emgu.CV.CvEnum.BorderType.Constant },
			{ "Reflect", Emgu.CV.CvEnum.BorderType.Reflect }
		};
		string[] sizes = new string[] { "3", "5", "7", "11", "13", "15", "17", "19", "21" };
		bool isLoading = true;
		public MorphologyDialog()
		{
			InitializeComponent();
			this.cbOperation.Items.AddRange(operations.Keys.ToArray());
			this.cbOperation.SelectedIndex = 0;
			this.cbShape.Items.AddRange(shapes.Keys.ToArray());
			this.cbShape.SelectedIndex = 0;

			this.cbBorderType.Items.AddRange(borderTypes.Keys.ToArray());
			this.cbBorderType.SelectedIndex = 0;
			this.cbSize.Items.AddRange(sizes);
			this.cbSize.SelectedIndex = 0;
			isLoading = false;
		}
		private void ImageChange()
		{
			if(!isLoading)
			{
				PictureList.Focused.Revert();
				PictureList.Focused.Morphology(operations[cbOperation.SelectedItem.ToString()], shapes[cbShape.SelectedItem.ToString()], borderTypes[cbBorderType.SelectedItem.ToString()], int.Parse(cbSize.SelectedItem.ToString()));
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

		private void cbOperation_SelectedIndexChanged(object sender, EventArgs e)
		{
			ImageChange();
		}

		private void cbShape_SelectedIndexChanged(object sender, EventArgs e)
		{
			ImageChange();
		}

		private void cbBorderType_SelectedIndexChanged(object sender, EventArgs e)
		{
			ImageChange();
		}

		private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			ImageChange();
		}
	}
}
