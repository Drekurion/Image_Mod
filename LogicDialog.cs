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
	public partial class LogicDialog : Form
	{
		private Picture handle;
		public LogicDialog(Picture handle)
		{
			InitializeComponent();
			this.handle = handle;
			this.cbSurrounding.DataSource = Enum.GetValues(typeof(LogicWindowType));
			this.cbSurrounding.SelectedIndex = 0;
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			LogicWindowType win = (LogicWindowType)cbSurrounding.SelectedItem;
			handle.LogicFiltration(win);
			this.DialogResult = DialogResult.OK;
		}

		private void btCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
