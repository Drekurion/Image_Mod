
namespace APO_Projekt
{
	partial class HistListForm
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
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Red = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Green = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Blue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Black = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.display)).BeginInit();
			this.SuspendLayout();
			// 
			// display
			// 
			this.display.AllowUserToAddRows = false;
			this.display.AllowUserToDeleteRows = false;
			this.display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.display.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Value,
            this.Red,
            this.Green,
            this.Blue,
            this.Black});
			this.display.Dock = System.Windows.Forms.DockStyle.Fill;
			this.display.Location = new System.Drawing.Point(0, 0);
			this.display.Name = "display";
			this.display.ReadOnly = true;
			this.display.RowHeadersVisible = false;
			this.display.Size = new System.Drawing.Size(218, 407);
			this.display.TabIndex = 0;
			// 
			// Value
			// 
			this.Value.HeaderText = "Value";
			this.Value.Name = "Value";
			this.Value.ReadOnly = true;
			// 
			// Red
			// 
			this.Red.HeaderText = "Red Count";
			this.Red.Name = "Red";
			this.Red.ReadOnly = true;
			this.Red.Visible = false;
			// 
			// Green
			// 
			this.Green.HeaderText = "Green Count";
			this.Green.Name = "Green";
			this.Green.ReadOnly = true;
			this.Green.Visible = false;
			// 
			// Blue
			// 
			this.Blue.HeaderText = "Blue Count";
			this.Blue.Name = "Blue";
			this.Blue.ReadOnly = true;
			this.Blue.Visible = false;
			// 
			// Black
			// 
			this.Black.HeaderText = "Count";
			this.Black.Name = "Black";
			this.Black.ReadOnly = true;
			this.Black.Visible = false;
			// 
			// HistListForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(218, 407);
			this.Controls.Add(this.display);
			this.Name = "HistListForm";
			this.Text = "HistListForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistListForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.display)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView display;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.DataGridViewTextBoxColumn Red;
		private System.Windows.Forms.DataGridViewTextBoxColumn Green;
		private System.Windows.Forms.DataGridViewTextBoxColumn Blue;
		private System.Windows.Forms.DataGridViewTextBoxColumn Black;
	}
}