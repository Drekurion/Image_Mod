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
	public partial class ArrayDialog : Form
	{
		public Emgu.CV.Matrix<int> kernel;
		public ArrayDialog()
		{
			InitializeComponent();
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			kernel = Parse(txtKernel.Text);
			this.DialogResult = DialogResult.OK;
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private Emgu.CV.Matrix<int> Parse(string data)
		{
			Emgu.CV.Matrix<int> m = null;
			string[] Rows = data.Split("\r\n\v".ToArray(), StringSplitOptions.RemoveEmptyEntries);
			int row = Rows.Length;
			int col = 0;
			for(int r = 0; r < row; ++r)
			{
				string[] cols = Rows[r].Split("\t ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
				if (r <= 0)
				{
					col = cols.Length;
					m = new Emgu.CV.Matrix<int>(row, col);
				}
				else if (col != cols.Length) throw new ArgumentException("Unregular matrix data.");
				for(int c = 0; c < col; ++c)
				{
					m[r, c] = int.Parse(cols[c]);
				}
			}
			return m;
		}
	}
}
