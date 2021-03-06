using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_Projekt
{
	/// <summary>
	/// Form being a main window of the program, allowing to use all functionalities of it. Contains only a toolbar mainly with references to functions from Picture class.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Activated(object sender, EventArgs e)
		{
			if(PictureList.Focused != null)
			{
				saveToolStripMenuItem.Enabled = true;
				saveAsToolStripMenuItem.Enabled = true;
				viewToolStripMenuItem.Enabled = true;
				histogramToolStripMenuItem.Enabled = true;
				pointOperationsToolStripMenuItem.Enabled = true;
				neighborOperationsToolStripMenuItem.Enabled = true;
				morfologyToolStripMenuItem.Enabled = true;
			}
			else
			{
				saveToolStripMenuItem.Enabled = false;
				saveAsToolStripMenuItem.Enabled = false;
				viewToolStripMenuItem.Enabled = false;
				histogramToolStripMenuItem.Enabled = false;
				pointOperationsToolStripMenuItem.Enabled = false;
				neighborOperationsToolStripMenuItem.Enabled = false;
				morfologyToolStripMenuItem.Enabled = false;
			}
		}

		#region File
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "Browse Images";
			dlg.DefaultExt = "bmp";
			dlg.Filter = "Image files (*.bmp ,*.jpg, *.jpeg, *.png, *.gif, *,tiff) | *.bmp; *.jpg; *.jpeg; *.png; *.gif; *,tiff";
			dlg.CheckFileExists = true;
			dlg.Multiselect = true;
			
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				foreach(string filename in dlg.FileNames)
				{
					if(!PictureList.All.ContainsKey(filename))
					{
						PictureList.All.Add(filename, new Picture(filename));
					}
					else
					{
						Bitmap bitmap = new Bitmap(filename);
						Picture picture = new Picture(bitmap, filename);
						PictureList.All.Add(picture.Path, picture);
						bitmap.Dispose();
					}
				}
				MainForm_Activated(null, null);
			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!PictureList.Focused.IsCreated)
			{
				PictureList.Focused.Save(PictureList.Focused.Path);
			}
			else
			{
				saveAsToolStripMenuItem_Click(sender, e);
			}
		}
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Save Image As...";
			dlg.DefaultExt = ".bmp";
			dlg.Filter = "Bitmap Image (*.bmp)|*.bmp|Gif Image (*.gif)|*.gif|JPEG Image (*.jpeg)|*.jpeg|Png Image (*.png)|*.png|Tiff Image (*.tiff)|*.tiff";
			dlg.FilterIndex = 1;
			dlg.FileName = PictureList.Focused.Filename;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				PictureList.Focused.Save(dlg.FileName);
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		#endregion File

		#region View

		private void undoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Undo();
		}
		private void redoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Redo();
		}

		private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Bitmap bitmap = new Bitmap(PictureList.Focused.Path);
			Picture picture = new Picture(bitmap, PictureList.Focused.Path);
			PictureList.All.Add(picture.Path, picture);
			bitmap.Dispose();
		}
		#endregion View

		#region Histogram
		private void showHistogramChartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.ViewHistogram();
		}

		private void showHistogramListToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.ViewHistogramList();
		}

		private void stretchHistogramToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.StretchHistogram();
		}

		private void equalizeHistogramToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.EqualizeHistogram();
		}
		private void recoverFragmentToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TwoNumbersDialog dlg = new TwoNumbersDialog();
			dlg.ShowDialog();
		}
		#endregion Histogram

		#region Point Operations

		private void negationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Negation();
		}

		private void thresholdingToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SliderDialog dlg = new SliderDialog(SliderDialogType.Threshold);
			dlg.ShowDialog();
		}

		private void posterizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SliderDialog dlg = new SliderDialog(SliderDialogType.Posterize);
			dlg.ShowDialog();
		}

		private void thresholdingAdaptiveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SliderDialog dlg = new SliderDialog(SliderDialogType.AdaptiveThreshold);
			dlg.ShowDialog();
		}

		private void thresholdingOtsuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.OtsuThresholding();
		}

		private void addingPicturesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChooseTwoPicturesDialog dlg = new ChooseTwoPicturesDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Picture newPicture = Picture.Add(PictureList.All[dlg.file1.Text], PictureList.All[dlg.file2.Text]);
					PictureList.All.Add(newPicture.Path, newPicture);
				}
				catch (ArgumentException x)
				{
					MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK);
				}
			}
		}

		private void substractingPicturesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChooseTwoPicturesDialog dlg = new ChooseTwoPicturesDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Picture newPicture = Picture.Substract(PictureList.All[dlg.file1.Text], PictureList.All[dlg.file2.Text]);
					PictureList.All.Add(newPicture.Path, newPicture);
				}
				catch (ArgumentException x)
				{
					MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK);
				}
			}
		}

		private void bitwiseANDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChooseTwoPicturesDialog dlg = new ChooseTwoPicturesDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Picture newPicture = Picture.BitwiseAND(PictureList.All[dlg.file1.Text], PictureList.All[dlg.file2.Text]);
					PictureList.All.Add(newPicture.Path, newPicture);
				}
				catch (ArgumentException x)
				{
					MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK);
				}
			}
		}

		private void bitwiseORToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChooseTwoPicturesDialog dlg = new ChooseTwoPicturesDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Picture newPicture = Picture.BitwiseOR(PictureList.All[dlg.file1.Text], PictureList.All[dlg.file2.Text]);
					PictureList.All.Add(newPicture.Path, newPicture);
				}
				catch (ArgumentException x)
				{
					MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK);
				}
			}
		}

		private void bitwiseXORToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChooseTwoPicturesDialog dlg = new ChooseTwoPicturesDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Picture newPicture = Picture.BitwiseXOR(PictureList.All[dlg.file1.Text], PictureList.All[dlg.file2.Text]);
					PictureList.All.Add(newPicture.Path, newPicture);
				}
				catch (ArgumentException x)
				{
					MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK);
				}
			}
		}
		#endregion Point Operations

		#region Neighbor Operations

		private void blurToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SliderDialog dlg = new SliderDialog(SliderDialogType.Blur);
			dlg.ShowDialog();
		}

		private void blurGaussianToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SliderDialog dlg = new SliderDialog(SliderDialogType.GaussBlur);
			dlg.ShowDialog();
		}
		private void blurMedianToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SliderDialog dlg = new SliderDialog(SliderDialogType.MedianBlur);
			dlg.ShowDialog();
		}
		private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Sobel(1, 0);
		}

		private void laplaceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Laplacian();
		}

		private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Canny(100, 200);
		}

		private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PrewittDirectionDialog dlg = new PrewittDirectionDialog();
			dlg.ShowDialog();
		}

		private void maskToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ArrayDialog dlg = new ArrayDialog();
			if(dlg.ShowDialog() == DialogResult.OK)
			{
				PictureList.Focused.Filtration(dlg.kernel);
				PictureList.Focused.ApproveChanges();
			}
		}
		private void logicFiltrationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LogicDialog dlg = new LogicDialog(PictureList.Focused);
			dlg.ShowDialog();
		}
		#endregion Neighbor Operations

		#region Morfology

		private void showMorfologyDialogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MorphologyDialog dlg = new MorphologyDialog();
			dlg.ShowDialog();
		}

		private void skeletizationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Skeletization();
		}

		private void watershedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PictureList.Focused.Watershed();
		}
		private void analizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AnalizeForm form = new AnalizeForm(PictureList.Focused);
			form.Show();
		}

		#endregion Morfology

		private void informacjaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Image Processing Application\nAuthor: Drekurion\nProject made for Image Processing Algorithms in 2021 on WSISIZ(WIT).\n");
		}
	}
}
