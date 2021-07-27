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
	public partial class TwoNumbersDialog : Form
	{
		public TwoNumbersDialog()
		{
			InitializeComponent();
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			int min = int.Parse(tbMin.Text);
			int max = int.Parse(tbMax.Text);
			PictureList.Focused.RecoverFragment(min, max);
			this.DialogResult = DialogResult.OK;
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
