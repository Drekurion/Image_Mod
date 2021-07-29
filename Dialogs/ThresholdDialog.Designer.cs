
namespace APO_Projekt
{
	partial class ThresholdDialog
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
			this.tbT1 = new System.Windows.Forms.TextBox();
			this.tbV1 = new System.Windows.Forms.TextBox();
			this.labelT1 = new System.Windows.Forms.Label();
			this.labelV1 = new System.Windows.Forms.Label();
			this.cb0 = new System.Windows.Forms.CheckBox();
			this.btAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btOK
			// 
			this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btOK.Location = new System.Drawing.Point(12, 53);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(75, 23);
			this.btOK.TabIndex = 0;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.Location = new System.Drawing.Point(366, 53);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// tbT1
			// 
			this.tbT1.Location = new System.Drawing.Point(228, 12);
			this.tbT1.Name = "tbT1";
			this.tbT1.Size = new System.Drawing.Size(100, 20);
			this.tbT1.TabIndex = 2;
			// 
			// tbV1
			// 
			this.tbV1.Location = new System.Drawing.Point(59, 12);
			this.tbV1.Name = "tbV1";
			this.tbV1.Size = new System.Drawing.Size(100, 20);
			this.tbV1.TabIndex = 6;
			// 
			// labelT1
			// 
			this.labelT1.AutoSize = true;
			this.labelT1.Location = new System.Drawing.Point(165, 16);
			this.labelT1.Name = "labelT1";
			this.labelT1.Size = new System.Drawing.Size(57, 13);
			this.labelT1.TabIndex = 10;
			this.labelT1.Text = "Threshold:";
			// 
			// labelV1
			// 
			this.labelV1.AutoSize = true;
			this.labelV1.Location = new System.Drawing.Point(16, 16);
			this.labelV1.Name = "labelV1";
			this.labelV1.Size = new System.Drawing.Size(37, 13);
			this.labelV1.TabIndex = 14;
			this.labelV1.Text = "Value:";
			// 
			// cb0
			// 
			this.cb0.AutoSize = true;
			this.cb0.Location = new System.Drawing.Point(348, 14);
			this.cb0.Name = "cb0";
			this.cb0.Size = new System.Drawing.Size(69, 17);
			this.cb0.TabIndex = 15;
			this.cb0.Text = "Posterize";
			this.cb0.UseVisualStyleBackColor = true;
			this.cb0.CheckedChanged += new System.EventHandler(this.cb_CheckedChanged);
			// 
			// btAdd
			// 
			this.btAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btAdd.Location = new System.Drawing.Point(189, 53);
			this.btAdd.Name = "btAdd";
			this.btAdd.Size = new System.Drawing.Size(75, 23);
			this.btAdd.TabIndex = 16;
			this.btAdd.Text = "Add";
			this.btAdd.UseVisualStyleBackColor = true;
			this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
			// 
			// ThresholdDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 88);
			this.Controls.Add(this.btAdd);
			this.Controls.Add(this.cb0);
			this.Controls.Add(this.labelV1);
			this.Controls.Add(this.labelT1);
			this.Controls.Add(this.tbV1);
			this.Controls.Add(this.tbT1);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.Name = "ThresholdDialog";
			this.Text = "ThresholdDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.TextBox tbT1;
		private System.Windows.Forms.TextBox tbV1;
		private System.Windows.Forms.Label labelT1;
		private System.Windows.Forms.Label labelV1;
		private System.Windows.Forms.CheckBox cb0;
		private System.Windows.Forms.Button btAdd;
	}
}