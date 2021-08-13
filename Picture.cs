using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace APO_Projekt
{
	/// <summary>
	/// Main class holding an image and all the necessary forms and functions.
	/// </summary>
	public class Picture
	{
		private Bitmap img;
		private Bitmap imgCopy;
		private string filename;

		private ImgForm imageDisplay = null; // Window displaying image
		private HistForm histogramDisplay = null; // Window displaying histogram
		private HistListForm histogramListDisplay = null;

		private Dictionary<string, int[]> histogram; // 3 histograms: red, green, blue
		private History history = new History(); // Undo / Redo

		private bool isGreyscale = false;
		private bool isModified = false;
		private bool isCreated = false;

		#region Constructors
		public Picture(string filename)
		{
			this.img = new Bitmap(filename);
			this.imgCopy = new Bitmap(filename);
			this.filename = filename;
			this.imageDisplay = new ImgForm(this);
			this.imageDisplay.Show();
			this.histogram = CalculateHistogram();
			if(Enumerable.SequenceEqual(this.RedHistogram,this.GreenHistogram) && Enumerable.SequenceEqual(this.RedHistogram, this.BlueHistogram))
			{
				isGreyscale = true;
			}
		}
		/// <summary>
		/// Copying constructor.
		/// </summary>
		/// <param name="image">New image.</param>
		/// <param name="filename">Filename of old image to create a new name from.</param>
		public Picture(Bitmap image, string filename)
		{
			this.img = new Bitmap(image);
			this.imgCopy = new Bitmap(image);
			this.filename = CreateNewFilename(filename);
			this.isCreated = true;
			this.imageDisplay = new ImgForm(this);
			this.imageDisplay.Show();
			this.histogram = CalculateHistogram();
			if (Enumerable.SequenceEqual(this.RedHistogram, this.GreenHistogram) && Enumerable.SequenceEqual(this.RedHistogram, this.BlueHistogram))
			{
				isGreyscale = true;
			}
		}
		#endregion Constructors

		#region Functions

		#region Show Form
		public void ViewHistogram()
		{
			this.histogramDisplay = new HistForm(this);
			this.histogramDisplay.Show();
		}

		public void ViewHistogramList()
		{
			this.histogramListDisplay = new HistListForm(this);
			this.histogramListDisplay.Show();
		}
		#endregion Show Form

		#region Close Form
		/// <summary>
		/// Executed when closing image window, closes all related windows.
		/// </summary>
		public void Close()
		{
			if (this.histogramDisplay != null)
			{
				this.histogramDisplay.Close();
			}
			if (this.histogramListDisplay != null)
			{
				this.histogramListDisplay.Close();
			}
			PictureList.All.Remove(Path);
			if (PictureList.Focused == this)
			{
				PictureList.Focused = null;
			}
			this.img.Dispose();
			this.imgCopy.Dispose();
		}

		public void CloseHistogram()
		{
			this.histogramDisplay = null;
		}

		public void CloseHistogramList()
		{
			this.histogramListDisplay = null;
		}

		#endregion Close Form

		#region Undo/Redo

		/// <summary>
		/// Undos all made changes.
		/// </summary>
		public void Revert()
		{
			this.img = new Bitmap(this.imgCopy);
			this.histogram = CalculateHistogram();
			this.isModified = false;
			if (this.imageDisplay != null)
			{
				this.imageDisplay.refresh();
			}
			if (this.histogramDisplay != null)
			{
				this.histogramDisplay.refresh();
			}
		}
		public void Undo()
		{
			if (!history.UndoEmpty)
			{
				img = history.Undo(imgCopy);
				imgCopy = new Bitmap(img);
			}
		}

		public void Redo()
		{
			if (!history.RedoEmpty)
			{
				img = history.Redo(imgCopy);
				imgCopy = new Bitmap(img);
			}
		}

		#endregion Undo/Redo

		#region Apply Changes

		/// <summary>
		/// Saves changed image and refreshes all related windows.
		/// </summary>
		/// <param name="newImg">Image to be saved.</param>
		private void MakeChanges(Bitmap newImg)
		{
			this.img.Dispose();
			this.img = new Bitmap(newImg);
			this.isModified = true;
			this.histogram = CalculateHistogram();

			if (this.imageDisplay != null)
			{
				this.imageDisplay.refresh();
			}

			if (this.histogramDisplay != null)
			{
				this.histogramDisplay.refresh();
			}

			if (this.histogramListDisplay != null)
			{
				this.histogramListDisplay.refresh();
			}
			newImg.Dispose();
		}
		/// <summary>
		/// Approves changes made to image, so you can make different changes to it, as well as to use undo operation.
		/// </summary>
		public void ApproveChanges()
		{
			history.Add(this.imgCopy);
			this.imgCopy = new Bitmap(this.img);
		}
		#endregion Apply Changes

		/// <summary>
		/// Generates histogram for current image.
		/// </summary>
		/// <returns>3 histograms (int[256]) "red", "green", "blue".</returns>
		private Dictionary<string, int[]> CalculateHistogram()
		{
			Dictionary<string, int[]> histogram = new Dictionary<string, int[]>()
			{
				{"red",new int[256] },
				{"green",new int[256] },
				{"blue",new int[256] },
			};
			for (int x = 0; x < img.Width; ++x)
			{
				for (int y = 0; y < img.Height; ++y)
				{
					histogram["red"][img.GetPixel(x, y).R]++;
					histogram["green"][img.GetPixel(x, y).G]++;
					histogram["blue"][img.GetPixel(x, y).B]++;
				}
			}
			return histogram;
		}
		/// <summary>
		/// Creates new file path based on file path of another file.
		/// </summary>
		/// <param name="path">File path of similar image.</param>
		/// <returns>New filename</returns>
		private string CreateNewFilename(string path)
		{
			int i = 1;
			StringBuilder sb = new StringBuilder();
			sb.Append(System.IO.Path.GetDirectoryName(path));
			sb.Append("\\");
			sb.Append(System.IO.Path.GetFileNameWithoutExtension(path));
			while (PictureList.All.ContainsKey(sb.ToString() + "(" + i + ")" + System.IO.Path.GetExtension(path)))
			{
				i++;
			}
			sb.Append("(" + i + ")");
			sb.Append(System.IO.Path.GetExtension(path));
			return sb.ToString();
		}
		/// <summary>
		/// Save image to file. It will update the filename of the class.
		/// </summary>
		/// <param name="filename">File path where the image is saved.</param>
		public void Save(string filename)
		{
			Bitmap bitmap = new Bitmap(this.img);
			this.img.Dispose();
			this.imgCopy.Dispose();
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			bitmap.Save(filename);
			this.img = new Bitmap(bitmap);
			this.imgCopy = new Bitmap(bitmap);
			bitmap.Dispose();
			if (this.filename != filename)
			{
				PictureList.All.Remove(this.filename);
				this.filename = filename;
				PictureList.All.Add(this.filename, this);
			}
			this.isModified = false;
			this.isCreated = false;
			this.imageDisplay.changeName();
			if (this.histogramDisplay != null)
			{
				this.histogramDisplay.changeName();
			}
			if (this.histogramListDisplay != null)
			{
				this.histogramListDisplay.changeName();
			}
		}
		#endregion Functions

		#region Image Modification

		#region Histogram
		private int HistogramMinValue(int[] histogram)
		{
			int minValue = 0;
			for (int i = 0; i < 256; ++i)
			{
				if (histogram[i] != 0)
				{
					minValue = i;
					break;
				}
			}
			return minValue;
		}

		private int HistogramMaxValue(int[] histogram)
		{
			int maxValue = 255;

			for (int i = 255; i >= 0; --i)
			{
				if (histogram[i] != 0)
				{
					maxValue = i;
					break;
				}
			}
			return maxValue;
		}

		private int[] StretchingLUT(int[] histogram)
		{
			int minValue = HistogramMinValue(histogram);
			int maxValue = HistogramMaxValue(histogram);

			int[] result = new int[256];
			double a = 255.0 / (maxValue - minValue);
			for (int i = 0; i < 256; ++i)
			{
				result[i] = (int)(a * (i - minValue));
			}
			return result;
		}

		private int[] EqualizationLUT(int[] histogram, int size)
		{
			int minValue = HistogramMinValue(histogram);
			
			int[] result = new int[256];
			double sum = 0;
			for(int i = 0; i < 256; ++i)
			{
				sum += histogram[i];
				result[i] = (int)(((sum - minValue) / (size - minValue)) * 255.0);
			}
			return result;
		}

		public void StretchHistogram()
		{
			int[] redLUT = StretchingLUT(RedHistogram);
			int[] greenLUT = StretchingLUT(GreenHistogram);
			int[] blueLUT = StretchingLUT(BlueHistogram);
			Bitmap newImg = new Bitmap(Img.Width, Img.Height);
			for (int x = 0; x < Img.Width; ++x)
			{
				for (int y = 0; y < Img.Height; ++y)
				{
					Color pixel = Img.GetPixel(x, y);
					Color newpixel = Color.FromArgb(redLUT[pixel.R], greenLUT[pixel.G], blueLUT[pixel.B]);
					newImg.SetPixel(x, y, newpixel);
				}
			}
			MakeChanges(newImg);
			ApproveChanges();
		}

		public void EqualizeHistogram()
		{
			int size = Img.Width * Img.Height;
			int[] redLUT = EqualizationLUT(RedHistogram, size);
			int[] greenLUT = EqualizationLUT(GreenHistogram, size);
			int[] blueLUT = EqualizationLUT(BlueHistogram, size);
			Bitmap newImg = new Bitmap(Img.Width, Img.Height);
			for (int x = 0; x < Img.Width; ++x)
			{
				for (int y = 0; y < Img.Height; ++y)
				{
					Color pixel = Img.GetPixel(x, y);
					Color newpixel = Color.FromArgb(redLUT[pixel.R], greenLUT[pixel.G], blueLUT[pixel.B]);
					newImg.SetPixel(x, y, newpixel);
				}
			}
			MakeChanges(newImg);
			ApproveChanges();
		}
		public void RecoverFragment(int min, int max)
		{
			Image<Gray, Byte> image = Img.ToImage<Gray, Byte>();
			Bitmap NewImg = new Bitmap(Img.Width, Img.Height);
			for (int i = 0; i < Img.Width; ++i)
			{
				for (int j = 0; j < Img.Height; ++j)
				{
					int pixel = (int)image[j, i].Intensity;
					Color newpixel = Color.FromArgb(0, 0, 0);
					if (min < pixel && pixel < max)
					{
						newpixel = Color.FromArgb(255, 255, 255);
					}
					NewImg.SetPixel(i, j, newpixel);
				}
			}
			MakeChanges(NewImg);
			ApproveChanges();
		}
		#endregion Histogram

		#region Point Operations
		public void Negation()
		{
			Bitmap newImg = new Bitmap(Img.Width, Img.Height);
			for (int x = 0; x < Img.Width; ++x)
			{
				for (int y = 0; y < Img.Height; ++y)
				{
					Color pixel = Img.GetPixel(x, y);
					Color newpixel = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);
					newImg.SetPixel(x, y, newpixel);
				}
			}
			MakeChanges(newImg);
			ApproveChanges();
		}

		public void Thresholding(int threshold)
		{
			byte r, g, b;
			Bitmap newImg = new Bitmap(Img.Width, Img.Height);
			for (int x = 0; x < Img.Width; ++x)
			{
				for (int y = 0; y < Img.Height; ++y)
				{
					r = 0;
					g = 0;
					b = 0;
					Color pixel = Img.GetPixel(x, y);
					if (pixel.R > threshold) r = 255;
					if (pixel.G > threshold) g = 255;
					if (pixel.B > threshold) b = 255;
					Color newpixel = Color.FromArgb(r, g, b);
					newImg.SetPixel(x, y, newpixel);
				}
			}
			MakeChanges(newImg);
		}

		public void Posterize(int numberOfBins)
		{
			int step = (int)Math.Ceiling((decimal)255 / numberOfBins);
			int[] bins = new int[numberOfBins];
			for (int i = 0; i < numberOfBins; ++i)
			{
				bins[i] = i * step;
			}
			Bitmap newImg = new Bitmap(Img.Width, Img.Height);
			for (int x = 0; x < Img.Width; ++x)
			{
				for (int y = 0; y < Img.Height; ++y)
				{
					int r = 0;
					int g = 0;
					int b = 0;
					Color pixel = Img.GetPixel(x, y);
					int i = 0;
					for (; i < bins.Length - 1; ++i)
					{
						if (pixel.R > bins[i]) r = bins[i];
						if (pixel.G > bins[i]) g = bins[i];
						if (pixel.B > bins[i]) b = bins[i];
					}
					if (pixel.R > bins[i]) r = 255;
					if (pixel.G > bins[i]) g = 255;
					if (pixel.B > bins[i]) b = 255;
					Color newpixel = Color.FromArgb(r, g, b);
					newImg.SetPixel(x, y, newpixel);
				}
			}
			MakeChanges(newImg);
		}
		public void AdaptiveThresholding(int size)
		{
			Image<Bgr, Byte> imgCV = Img.ToImage<Bgr, byte>();
			Image<Bgr, Byte> newImg;
			newImg = imgCV.ThresholdAdaptive(new Bgr(255, 255, 255), Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Binary, size, new Bgr(5, 5, 5));
			MakeChanges(newImg.ToBitmap());
		}

		public void OtsuThresholding()
		{
			this.GaussianBlur(5);
			Image<Gray, Byte> imgCV = Img.ToImage<Gray, byte>();
			Image<Gray, Byte> newImg = new Image<Gray, byte>(imgCV.Size);
			CvInvoke.Threshold(imgCV, newImg, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);
			MakeChanges(newImg.ToBitmap());
			ApproveChanges();
		}
		public static Picture Add(Picture picture1, Picture picture2)
		{
			if (picture1.Img.Size != picture2.Img.Size) throw new ArgumentException("Pictures are in different size.");
			Size size = new Size(picture1.Img.Size.Width, picture1.Img.Size.Height);
			Bitmap newImg = new Bitmap(size.Width, size.Height);
			for (int x = 0; x < size.Width; ++x)
			{
				for (int y = 0; y < size.Height; ++y)
				{
					Color pixel1 = picture1.Img.GetPixel(x, y);
					Color pixel2 = picture2.Img.GetPixel(x, y);
					int red = pixel1.R + pixel2.R;
					if (red > 255) red = 255;
					int green = pixel1.G + pixel2.G;
					if (green > 255) green = 255;
					int blue = pixel1.B + pixel2.B;
					if (blue > 255) blue = 255;
					Color newpixel = Color.FromArgb(red, green, blue);
					newImg.SetPixel(x, y, newpixel);
				}
			}
			return new Picture(newImg, picture1.Path);
		}

		public static Picture Substract(Picture picture1, Picture picture2)
		{
			if (picture1.Img.Size != picture2.Img.Size) throw new ArgumentException("Pictures are in different size.");
			Size size = new Size(picture1.Img.Size.Width, picture1.Img.Size.Height);
			Bitmap newImg = new Bitmap(size.Width, size.Height);
			for (int x = 0; x < size.Width; ++x)
			{
				for (int y = 0; y < size.Height; ++y)
				{
					Color pixel1 = picture1.Img.GetPixel(x, y);
					Color pixel2 = picture2.Img.GetPixel(x, y);
					int red = pixel1.R - pixel2.R;
					if (red < 0) red = 0;
					int green = pixel1.G - pixel2.G;
					if (green < 0) green = 0;
					int blue = pixel1.B - pixel2.B;
					if (blue < 0) blue = 0;
					Color newpixel = Color.FromArgb(red, green, blue);
					newImg.SetPixel(x, y, newpixel);
				}
			}
			return new Picture(newImg, picture1.Path);
		}
		public static Picture BitwiseAND(Picture picture1, Picture picture2)
		{
			if (picture1.Img.Size != picture2.Img.Size) throw new ArgumentException("Pictures are in different size.");
			Image<Bgr, Byte> img1 = picture1.Img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> img2 = picture2.Img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(img1.Size);
			CvInvoke.BitwiseAnd(img1, img2, newImg);
			return new Picture(newImg.ToBitmap(), picture1.Path);
		}

		public static Picture BitwiseOR(Picture picture1, Picture picture2)
		{
			if (picture1.Img.Size != picture2.Img.Size) throw new ArgumentException("Pictures are in different size.");
			Image<Bgr, Byte> img1 = picture1.Img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> img2 = picture2.Img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(img1.Size);
			CvInvoke.BitwiseOr(img1, img2, newImg);
			return new Picture(newImg.ToBitmap(), picture1.Path);
		}

		public static Picture BitwiseXOR(Picture picture1, Picture picture2)
		{
			if (picture1.Img.Size != picture2.Img.Size) throw new ArgumentException("Pictures are in different size.");
			Image<Bgr, Byte> img1 = picture1.Img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> img2 = picture2.Img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(img1.Size);
			CvInvoke.BitwiseXor(img1, img2, newImg);
			return new Picture(newImg.ToBitmap(), picture1.Path);
		}
		#endregion Point Operations

		#region Neighbor Operations
		public void Blur(int size)
		{
			Point point = new Point(-1, -1);
			Image<Bgr, Byte> imgCV = Img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(imgCV.Size);
			CvInvoke.Blur(imgCV, newImg, new Size(size, size), point);
			MakeChanges(newImg.ToBitmap());
		}

		public void GaussianBlur(int size)
		{
			Image<Bgr, Byte> imgCV = Img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(imgCV.Size);
			CvInvoke.GaussianBlur(imgCV, newImg, new Size(size, size), 0);
			MakeChanges(newImg.ToBitmap());
		}

		public void MedianBlur(int filterSize)
		{
			Image<Bgr, Byte> imgCV = img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(imgCV.Size);
			CvInvoke.MedianBlur(imgCV, newImg, filterSize);
			MakeChanges(newImg.ToBitmap());
		}
		public void Laplacian()
		{
			Image<Bgr, double> imgCV = img.ToImage<Bgr, double>();
			Image<Bgr, double> newImg = new Image<Bgr, double>(imgCV.Size);
			CvInvoke.Laplacian(imgCV, newImg, Emgu.CV.CvEnum.DepthType.Cv64F);
			MakeChanges(newImg.ToBitmap());
			ApproveChanges();
		}

		public void Sobel(int xorder, int yorder)
		{
			Image<Bgr, double> imgCV = img.ToImage<Bgr, double>();
			Image<Bgr, double> newImg = new Image<Bgr, double>(imgCV.Size);
			CvInvoke.Sobel(imgCV, newImg, Emgu.CV.CvEnum.DepthType.Cv64F, xorder, yorder);
			MakeChanges(newImg.ToBitmap());
			ApproveChanges();
		}

		public void Canny(double threshold1, double threshold2)
		{
			Image<Gray, Byte> imgCV = img.ToImage<Gray, Byte>();
			Image<Gray, Byte> newImg = new Image<Gray, byte>(imgCV.Size);
			CvInvoke.Canny(imgCV, newImg, threshold1, threshold2, 3, true);
			MakeChanges(newImg.ToBitmap());
			ApproveChanges();
		}
		public void Filtration(IInputArray kernel)
		{
			Image<Bgr, Byte> imgCV = img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(imgCV.Size);
			CvInvoke.Filter2D(imgCV, newImg, kernel, new Point(-1, -1), 0, Emgu.CV.CvEnum.BorderType.Replicate);
			MakeChanges(newImg.ToBitmap());
		}
		public void LogicFiltration(LogicWindowType logicWindowType)
		{
			Image<Gray, Byte> image = Img.ToImage<Gray, Byte>();
			Gray[] window;
			switch (logicWindowType)
			{
				case LogicWindowType.Horizontal:
					{
						window = new Gray[2];
						for (int i = 0; i < image.Height; ++i)
						{
							for (int j = 1; j < image.Width - 1; ++j)
							{
								window[0] = image[i, j - 1];
								window[1] = image[i, j + 1];
								if (window[0].Intensity == window[1].Intensity)
								{
									image[i, j] = window[0];
								}
							}
						}
						break;
					}
				case LogicWindowType.Vertical:
					{
						window = new Gray[2];
						for (int i = 1; i < image.Height - 1; ++i)
						{
							for (int j = 0; j < image.Width; ++j)
							{
								window[0] = image[i - 1, j];
								window[1] = image[i + 1, j];
								if (window[0].Intensity == window[1].Intensity)
								{
									image[i, j] = window[0];
								}
							}
						}
						break;
					}
				case LogicWindowType.Star:
					{
						window = new Gray[4];
						for (int i = 1; i < image.Height - 1; ++i)
						{
							for (int j = 1; j < image.Width - 1; ++j)
							{
								window[0] = image[i - 1, j];
								window[1] = image[i, j + 1];
								window[2] = image[i + 1, j];
								window[3] = image[i, j - 1];
								if ((window[0].Intensity == window[1].Intensity) && (window[0].Intensity == window[2].Intensity) && (window[0].Intensity == window[3].Intensity))
								{
									image[i, j] = window[0];
								}
							}
						}
						break;
					}
			}
			MakeChanges(image.ToBitmap());
		}
		#endregion Neighbor Operations

		#region Morphology
		public void Morphology(Emgu.CV.CvEnum.MorphOp morphOp, Emgu.CV.CvEnum.ElementShape elementShape, Emgu.CV.CvEnum.BorderType borderType, int size)
		{
			Size s = new Size(size, size);
			Point p = new Point(-1, -1);
			Mat kernel = CvInvoke.GetStructuringElement(elementShape, s, p);
			Image<Bgr, Byte> imgCV = img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(imgCV.Size);
			CvInvoke.MorphologyEx(imgCV, newImg, morphOp, kernel, p, 1, borderType, new MCvScalar());
			MakeChanges(newImg.ToBitmap());
		}
		public void Skeletization()//TODO
		{
			Image<Gray, Byte> imgCV = img.ToImage<Gray, Byte>();
			Image<Gray, Byte> skel = new Image<Gray, byte>(imgCV.Size);
			skel.SetZero();
			Point anchor = new Point(-1, -1);
			Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross, new Size(3, 3), anchor);
			Image<Gray, Byte> imgTemp = new Image<Gray, byte>(imgCV.Size);
			Image<Gray, Byte> imgEroded = new Image<Gray, byte>(imgCV.Size);
			Image<Gray, Byte> imgOpen = new Image<Gray, byte>(imgCV.Size);
			do
			{
				imgOpen = imgCV.MorphologyEx(Emgu.CV.CvEnum.MorphOp.Open, kernel, anchor, 1, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar());
				CvInvoke.Subtract(imgCV, imgOpen, imgTemp);
				CvInvoke.Erode(imgCV, imgEroded, kernel, anchor, 1, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar());
				CvInvoke.BitwiseOr(skel, imgTemp, skel);
				imgCV = imgEroded.Copy();
			} while (CvInvoke.CountNonZero(imgCV) == 0);
			MakeChanges(skel.ToBitmap());
		}

		public void Watershed()//TODO
		{
			Image<Gray, byte> imgCV = img.ToImage<Gray, byte>();
			Image<Gray, byte> imgThresh = new Image<Gray, byte>(imgCV.Size);
			Matrix<float> kernel = new Matrix<float>(new float[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 });
			Point p = new Point(-1, -1);
			CvInvoke.Threshold(imgCV, imgThresh, 0, 255, Emgu.CV.CvEnum.ThresholdType.BinaryInv | Emgu.CV.CvEnum.ThresholdType.Otsu);
			Image<Gray, byte> imgOpen = new Image<Gray, byte>(imgCV.Size);
			CvInvoke.MorphologyEx(imgThresh, imgOpen, Emgu.CV.CvEnum.MorphOp.Open, kernel, p, 1, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar());
			Image<Gray, byte> sureBG = new Image<Gray, byte>(imgCV.Size);
			CvInvoke.Dilate(imgOpen, sureBG, kernel, p, 1, Emgu.CV.CvEnum.BorderType.Replicate, new MCvScalar());
			Image<Gray, float> dist_transform = new Image<Gray, float>(imgCV.Size);
			CvInvoke.DistanceTransform(imgOpen, dist_transform, null, Emgu.CV.CvEnum.DistType.L2, 5);
			MakeChanges(dist_transform.ToBitmap());
			Image<Gray, sbyte> sureFG = new Image<Gray, sbyte>(imgCV.Size);
			CvInvoke.Threshold(dist_transform, sureFG, 0.5 * HistogramMaxValue(RedHistogram), 255, Emgu.CV.CvEnum.ThresholdType.Binary);
			Image<Gray, byte> result = new Image<Gray, byte>(imgCV.Size);
			CvInvoke.Subtract(sureBG, sureFG, result, null, Emgu.CV.CvEnum.DepthType.Cv8U);
			Image<Gray, sbyte> markers = new Image<Gray, sbyte>(imgCV.Size);
			//int components = CvInvoke.ConnectedComponents(sureFG, markers);
			MakeChanges(result.ToBitmap());
			//TODO
		}
		#endregion Morphology

		#endregion Image Modification

		#region Getters

		public Bitmap Img
		{
			get { return this.img; }
		}
		public int[] RedHistogram
		{
			get { return histogram["red"]; }
		}
		public int[] GreenHistogram
		{
			get { return histogram["green"]; }
		}
		public int[] BlueHistogram
		{
			get { return histogram["blue"]; }
		}
		public bool IsGreyscale
		{
			get { return isGreyscale; }
		}
		public bool IsModified
		{
			get { return isModified; }
		}
		public bool IsCreated
		{
			get { return isCreated; }
		}
		public string Filename
		{
			get { return System.IO.Path.GetFileName(this.filename); }
		}
		public string Path
		{
			get { return this.filename; }
			set { this.filename = value; }
		}
		public string Extension
		{
			get { return System.IO.Path.GetExtension(this.filename); }
		}

		// Author: Drekurion
		// Image Processing Application - Main Class

		#endregion Getters

	}
}
