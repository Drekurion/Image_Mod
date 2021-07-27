
namespace APO_Projekt
{
	partial class DataTableDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.display = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
			this.SuspendLayout();
			// 
			// display
			// 
			this.display.AllowUserToAddRows = false;
			this.display.AllowUserToDeleteRows = false;
			this.display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.display.Dock = System.Windows.Forms.DockStyle.Fill;
			this.display.Location = new System.Drawing.Point(0, 0);
			this.display.Name = "display";
			this.display.ReadOnly = true;
			this.display.Size = new System.Drawing.Size(297, 210);
			this.display.TabIndex = 0;
			// 
			// DataTableDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(297, 210);
			this.Controls.Add(this.display);
			this.Name = "DataTableDialog";
			this.Text = "DataTableDialog";
			((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView display;
	}
}