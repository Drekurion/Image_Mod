
namespace APO_Projekt
{
	partial class SliderDialog
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
			this.btOK = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.tbThreshold = new System.Windows.Forms.TrackBar();
			this.txtDisplay = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).BeginInit();
			this.SuspendLayout();
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btOK.Location = new System.Drawing.Point(12, 62);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(75, 23);
			this.btOK.TabIndex = 2;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(360, 62);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 3;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// tbThreshold
			// 
			this.tbThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbThreshold.LargeChange = 8;
			this.tbThreshold.Location = new System.Drawing.Point(12, 11);
			this.tbThreshold.Maximum = 255;
			this.tbThreshold.Name = "tbThreshold";
			this.tbThreshold.Size = new System.Drawing.Size(423, 45);
			this.tbThreshold.TabIndex = 0;
			this.tbThreshold.Scroll += new System.EventHandler(this.tbThreshold_Scroll);
			this.tbThreshold.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbThreshold_KeyUp);
			this.tbThreshold.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbThreshold_MouseUp);
			// 
			// txtDisplay
			// 
			this.txtDisplay.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.txtDisplay.Location = new System.Drawing.Point(185, 65);
			this.txtDisplay.MaximumSize = new System.Drawing.Size(80, 20);
			this.txtDisplay.MinimumSize = new System.Drawing.Size(80, 20);
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.ReadOnly = true;
			this.txtDisplay.Size = new System.Drawing.Size(80, 20);
			this.txtDisplay.TabIndex = 1;
			// 
			// SliderDialog
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(447, 97);
			this.Controls.Add(this.txtDisplay);
			this.Controls.Add(this.tbThreshold);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SliderDialog";
			this.ShowIcon = false;
			this.Text = "Select value:";
			((System.ComponentModel.ISupportInitialize)(this.tbThreshold)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.TextBox txtDisplay;
		public System.Windows.Forms.TrackBar tbThreshold;
	}
}