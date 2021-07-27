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
	public class Picture
	{
		private Bitmap img;
		private Bitmap imgCopy;
		private string filename;

		private ImgForm imageDisplay = null; // Window displaying image
		private HistForm histogramDisplay = null; // Window displaying histogram
		private HistListForm histogramListDisplay = null;

		private Dictionary<string, int[]> histogram; // 3 histograms: red, green, blue

		private bool isGreyscale = false;
		private bool isModified = false;
		private bool isCreated = false;

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

		//Functions

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
		}

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
					if(red > 255) red = 255;
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

		public void Threshold(int[] thresholds, int[] values)
		{
			if (thresholds.Length != values.Length) throw new ArgumentException();
			Image<Gray, byte> image = Img.ToImage<Gray, Byte>();
			Gray th = new Gray(128);
			for(int x = 0; x < image.Height; ++x)
			{
				for(int y = 0; y < image.Width; ++y)
				{
					Gray value = new Gray(255);
					Gray pixel = image[x, y];
					for(int i = thresholds.Length - 1; i >= 0; --i)
					{
						if (pixel.Intensity <= thresholds[i])
						{
							if(values[i] < 0)
							{
								value.Intensity = pixel.Intensity;
							}
							else
							{
								value.Intensity = values[i];
							}
						}
					}
					image[x, y] = value;
				}
			}
			MakeChanges(image.ToBitmap());
		}

		public void AdaptiveThresholding(int size)
		{
			Image<Bgr, Byte> imgCV = Img.ToImage<Bgr, byte>();
			Image<Bgr, Byte> newImg;
			newImg = imgCV.ThresholdAdaptive(new Bgr(255, 255, 255), Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC, Emgu.CV.CvEnum.ThresholdType.Binary, size, new Bgr(5,5,5));
			MakeChanges(newImg.ToBitmap());
		}
		
		public void OtsuThresholding()
		{
			this.GaussianBlur(5);
			Image<Gray, Byte> imgCV = Img.ToImage<Gray, byte>();
			Image<Gray, Byte> newImg = new Image<Gray, byte>(imgCV.Size);
			CvInvoke.Threshold(imgCV, newImg, 0, 255, Emgu.CV.CvEnum.ThresholdType.Otsu);
			MakeChanges(newImg.ToBitmap());
		}
		
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
			CvInvoke.GaussianBlur(imgCV, newImg, new Size(size,size), 0);
			MakeChanges(newImg.ToBitmap());
		}
		
		public void Laplacian()
		{
			Image<Bgr, double> imgCV = img.ToImage<Bgr, double>();
			Image<Bgr, double> newImg = new Image<Bgr, double>(imgCV.Size);
			CvInvoke.Laplacian(imgCV, newImg, Emgu.CV.CvEnum.DepthType.Cv64F);
			MakeChanges(newImg.ToBitmap());
		}

		public void Sobel(int xorder, int yorder)
		{
			Image<Bgr, double> imgCV = img.ToImage<Bgr, double>();
			Image<Bgr, double> newImg = new Image<Bgr, double>(imgCV.Size);
			CvInvoke.Sobel(imgCV, newImg, Emgu.CV.CvEnum.DepthType.Cv64F, xorder, yorder);
			MakeChanges(newImg.ToBitmap());
		}

		public void Canny(double threshold1, double threshold2)
		{
			Image<Gray, Byte> imgCV = img.ToImage<Gray, Byte>();
			Image<Gray, Byte> newImg = new Image<Gray, byte>(imgCV.Size);
			CvInvoke.Canny(imgCV, newImg, threshold1, threshold2, 3, true);
			MakeChanges(newImg.ToBitmap());
		}

		public void MedianBlur(int filterSize)
		{
			Image<Bgr, Byte> imgCV = img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(imgCV.Size);
			CvInvoke.MedianBlur(imgCV, newImg, filterSize);
			MakeChanges(newImg.ToBitmap());
		}
		public void Morphology(Emgu.CV.CvEnum.MorphOp morphOp, Emgu.CV.CvEnum.ElementShape elementShape, Emgu.CV.CvEnum.BorderType borderType, int size )
		{
			Size s = new Size(size, size);
			Point p = new Point(-1, -1);
			Mat kernel = CvInvoke.GetStructuringElement(elementShape, s, p);
			Image<Bgr, Byte> imgCV = img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(imgCV.Size);
			CvInvoke.MorphologyEx(imgCV,newImg,morphOp,kernel,p,1,borderType,new MCvScalar());
			MakeChanges(newImg.ToBitmap());
		}

		public void Filtration(IInputArray kernel)
		{
			Image<Bgr, Byte> imgCV = img.ToImage<Bgr, Byte>();
			Image<Bgr, Byte> newImg = new Image<Bgr, byte>(imgCV.Size);
			CvInvoke.Filter2D(imgCV, newImg, kernel, new Point(-1, -1), 0, Emgu.CV.CvEnum.BorderType.Replicate);
			MakeChanges(newImg.ToBitmap());
		}

		public void Skeletization()
		{
			Image<Gray, Byte> imgCV = img.ToImage<Gray, Byte>();
			Image<Gray, Byte> skel = new Image<Gray, byte>(imgCV.Size);
			skel.SetZero();
			Point anchor = new Point(-1, -1);
			Mat kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Cross,new Size(3,3),anchor);
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

		public void Watershed()
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
			CvInvoke.DistanceTransform(imgOpen, dist_transform, null, Emgu.CV.CvEnum.DistType.L2,5);
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
		// Display

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
		// Undos all made changes
		public void Undo()
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
		//Executed when closing image window, closes all related windows
		public void Close()
		{
			if(this.histogramDisplay != null)
			{
				this.histogramDisplay.Close();
			}
			if(this.histogramListDisplay != null)
			{
				this.histogramListDisplay.Close();
			}
			PictureList.All.Remove(Path);
			if(PictureList.Focused == this)
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

		//Saves changed image and refreshes all related windows
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
		private string CreateNewFilename(string path)
		{
			int i = 1;
			StringBuilder sb = new StringBuilder();
			sb.Append(System.IO.Path.GetDirectoryName(path));
			sb.Append("\\");
			sb.Append(System.IO.Path.GetFileNameWithoutExtension(path));
			while(PictureList.All.ContainsKey(sb.ToString()+"("+i+")"+System.IO.Path.GetExtension(path)))
			{
				i++;
			}
			sb.Append("(" + i + ")");
			sb.Append(System.IO.Path.GetExtension(path));
			return sb.ToString();
		}

		public void Save(string filename)
		{
			Bitmap bitmap = new Bitmap(this.img);
			this.img.Dispose();
			this.imgCopy.Dispose();
			if(System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			bitmap.Save(filename);
			this.img = new Bitmap(bitmap);
			this.imgCopy = new Bitmap(bitmap);
			bitmap.Dispose();
			if(this.filename != filename)
			{
				PictureList.All.Remove(this.filename);
				this.filename = filename;
				PictureList.All.Add(this.filename, this);
			}
			this.isModified = false;
			this.isCreated = false;
			this.imageDisplay.changeName();
			if(this.histogramDisplay != null)
			{
				this.histogramDisplay.changeName();
			}
			if (this.histogramListDisplay != null)
			{
				this.histogramListDisplay.changeName();
			}
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
								if(window[0].Intensity == window[1].Intensity)
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
								if( (window[0].Intensity == window[1].Intensity) && (window[0].Intensity == window[2].Intensity) && (window[0].Intensity == window[3].Intensity))
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
		/*public void LogicFiltration(LogicOperationType logicOperationType, LogicWindowType logicWindowType)
		{
			Image<Gray, Byte> image = Img.ToImage<Gray,Byte>();
			image = image.ThresholdBinary(new Gray(127), new Gray(255));
			int[] window;
			switch(logicWindowType)
			{
				case LogicWindowType.Horizontal:
					{
						window = new int[3];
						for(int i = 0; i < image.Height; ++i)
						{
							for(int j = 1; j < image.Width - 1;++j)
							{
								window[0] = (int)image[j - 1, i].Intensity;
								window[1] = (int)image[j, i].Intensity;
								window[2] = (int)image[j + 1, i].Intensity;
								window = logicOperation(window, logicOperationType);
								image[j, i] = new Gray(window[1]);
							}
						}
						break;
					}
				case LogicWindowType.Vertical:
					{
						window = new int[3];
						for (int i = 1; i < image.Height - 1; ++i)
						{
							for (int j = 0; j < image.Width; ++j)
							{
								window[0] = (int)image[j, i - 1].Intensity;
								window[1] = (int)image[j, i].Intensity;
								window[2] = (int)image[j, i + 1].Intensity;
								window = logicOperation(window, logicOperationType);
								image[j, i] = new Gray(window[1]);
							}
						}
						break;
					}
				case LogicWindowType.Star:
				{
						window = new int[9];
						for (int i = 1; i < image.Height - 1; ++i)
						{
							for (int j = 1; j < image.Width - 1; ++j)
							{
								window[1] = (int)image[j, i - 1].Intensity;
								window[3] = (int)image[j - 1, i].Intensity;
								window[4] = (int)image[j, i].Intensity;
								window[5] = (int)image[j + 1, i].Intensity;
								window[7] = (int)image[j, i + 1].Intensity;
								window = logicOperationStar(window, logicOperationType);
								image[j, i] = new Gray(window[4]);
							}
						}
						break;
				}
			}
			MakeChanges(image.ToBitmap());
		}
		private int[] logicOperationStar(int[] window, LogicOperationType logicOperationType)
		{
			bool a = Convert.ToBoolean(window[3]);
			bool b = Convert.ToBoolean(window[1]);
			bool c = Convert.ToBoolean(window[5]);
			bool d = Convert.ToBoolean(window[7]);
			switch (logicOperationType)
			{
				case LogicOperationType.AND:
					{
						if (a && b && c && d)
						{
							window[4] = window[3];
						}
						break;
					}
				case LogicOperationType.OR:
					{
						if (a || b || c || d)
						{
							window[4] = window[3];
						}
						break;
					}
				case LogicOperationType.NOT:
					{
						if ((a != b) && (a != c) && (a != d))
						{
							window[4] = window[3];
						}
						break;
					}
				case LogicOperationType.XOR:
					{
						if (a ^ b ^ c ^ d)
						{
							window[4] = window[3];
						}
						break;
					}
				case LogicOperationType.NXOR:
					{
						if (!(a ^ b) && !(a ^ c) && !(a ^ d))
						{
							window[4] = window[3];
						}
						break;
					}
				default:
					throw new ArgumentNullException();
			}
			return window;
		}
		private int[] logicOperation(int[] window, LogicOperationType logicOperationType)
		{
			bool a = Convert.ToBoolean(window[0]);
			bool b = Convert.ToBoolean(window[2]);
			switch (logicOperationType)
			{
				case LogicOperationType.AND:
					{
						if (a && b)
						{
							window[1] = window[0];
						}
						break;
					}
				case LogicOperationType.OR:
					{
						if (a || b)
						{
							window[1] = window[0];
						}
						break;
					}
				case LogicOperationType.NOT:
					{
						if (a != b)
						{
							window[1] = window[0];
						}
						break;
					}
				case LogicOperationType.XOR:
					{
						if (a ^ b)
						{
							window[1] = window[0];
						}
						break;
					}
				case LogicOperationType.NXOR:
					{
						if (!(a ^ b))
						{
							window[1] = window[0];
						}
						break;
					}
				default:
					throw new ArgumentNullException();
			}
			return window;
		}
		*/
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
		}

		// Getters

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
	}
}
