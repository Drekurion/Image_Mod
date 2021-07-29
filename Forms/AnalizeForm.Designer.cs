
namespace APO_Projekt
{
	partial class AnalizeForm
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
			this.btMoments = new System.Windows.Forms.Button();
			this.btCalc = new System.Windows.Forms.Button();
			this.btShapeAspects = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pbDisplay = new System.Windows.Forms.PictureBox();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// btMoments
			// 
			this.btMoments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btMoments.Location = new System.Drawing.Point(3, 12);
			this.btMoments.Name = "btMoments";
			this.btMoments.Size = new System.Drawing.Size(90, 23);
			this.btMoments.TabIndex = 4;
			this.btMoments.Text = "Momenty";
			this.btMoments.UseVisualStyleBackColor = true;
			this.btMoments.Click += new System.EventHandler(this.btMoments_Click);
			// 
			// btCalc
			// 
			this.btCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btCalc.Location = new System.Drawing.Point(3, 41);
			this.btCalc.Name = "btCalc";
			this.btCalc.Size = new System.Drawing.Size(90, 23);
			this.btCalc.TabIndex = 5;
			this.btCalc.Text = "Pole i obwód";
			this.btCalc.UseVisualStyleBackColor = true;
			this.btCalc.Click += new System.EventHandler(this.btCalc_Click);
			// 
			// btShapeAspects
			// 
			this.btShapeAspects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btShapeAspects.Location = new System.Drawing.Point(3, 70);
			this.btShapeAspects.Name = "btShapeAspects";
			this.btShapeAspects.Size = new System.Drawing.Size(90, 43);
			this.btShapeAspects.TabIndex = 6;
			this.btShapeAspects.Text = "Współczynniki kształtu";
			this.btShapeAspects.UseVisualStyleBackColor = true;
			this.btShapeAspects.Click += new System.EventHandler(this.btShapeAspects_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btMoments);
			this.panel1.Controls.Add(this.btCalc);
			this.panel1.Controls.Add(this.btShapeAspects);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(344, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(96, 407);
			this.panel1.TabIndex = 8;
			// 
			// pbDisplay
			// 
			this.pbDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbDisplay.Location = new System.Drawing.Point(0, 0);
			this.pbDisplay.Name = "pbDisplay";
			this.pbDisplay.Size = new System.Drawing.Size(344, 407);
			this.pbDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbDisplay.TabIndex = 9;
			this.pbDisplay.TabStop = false;
			// 
			// AnalizeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 407);
			this.Controls.Add(this.pbDisplay);
			this.Controls.Add(this.panel1);
			this.Name = "AnalizeForm";
			this.Text = "AnalizeForm";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btMoments;
		private System.Windows.Forms.Button btCalc;
		private System.Windows.Forms.Button btShapeAspects;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pbDisplay;
	}
}