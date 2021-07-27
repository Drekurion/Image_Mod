
namespace APO_Projekt
{
	partial class MorphologyDialog
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
			this.cbOperation = new System.Windows.Forms.ComboBox();
			this.cbBorderType = new System.Windows.Forms.ComboBox();
			this.cbShape = new System.Windows.Forms.ComboBox();
			this.cbSize = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btOK = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbOperation
			// 
			this.cbOperation.FormattingEnabled = true;
			this.cbOperation.Location = new System.Drawing.Point(86, 18);
			this.cbOperation.Name = "cbOperation";
			this.cbOperation.Size = new System.Drawing.Size(121, 21);
			this.cbOperation.TabIndex = 0;
			this.cbOperation.SelectedIndexChanged += new System.EventHandler(this.cbOperation_SelectedIndexChanged);
			// 
			// cbBorderType
			// 
			this.cbBorderType.FormattingEnabled = true;
			this.cbBorderType.Location = new System.Drawing.Point(86, 47);
			this.cbBorderType.Name = "cbBorderType";
			this.cbBorderType.Size = new System.Drawing.Size(121, 21);
			this.cbBorderType.TabIndex = 1;
			this.cbBorderType.SelectedIndexChanged += new System.EventHandler(this.cbBorderType_SelectedIndexChanged);
			// 
			// cbShape
			// 
			this.cbShape.FormattingEnabled = true;
			this.cbShape.Location = new System.Drawing.Point(254, 18);
			this.cbShape.Name = "cbShape";
			this.cbShape.Size = new System.Drawing.Size(121, 21);
			this.cbShape.TabIndex = 2;
			this.cbShape.SelectedIndexChanged += new System.EventHandler(this.cbShape_SelectedIndexChanged);
			// 
			// cbSize
			// 
			this.cbSize.FormattingEnabled = true;
			this.cbSize.Location = new System.Drawing.Point(254, 47);
			this.cbSize.Name = "cbSize";
			this.cbSize.Size = new System.Drawing.Size(121, 21);
			this.cbSize.TabIndex = 3;
			this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(30, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Operation:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Border Type:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(213, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Shape:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(224, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Size:";
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(21, 84);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(75, 23);
			this.btOK.TabIndex = 8;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btCancel
			// 
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Location = new System.Drawing.Point(300, 84);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 9;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// MorphologyDialog
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(408, 119);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbSize);
			this.Controls.Add(this.cbShape);
			this.Controls.Add(this.cbBorderType);
			this.Controls.Add(this.cbOperation);
			this.Name = "MorphologyDialog";
			this.Text = "MorfologyDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbOperation;
		private System.Windows.Forms.ComboBox cbBorderType;
		private System.Windows.Forms.ComboBox cbShape;
		private System.Windows.Forms.ComboBox cbSize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
	}
}