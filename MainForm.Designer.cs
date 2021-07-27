
namespace APO_Projekt
{
	partial class MainForm
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
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ShowHistogramChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showHistogramListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stretchHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.equalizeHistogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recoverFragmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pointOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.negationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thresholdingAdaptiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.thresholdingOtsuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.addingPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.substractingPicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.bitwiseANDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bitwiseORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bitwiseXORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.neighborOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blurGaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blurMedianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.borderDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.laplaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cannyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.maskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.logicFiltrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.morfologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showMorfologyDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.skeletizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.watershedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.analizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.informacjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.pointOperationsToolStripMenuItem,
            this.neighborOperationsToolStripMenuItem,
            this.morfologyToolStripMenuItem,
            this.informacjaToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(733, 42);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 38);
			this.fileToolStripMenuItem.Text = "Plik";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.openToolStripMenuItem.Text = "Otwórz";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Enabled = false;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.saveToolStripMenuItem.Text = "Zapisz";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Enabled = false;
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.saveAsToolStripMenuItem.Text = "Zapisz jako...";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(210, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.closeToolStripMenuItem.Text = "Zamknij";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.duplicateToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 38);
			this.viewToolStripMenuItem.Text = "Widok";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.undoToolStripMenuItem.Text = "Cofnij";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
			// 
			// duplicateToolStripMenuItem
			// 
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
			this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.duplicateToolStripMenuItem.Text = "Utwórz kopię";
			this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
			// 
			// histogramToolStripMenuItem
			// 
			this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHistogramToolStripMenuItem,
            this.stretchHistogramToolStripMenuItem,
            this.equalizeHistogramToolStripMenuItem,
            this.recoverFragmentToolStripMenuItem});
			this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
			this.histogramToolStripMenuItem.Size = new System.Drawing.Size(75, 38);
			this.histogramToolStripMenuItem.Text = "Histogram";
			// 
			// showHistogramToolStripMenuItem
			// 
			this.showHistogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowHistogramChartToolStripMenuItem,
            this.showHistogramListToolStripMenuItem});
			this.showHistogramToolStripMenuItem.Name = "showHistogramToolStripMenuItem";
			this.showHistogramToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.showHistogramToolStripMenuItem.Text = "Wyświetl Histogram";
			// 
			// ShowHistogramChartToolStripMenuItem
			// 
			this.ShowHistogramChartToolStripMenuItem.Name = "ShowHistogramChartToolStripMenuItem";
			this.ShowHistogramChartToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.ShowHistogramChartToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.ShowHistogramChartToolStripMenuItem.Text = "Wykres";
			this.ShowHistogramChartToolStripMenuItem.Click += new System.EventHandler(this.showHistogramChartToolStripMenuItem_Click);
			// 
			// showHistogramListToolStripMenuItem
			// 
			this.showHistogramListToolStripMenuItem.Name = "showHistogramListToolStripMenuItem";
			this.showHistogramListToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.H)));
			this.showHistogramListToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.showHistogramListToolStripMenuItem.Text = "Lista";
			this.showHistogramListToolStripMenuItem.Click += new System.EventHandler(this.showHistogramListToolStripMenuItem_Click);
			// 
			// stretchHistogramToolStripMenuItem
			// 
			this.stretchHistogramToolStripMenuItem.Name = "stretchHistogramToolStripMenuItem";
			this.stretchHistogramToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.stretchHistogramToolStripMenuItem.Text = "Rozciąganie";
			this.stretchHistogramToolStripMenuItem.Click += new System.EventHandler(this.stretchHistogramToolStripMenuItem_Click);
			// 
			// equalizeHistogramToolStripMenuItem
			// 
			this.equalizeHistogramToolStripMenuItem.Name = "equalizeHistogramToolStripMenuItem";
			this.equalizeHistogramToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.equalizeHistogramToolStripMenuItem.Text = "Equalizacja";
			this.equalizeHistogramToolStripMenuItem.Click += new System.EventHandler(this.equalizeHistogramToolStripMenuItem_Click);
			// 
			// recoverFragmentToolStripMenuItem
			// 
			this.recoverFragmentToolStripMenuItem.Name = "recoverFragmentToolStripMenuItem";
			this.recoverFragmentToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.recoverFragmentToolStripMenuItem.Text = "Fragment histogramu";
			this.recoverFragmentToolStripMenuItem.Click += new System.EventHandler(this.recoverFragmentToolStripMenuItem_Click);
			// 
			// pointOperationsToolStripMenuItem
			// 
			this.pointOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.negationToolStripMenuItem,
            this.thresholdingToolStripMenuItem,
            this.thresholdingAdaptiveToolStripMenuItem,
            this.thresholdingOtsuToolStripMenuItem,
            this.toolStripMenuItem7,
            this.addingPicturesToolStripMenuItem,
            this.substractingPicturesToolStripMenuItem,
            this.toolStripMenuItem8,
            this.bitwiseANDToolStripMenuItem,
            this.bitwiseORToolStripMenuItem,
            this.bitwiseXORToolStripMenuItem});
			this.pointOperationsToolStripMenuItem.Name = "pointOperationsToolStripMenuItem";
			this.pointOperationsToolStripMenuItem.Size = new System.Drawing.Size(122, 38);
			this.pointOperationsToolStripMenuItem.Text = "Operacje punktowe";
			// 
			// negationToolStripMenuItem
			// 
			this.negationToolStripMenuItem.Name = "negationToolStripMenuItem";
			this.negationToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.negationToolStripMenuItem.Text = "Negacja";
			this.negationToolStripMenuItem.Click += new System.EventHandler(this.negationToolStripMenuItem_Click);
			// 
			// thresholdingToolStripMenuItem
			// 
			this.thresholdingToolStripMenuItem.Name = "thresholdingToolStripMenuItem";
			this.thresholdingToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.thresholdingToolStripMenuItem.Text = "Progowanie / Posteryzacja";
			this.thresholdingToolStripMenuItem.Click += new System.EventHandler(this.thresholdingToolStripMenuItem_Click);
			// 
			// thresholdingAdaptiveToolStripMenuItem
			// 
			this.thresholdingAdaptiveToolStripMenuItem.Name = "thresholdingAdaptiveToolStripMenuItem";
			this.thresholdingAdaptiveToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.thresholdingAdaptiveToolStripMenuItem.Text = "Progowanie adaptacyjne";
			this.thresholdingAdaptiveToolStripMenuItem.Click += new System.EventHandler(this.thresholdingAdaptiveToolStripMenuItem_Click);
			// 
			// thresholdingOtsuToolStripMenuItem
			// 
			this.thresholdingOtsuToolStripMenuItem.Name = "thresholdingOtsuToolStripMenuItem";
			this.thresholdingOtsuToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.thresholdingOtsuToolStripMenuItem.Text = "Progowanie Otsu";
			this.thresholdingOtsuToolStripMenuItem.Click += new System.EventHandler(this.thresholdingOtsuToolStripMenuItem_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(210, 6);
			// 
			// addingPicturesToolStripMenuItem
			// 
			this.addingPicturesToolStripMenuItem.Name = "addingPicturesToolStripMenuItem";
			this.addingPicturesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.addingPicturesToolStripMenuItem.Text = "Dodawanie";
			this.addingPicturesToolStripMenuItem.Click += new System.EventHandler(this.addingPicturesToolStripMenuItem_Click);
			// 
			// substractingPicturesToolStripMenuItem
			// 
			this.substractingPicturesToolStripMenuItem.Name = "substractingPicturesToolStripMenuItem";
			this.substractingPicturesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.substractingPicturesToolStripMenuItem.Text = "Odejmowanie";
			this.substractingPicturesToolStripMenuItem.Click += new System.EventHandler(this.substractingPicturesToolStripMenuItem_Click);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(210, 6);
			// 
			// bitwiseANDToolStripMenuItem
			// 
			this.bitwiseANDToolStripMenuItem.Name = "bitwiseANDToolStripMenuItem";
			this.bitwiseANDToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.bitwiseANDToolStripMenuItem.Text = "And";
			this.bitwiseANDToolStripMenuItem.Click += new System.EventHandler(this.bitwiseANDToolStripMenuItem_Click);
			// 
			// bitwiseORToolStripMenuItem
			// 
			this.bitwiseORToolStripMenuItem.Name = "bitwiseORToolStripMenuItem";
			this.bitwiseORToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.bitwiseORToolStripMenuItem.Text = "Or";
			this.bitwiseORToolStripMenuItem.Click += new System.EventHandler(this.bitwiseORToolStripMenuItem_Click);
			// 
			// bitwiseXORToolStripMenuItem
			// 
			this.bitwiseXORToolStripMenuItem.Name = "bitwiseXORToolStripMenuItem";
			this.bitwiseXORToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.bitwiseXORToolStripMenuItem.Text = "Xor";
			this.bitwiseXORToolStripMenuItem.Click += new System.EventHandler(this.bitwiseXORToolStripMenuItem_Click);
			// 
			// neighborOperationsToolStripMenuItem
			// 
			this.neighborOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurToolStripMenuItem,
            this.blurGaussianToolStripMenuItem,
            this.blurMedianToolStripMenuItem,
            this.borderDetectionToolStripMenuItem,
            this.maskToolStripMenuItem,
            this.logicFiltrationToolStripMenuItem});
			this.neighborOperationsToolStripMenuItem.Name = "neighborOperationsToolStripMenuItem";
			this.neighborOperationsToolStripMenuItem.Size = new System.Drawing.Size(125, 38);
			this.neighborOperationsToolStripMenuItem.Text = "Operacje sąsiedztwa";
			// 
			// blurToolStripMenuItem
			// 
			this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
			this.blurToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.blurToolStripMenuItem.Text = "Wygładzanie";
			this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
			// 
			// blurGaussianToolStripMenuItem
			// 
			this.blurGaussianToolStripMenuItem.Name = "blurGaussianToolStripMenuItem";
			this.blurGaussianToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.blurGaussianToolStripMenuItem.Text = "Wygładzanie Gaussa";
			this.blurGaussianToolStripMenuItem.Click += new System.EventHandler(this.blurGaussianToolStripMenuItem_Click);
			// 
			// blurMedianToolStripMenuItem
			// 
			this.blurMedianToolStripMenuItem.Name = "blurMedianToolStripMenuItem";
			this.blurMedianToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.blurMedianToolStripMenuItem.Text = "Filtracja medianowa";
			this.blurMedianToolStripMenuItem.Click += new System.EventHandler(this.blurMedianToolStripMenuItem_Click);
			// 
			// borderDetectionToolStripMenuItem
			// 
			this.borderDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobelToolStripMenuItem,
            this.laplaceToolStripMenuItem,
            this.cannyToolStripMenuItem,
            this.prewittToolStripMenuItem});
			this.borderDetectionToolStripMenuItem.Name = "borderDetectionToolStripMenuItem";
			this.borderDetectionToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.borderDetectionToolStripMenuItem.Text = "Detekcja krawędzi";
			// 
			// sobelToolStripMenuItem
			// 
			this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
			this.sobelToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.sobelToolStripMenuItem.Text = "Sobel";
			this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
			// 
			// laplaceToolStripMenuItem
			// 
			this.laplaceToolStripMenuItem.Name = "laplaceToolStripMenuItem";
			this.laplaceToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.laplaceToolStripMenuItem.Text = "Laplacjan";
			this.laplaceToolStripMenuItem.Click += new System.EventHandler(this.laplaceToolStripMenuItem_Click);
			// 
			// cannyToolStripMenuItem
			// 
			this.cannyToolStripMenuItem.Name = "cannyToolStripMenuItem";
			this.cannyToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.cannyToolStripMenuItem.Text = "Canny";
			this.cannyToolStripMenuItem.Click += new System.EventHandler(this.cannyToolStripMenuItem_Click);
			// 
			// prewittToolStripMenuItem
			// 
			this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
			this.prewittToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.prewittToolStripMenuItem.Text = "Prewitt";
			this.prewittToolStripMenuItem.Click += new System.EventHandler(this.prewittToolStripMenuItem_Click);
			// 
			// maskToolStripMenuItem
			// 
			this.maskToolStripMenuItem.Name = "maskToolStripMenuItem";
			this.maskToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.maskToolStripMenuItem.Text = "Własna maska";
			this.maskToolStripMenuItem.Click += new System.EventHandler(this.maskToolStripMenuItem_Click);
			// 
			// logicFiltrationToolStripMenuItem
			// 
			this.logicFiltrationToolStripMenuItem.Name = "logicFiltrationToolStripMenuItem";
			this.logicFiltrationToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.logicFiltrationToolStripMenuItem.Text = "Filtracja logiczna";
			this.logicFiltrationToolStripMenuItem.Click += new System.EventHandler(this.logicFiltrationToolStripMenuItem_Click);
			// 
			// morfologyToolStripMenuItem
			// 
			this.morfologyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMorfologyDialogToolStripMenuItem,
            this.skeletizationToolStripMenuItem,
            this.watershedToolStripMenuItem,
            this.analizeToolStripMenuItem});
			this.morfologyToolStripMenuItem.Name = "morfologyToolStripMenuItem";
			this.morfologyToolStripMenuItem.Size = new System.Drawing.Size(78, 38);
			this.morfologyToolStripMenuItem.Text = "Morfologia";
			// 
			// showMorfologyDialogToolStripMenuItem
			// 
			this.showMorfologyDialogToolStripMenuItem.Name = "showMorfologyDialogToolStripMenuItem";
			this.showMorfologyDialogToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.showMorfologyDialogToolStripMenuItem.Text = "Morfologia";
			this.showMorfologyDialogToolStripMenuItem.Click += new System.EventHandler(this.showMorfologyDialogToolStripMenuItem_Click);
			// 
			// skeletizationToolStripMenuItem
			// 
			this.skeletizationToolStripMenuItem.Name = "skeletizationToolStripMenuItem";
			this.skeletizationToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.skeletizationToolStripMenuItem.Text = "Szkieletyzacja";
			this.skeletizationToolStripMenuItem.Click += new System.EventHandler(this.skeletizationToolStripMenuItem_Click);
			// 
			// watershedToolStripMenuItem
			// 
			this.watershedToolStripMenuItem.Name = "watershedToolStripMenuItem";
			this.watershedToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.watershedToolStripMenuItem.Text = "Segmentacja wododziałowa";
			this.watershedToolStripMenuItem.Click += new System.EventHandler(this.watershedToolStripMenuItem_Click);
			// 
			// analizeToolStripMenuItem
			// 
			this.analizeToolStripMenuItem.Name = "analizeToolStripMenuItem";
			this.analizeToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
			this.analizeToolStripMenuItem.Text = "Analiza obrazu";
			this.analizeToolStripMenuItem.Click += new System.EventHandler(this.analizeToolStripMenuItem_Click);
			// 
			// informacjaToolStripMenuItem
			// 
			this.informacjaToolStripMenuItem.Name = "informacjaToolStripMenuItem";
			this.informacjaToolStripMenuItem.Size = new System.Drawing.Size(76, 38);
			this.informacjaToolStripMenuItem.Text = "Informacja";
			this.informacjaToolStripMenuItem.Click += new System.EventHandler(this.informacjaToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.ClientSize = new System.Drawing.Size(733, 42);
			this.Controls.Add(this.menuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Main";
			this.Activated += new System.EventHandler(this.MainForm_Activated);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showHistogramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ShowHistogramChartToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showHistogramListToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stretchHistogramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem equalizeHistogramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pointOperationsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem negationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thresholdingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thresholdingAdaptiveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem thresholdingOtsuToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem addingPicturesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem substractingPicturesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
		private System.Windows.Forms.ToolStripMenuItem bitwiseANDToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bitwiseORToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bitwiseXORToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem neighborOperationsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blurGaussianToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem borderDetectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem laplaceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cannyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem maskToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem morfologyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showMorfologyDialogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem skeletizationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem watershedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blurMedianToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem informacjaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem analizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem logicFiltrationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recoverFragmentToolStripMenuItem;
	}
}

