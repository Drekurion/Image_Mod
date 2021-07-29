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
	public partial class PrewittDirectionDialog : Form
	{
		Emgu.CV.Matrix<int> kernel;
		public PrewittDirectionDialog()
		{
			InitializeComponent();
		}

		private void DisplayKernel()
		{
			txtDisplay.Text = "";
			for(int i = 0; i < kernel.Height; ++i)
			{
				for(int j = 0; j < kernel.Width; ++j)
				{
					txtDisplay.Text += kernel.Data[i, j].ToString() + " ";
				}
				txtDisplay.Text += Environment.NewLine;
			}
		}

		private void btNW_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			kernel = new Emgu.CV.Matrix<int>(new int[,] 
			{
				{ 1, 1, 1 },
				{ 1, -2, -1 },
				{ 1, -1, -1 }
			});
			DisplayKernel();
			PictureList.Focused.Filtration(kernel);
		}
		private void btN_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			kernel = new Emgu.CV.Matrix<int>(new int[,]
			{
				{ 1, 1, 1 },
				{ 1,-2, 1 },
				{ -1,-1,-1 }
			});
			DisplayKernel();
			PictureList.Focused.Filtration(kernel);
		}
		private void btNE_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			kernel = new Emgu.CV.Matrix<int>(new int[,]
			{
				{ 1, 1, 1 },
				{ -1, -2, 1 },
				{ -1, -1, 1 }
			});
			DisplayKernel();
			PictureList.Focused.Filtration(kernel);
		}

		private void btW_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			kernel = new Emgu.CV.Matrix<int>(new int[,]
			{
				{ 1, 1, -1 },
				{ 1, -2, -1 },
				{ 1, 1, -1 }
			});
			DisplayKernel();
			PictureList.Focused.Filtration(kernel);
		}

		private void btE_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			kernel = new Emgu.CV.Matrix<int>(new int[,]
			{
				{ -1, 1, 1 },
				{ -1, -2, 1 },
				{ -1, 1, 1 }
			});
			DisplayKernel();
			PictureList.Focused.Filtration(kernel);
		}

		private void btSW_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			kernel = new Emgu.CV.Matrix<int>(new int[,]
			{
				{ 1, -1, -1 },
				{ 1, -2, -1 },
				{ 1, 1, 1 }
			});
			DisplayKernel();
			PictureList.Focused.Filtration(kernel);
		}

		private void btS_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			kernel = new Emgu.CV.Matrix<int>(new int[,]
			{
				{ -1, -1, -1},
				{ 1, -2, 1},
				{ 1, 1, 1}
			});
			DisplayKernel();
			PictureList.Focused.Filtration(kernel);
		}

		private void btSE_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Revert();
			kernel = new Emgu.CV.Matrix<int>(new int[,]
			{
				{ -1, -1, 1 },
				{ -1, -2, 1 },
				{ 1, 1, 1 }
			});
			DisplayKernel();
			PictureList.Focused.Filtration(kernel);
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
	}
}
