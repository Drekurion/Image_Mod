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
	public partial class DataTableDialog : Form
	{
		public DataTableDialog(VectorOfMat cnt, DataTableDialogType dialogType)
		{
			InitializeComponent();
			int size = cnt.Size;
			display.Columns.Add("Title", "");
			if(dialogType == DataTableDialogType.Moments)
			{
				display.Columns.Add("M00","M00");
				display.Columns.Add("M01","M01");
				display.Columns.Add("M02","M02");
				display.Columns.Add("M03","M03");
				display.Columns.Add("M10","M10");
				display.Columns.Add("M11","M11");
				display.Columns.Add("M12","M12");
				display.Columns.Add("M20","M20");
				display.Columns.Add("M21","M21");
				display.Columns.Add("M30","M30");
				display.Columns.Add("Mu02","Mu02");
				display.Columns.Add("Mu03", "Mu03");
				display.Columns.Add("Mu11", "Mu11");
				display.Columns.Add("Mu12", "Mu12");
				display.Columns.Add("Mu20", "Mu20");
				display.Columns.Add("Mu21", "Mu21");
				display.Columns.Add("Mu30", "Mu30");
				for(int i = 0; i < size; ++i)
				{
					Moments moments = CvInvoke.Moments(cnt[i], true);
					display.Rows.Add("Obiekt" + (i + 1), moments.M00, moments.M01, moments.M02, moments.M03, moments.M10, moments.M11, moments.M12, moments.M20, moments.M21, moments.M30, moments.Mu02, moments.Mu03, moments.Mu11, moments.Mu12, moments.Mu20, moments.Mu21, moments.Mu30);
				}
			}
			if(dialogType == DataTableDialogType.Diameter)
			{
				display.Columns.Add("Area","Pole");
				display.Columns.Add("Circumference", "Obwód");
				for(int i = 0; i< size; ++i)
				{
					double area = CvInvoke.ContourArea(cnt[i]);
					double circ = CvInvoke.ArcLength(cnt[i], true);
					display.Rows.Add("Obiekt" + (i + 1), area, circ);
				}
			}
			if(dialogType == DataTableDialogType.ShapeAspects)
			{
				display.Columns.Add("aspectRatio", "aspectRatio");
				display.Columns.Add("extent", "extent");
				display.Columns.Add("solidity", "solidity");
				display.Columns.Add("equivalentDiameter", "Equivalent Diameter");
				for(int i = 0; i< size;++i)
				{
					double area = CvInvoke.ContourArea(cnt[i]);
					VectorOfPoint hull = new VectorOfPoint();
					CvInvoke.ConvexHull(cnt[i],hull);
					double hull_area = CvInvoke.ContourArea(hull);
					Rectangle rect = CvInvoke.BoundingRectangle(cnt[i]);
					
					double rect_area = rect.Width * rect.Height;

					double ratio = rect.Width / rect.Height;
					double extent = area / rect_area;
					double solidity = area / hull_area;
					double equi_diameter = Math.Sqrt(4 * area / Math.PI);
					display.Rows.Add("Obiekt" + (i + 1), ratio, extent, solidity, equi_diameter);
				}
			}
		}
	}
}
