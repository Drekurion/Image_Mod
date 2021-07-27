
namespace APO_Projekt
{
	partial class ImgForm
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
			this.display = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
			this.SuspendLayout();
			// 
			// display
			// 
			this.display.Dock = System.Windows.Forms.DockStyle.Fill;
			this.display.Location = new System.Drawing.Point(0, 0);
			this.display.Name = "display";
			this.display.Size = new System.Drawing.Size(294, 289);
			this.display.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.display.TabIndex = 0;
			this.display.TabStop = false;
			this.display.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
			this.display.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove_NotDown);
			// 
			// ImgForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 289);
			this.Controls.Add(this.display);
			this.Name = "ImgForm";
			this.Text = "Image View";
			this.Activated += new System.EventHandler(this.ImgForm_Activated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImgForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox display;
	}
}