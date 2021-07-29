
namespace APO_Projekt
{
	partial class PrewittDirectionDialog
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
			this.btNW = new System.Windows.Forms.Button();
			this.btNE = new System.Windows.Forms.Button();
			this.btSE = new System.Windows.Forms.Button();
			this.btSW = new System.Windows.Forms.Button();
			this.btS = new System.Windows.Forms.Button();
			this.btE = new System.Windows.Forms.Button();
			this.btW = new System.Windows.Forms.Button();
			this.btN = new System.Windows.Forms.Button();
			this.txtDisplay = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(12, 149);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(75, 23);
			this.btOK.TabIndex = 0;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btCancel
			// 
			this.btCancel.Location = new System.Drawing.Point(250, 149);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// btNW
			// 
			this.btNW.Location = new System.Drawing.Point(12, 12);
			this.btNW.Name = "btNW";
			this.btNW.Size = new System.Drawing.Size(47, 32);
			this.btNW.TabIndex = 2;
			this.btNW.Text = "NW";
			this.btNW.UseVisualStyleBackColor = true;
			this.btNW.Click += new System.EventHandler(this.btNW_Click);
			// 
			// btNE
			// 
			this.btNE.Location = new System.Drawing.Point(118, 12);
			this.btNE.Name = "btNE";
			this.btNE.Size = new System.Drawing.Size(47, 32);
			this.btNE.TabIndex = 3;
			this.btNE.Text = "NE";
			this.btNE.UseVisualStyleBackColor = true;
			this.btNE.Click += new System.EventHandler(this.btNE_Click);
			// 
			// btSE
			// 
			this.btSE.Location = new System.Drawing.Point(118, 88);
			this.btSE.Name = "btSE";
			this.btSE.Size = new System.Drawing.Size(47, 32);
			this.btSE.TabIndex = 4;
			this.btSE.Text = "SE";
			this.btSE.UseVisualStyleBackColor = true;
			this.btSE.Click += new System.EventHandler(this.btSE_Click);
			// 
			// btSW
			// 
			this.btSW.Location = new System.Drawing.Point(12, 88);
			this.btSW.Name = "btSW";
			this.btSW.Size = new System.Drawing.Size(47, 32);
			this.btSW.TabIndex = 5;
			this.btSW.Text = "SW";
			this.btSW.UseVisualStyleBackColor = true;
			this.btSW.Click += new System.EventHandler(this.btSW_Click);
			// 
			// btS
			// 
			this.btS.Location = new System.Drawing.Point(65, 88);
			this.btS.Name = "btS";
			this.btS.Size = new System.Drawing.Size(47, 32);
			this.btS.TabIndex = 6;
			this.btS.Text = "S";
			this.btS.UseVisualStyleBackColor = true;
			this.btS.Click += new System.EventHandler(this.btS_Click);
			// 
			// btE
			// 
			this.btE.Location = new System.Drawing.Point(118, 50);
			this.btE.Name = "btE";
			this.btE.Size = new System.Drawing.Size(47, 32);
			this.btE.TabIndex = 7;
			this.btE.Text = "E";
			this.btE.UseVisualStyleBackColor = true;
			this.btE.Click += new System.EventHandler(this.btE_Click);
			// 
			// btW
			// 
			this.btW.Location = new System.Drawing.Point(12, 50);
			this.btW.Name = "btW";
			this.btW.Size = new System.Drawing.Size(47, 32);
			this.btW.TabIndex = 8;
			this.btW.Text = "W";
			this.btW.UseVisualStyleBackColor = true;
			this.btW.Click += new System.EventHandler(this.btW_Click);
			// 
			// btN
			// 
			this.btN.Location = new System.Drawing.Point(65, 12);
			this.btN.Name = "btN";
			this.btN.Size = new System.Drawing.Size(47, 32);
			this.btN.TabIndex = 9;
			this.btN.Text = "N";
			this.btN.UseVisualStyleBackColor = true;
			this.btN.Click += new System.EventHandler(this.btN_Click);
			// 
			// txtDisplay
			// 
			this.txtDisplay.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.txtDisplay.Location = new System.Drawing.Point(173, 12);
			this.txtDisplay.Multiline = true;
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.ReadOnly = true;
			this.txtDisplay.Size = new System.Drawing.Size(152, 108);
			this.txtDisplay.TabIndex = 10;
			// 
			// PrewittDirectionDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 184);
			this.Controls.Add(this.txtDisplay);
			this.Controls.Add(this.btN);
			this.Controls.Add(this.btW);
			this.Controls.Add(this.btE);
			this.Controls.Add(this.btS);
			this.Controls.Add(this.btSW);
			this.Controls.Add(this.btSE);
			this.Controls.Add(this.btNE);
			this.Controls.Add(this.btNW);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PrewittDirectionDialog";
			this.ShowIcon = false;
			this.Text = "Select Prewitt direction:";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Button btNW;
		private System.Windows.Forms.Button btNE;
		private System.Windows.Forms.Button btSE;
		private System.Windows.Forms.Button btSW;
		private System.Windows.Forms.Button btS;
		private System.Windows.Forms.Button btE;
		private System.Windows.Forms.Button btW;
		private System.Windows.Forms.Button btN;
		private System.Windows.Forms.TextBox txtDisplay;
	}
}