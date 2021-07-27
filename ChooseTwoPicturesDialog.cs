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
	public partial class ChooseTwoPicturesDialog : Form
	{
		public ChooseTwoPicturesDialog()
		{
			InitializeComponent();
			foreach(string key in PictureList.All.Keys)
			{
				file1.Items.Add(key);
				file2.Items.Add(key);
			}
			file1.SelectedItem = PictureList.Focused.Path;
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			if(file1.SelectedItem != null && file2.SelectedItem != null)
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
