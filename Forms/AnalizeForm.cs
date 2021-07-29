using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;

namespace APO_Projekt
{
	public partial class AnalizeForm : Form
	{
		private Picture handle;
		private Image<Gray, Byte> Img;
		private Image<Bgr, Byte> displayImg;
		private VectorOfMat contours;
		public AnalizeForm(Picture handle)
		{
			InitializeComponent();
			this.handle = handle;
			this.Img = handle.Img.ToImage<Gray, Byte>();
			this.contours = new VectorOfMat();
			this.Img = this.Img.ThresholdBinary(new Gray(127), new Gray(255));
			CvInvoke.FindContours(Img, contours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
			int length = contours.Size;
			Random rnd = new Random();
			displayImg = Img.Convert<Bgr, Byte>();
			for (int i = 0; i < length; ++i)
			{
				CvInvoke.DrawContours(displayImg, contours, i, new MCvScalar(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 3);
			}
			pbDisplay.Image = displayImg.ToBitmap();
		}
		private void btMoments_Click(object sender, EventArgs e)
		{
			DataTableDialog dlg = new DataTableDialog(contours,DataTableDialogType.Moments);
			dlg.ShowDialog();
		}

		private void btCalc_Click(object sender, EventArgs e)
		{
			DataTableDialog dlg = new DataTableDialog(contours, DataTableDialogType.Diameter);
			dlg.ShowDialog();
		}

		private void btShapeAspects_Click(object sender, EventArgs e)
		{
			DataTableDialog dlg = new DataTableDialog(contours, DataTableDialogType.ShapeAspects);
			dlg.ShowDialog();
		}
	}
}
