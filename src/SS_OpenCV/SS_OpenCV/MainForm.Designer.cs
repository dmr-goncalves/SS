namespace SS_OpenCV
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
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.binarizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.otsuBinarizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.negativeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.emguDirectivesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.directAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.transformsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.translationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.rotationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.zoomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.filtersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.colorToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.averageMethodAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.matrix3x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.differentiationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.robertsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.signDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redSignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blueSignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ImageViewer = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImageViewer)).BeginInit();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Images (*.png, *.bmp, *.jpg)|*.png;*.bmp;*.jpg";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.colorToolStripMenuItem1,
            this.transformsToolStripMenuItem1,
            this.filtersToolStripMenuItem1,
            this.signDetectionToolStripMenuItem,
            this.autoresToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(677, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.openToolStripMenuItem.Text = "Open...";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.saveToolStripMenuItem.Text = "Save As...";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.undoToolStripMenuItem.Text = "Undo";
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
			// 
			// imageToolStripMenuItem
			// 
			this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.autoZoomToolStripMenuItem});
			this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
			this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.imageToolStripMenuItem.Text = "Image";
			// 
			// histogramToolStripMenuItem
			// 
			this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
			this.histogramToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.histogramToolStripMenuItem.Text = "Histogram";
			this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
			// 
			// autoZoomToolStripMenuItem
			// 
			this.autoZoomToolStripMenuItem.CheckOnClick = true;
			this.autoZoomToolStripMenuItem.Name = "autoZoomToolStripMenuItem";
			this.autoZoomToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.autoZoomToolStripMenuItem.Text = "Auto Zoom";
			this.autoZoomToolStripMenuItem.Click += new System.EventHandler(this.autoZoomToolStripMenuItem_Click);
			// 
			// colorToolStripMenuItem1
			// 
			this.colorToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertToolStripMenuItem,
            this.negativeToolStripMenuItem1});
			this.colorToolStripMenuItem1.Name = "colorToolStripMenuItem1";
			this.colorToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
			this.colorToolStripMenuItem1.Text = "Color";
			// 
			// convertToolStripMenuItem
			// 
			this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayScaleToolStripMenuItem,
            this.binarizationToolStripMenuItem,
            this.otsuBinarizationToolStripMenuItem});
			this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
			this.convertToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.convertToolStripMenuItem.Text = "Convert";
			// 
			// grayScaleToolStripMenuItem
			// 
			this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
			this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.grayScaleToolStripMenuItem.Text = "Gray Scale";
			this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.grayScaleToolStripMenuItem_Click);
			// 
			// binarizationToolStripMenuItem
			// 
			this.binarizationToolStripMenuItem.Name = "binarizationToolStripMenuItem";
			this.binarizationToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.binarizationToolStripMenuItem.Text = "Binarization";
			this.binarizationToolStripMenuItem.Click += new System.EventHandler(this.binarizationToolStripMenuItem_Click);
			// 
			// otsuBinarizationToolStripMenuItem
			// 
			this.otsuBinarizationToolStripMenuItem.Name = "otsuBinarizationToolStripMenuItem";
			this.otsuBinarizationToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.otsuBinarizationToolStripMenuItem.Text = "Otsu Binarization";
			this.otsuBinarizationToolStripMenuItem.Click += new System.EventHandler(this.otsuBinarizationToolStripMenuItem_Click);
			// 
			// negativeToolStripMenuItem1
			// 
			this.negativeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emguDirectivesToolStripMenuItem,
            this.directAccessToolStripMenuItem});
			this.negativeToolStripMenuItem1.Name = "negativeToolStripMenuItem1";
			this.negativeToolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
			this.negativeToolStripMenuItem1.Text = "Negative";
			// 
			// emguDirectivesToolStripMenuItem
			// 
			this.emguDirectivesToolStripMenuItem.Name = "emguDirectivesToolStripMenuItem";
			this.emguDirectivesToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.emguDirectivesToolStripMenuItem.Text = "Emgu Directives";
			this.emguDirectivesToolStripMenuItem.Click += new System.EventHandler(this.emguDirectivesToolStripMenuItem_Click);
			// 
			// directAccessToolStripMenuItem
			// 
			this.directAccessToolStripMenuItem.Name = "directAccessToolStripMenuItem";
			this.directAccessToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
			this.directAccessToolStripMenuItem.Text = "Direct Access";
			this.directAccessToolStripMenuItem.Click += new System.EventHandler(this.directAccessToolStripMenuItem_Click);
			// 
			// transformsToolStripMenuItem1
			// 
			this.transformsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translationToolStripMenuItem1,
            this.rotationToolStripMenuItem1,
            this.zoomToolStripMenuItem1});
			this.transformsToolStripMenuItem1.Name = "transformsToolStripMenuItem1";
			this.transformsToolStripMenuItem1.Size = new System.Drawing.Size(79, 20);
			this.transformsToolStripMenuItem1.Text = "Transforms";
			// 
			// translationToolStripMenuItem1
			// 
			this.translationToolStripMenuItem1.Name = "translationToolStripMenuItem1";
			this.translationToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
			this.translationToolStripMenuItem1.Text = "Translation";
			this.translationToolStripMenuItem1.Click += new System.EventHandler(this.translationToolStripMenuItem1_Click);
			// 
			// rotationToolStripMenuItem1
			// 
			this.rotationToolStripMenuItem1.Name = "rotationToolStripMenuItem1";
			this.rotationToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
			this.rotationToolStripMenuItem1.Text = "Rotation";
			this.rotationToolStripMenuItem1.Click += new System.EventHandler(this.rotationToolStripMenuItem1_Click);
			// 
			// zoomToolStripMenuItem1
			// 
			this.zoomToolStripMenuItem1.Name = "zoomToolStripMenuItem1";
			this.zoomToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
			this.zoomToolStripMenuItem1.Text = "Zoom";
			this.zoomToolStripMenuItem1.Click += new System.EventHandler(this.zoomToolStripMenuItem1_Click);
			// 
			// filtersToolStripMenuItem1
			// 
			this.filtersToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorToolStripMenuItem2,
            this.averageMethodAToolStripMenuItem,
            this.matrix3x3ToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.differentiationToolStripMenuItem,
            this.robertsToolStripMenuItem,
            this.medianToolStripMenuItem});
			this.filtersToolStripMenuItem1.Name = "filtersToolStripMenuItem1";
			this.filtersToolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
			this.filtersToolStripMenuItem1.Text = "Filters";
			// 
			// colorToolStripMenuItem2
			// 
			this.colorToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.blueToolStripMenuItem});
			this.colorToolStripMenuItem2.Name = "colorToolStripMenuItem2";
			this.colorToolStripMenuItem2.Size = new System.Drawing.Size(181, 22);
			this.colorToolStripMenuItem2.Text = "Color";
			// 
			// redToolStripMenuItem
			// 
			this.redToolStripMenuItem.Name = "redToolStripMenuItem";
			this.redToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.redToolStripMenuItem.Text = "Red";
			this.redToolStripMenuItem.Click += new System.EventHandler(this.redToolStripMenuItem_Click);
			// 
			// greenToolStripMenuItem
			// 
			this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
			this.greenToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.greenToolStripMenuItem.Text = "Green";
			this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
			// 
			// blueToolStripMenuItem
			// 
			this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
			this.blueToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
			this.blueToolStripMenuItem.Text = "Blue";
			this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
			// 
			// averageMethodAToolStripMenuItem
			// 
			this.averageMethodAToolStripMenuItem.Name = "averageMethodAToolStripMenuItem";
			this.averageMethodAToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.averageMethodAToolStripMenuItem.Text = "Average (Method A)";
			this.averageMethodAToolStripMenuItem.Click += new System.EventHandler(this.averageMethodAToolStripMenuItem_Click);
			// 
			// matrix3x3ToolStripMenuItem
			// 
			this.matrix3x3ToolStripMenuItem.Name = "matrix3x3ToolStripMenuItem";
			this.matrix3x3ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.matrix3x3ToolStripMenuItem.Text = "Matrix 3x3";
			this.matrix3x3ToolStripMenuItem.Click += new System.EventHandler(this.matrix3x3ToolStripMenuItem_Click);
			// 
			// sobelToolStripMenuItem
			// 
			this.sobelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x3ToolStripMenuItem,
            this.x5ToolStripMenuItem});
			this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
			this.sobelToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.sobelToolStripMenuItem.Text = "Sobel";
			// 
			// x3ToolStripMenuItem
			// 
			this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
			this.x3ToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.x3ToolStripMenuItem.Text = "3x3";
			this.x3ToolStripMenuItem.Click += new System.EventHandler(this.x3ToolStripMenuItem_Click);
			// 
			// x5ToolStripMenuItem
			// 
			this.x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
			this.x5ToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
			this.x5ToolStripMenuItem.Text = "5x5";
			this.x5ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
			// 
			// differentiationToolStripMenuItem
			// 
			this.differentiationToolStripMenuItem.Name = "differentiationToolStripMenuItem";
			this.differentiationToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.differentiationToolStripMenuItem.Text = "Differentiation";
			this.differentiationToolStripMenuItem.Click += new System.EventHandler(this.differentiationToolStripMenuItem_Click);
			// 
			// robertsToolStripMenuItem
			// 
			this.robertsToolStripMenuItem.Name = "robertsToolStripMenuItem";
			this.robertsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.robertsToolStripMenuItem.Text = "Roberts";
			this.robertsToolStripMenuItem.Click += new System.EventHandler(this.robertsToolStripMenuItem_Click);
			// 
			// medianToolStripMenuItem
			// 
			this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
			this.medianToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.medianToolStripMenuItem.Text = "Median";
			this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
			// 
			// signDetectionToolStripMenuItem
			// 
			this.signDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redSignToolStripMenuItem,
            this.blueSignToolStripMenuItem});
			this.signDetectionToolStripMenuItem.Name = "signDetectionToolStripMenuItem";
			this.signDetectionToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
			this.signDetectionToolStripMenuItem.Text = "Sign Detection";
			// 
			// redSignToolStripMenuItem
			// 
			this.redSignToolStripMenuItem.Name = "redSignToolStripMenuItem";
			this.redSignToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.redSignToolStripMenuItem.Text = "Red Sign";
			this.redSignToolStripMenuItem.Click += new System.EventHandler(this.redSignToolStripMenuItem_Click);
			// 
			// blueSignToolStripMenuItem
			// 
			this.blueSignToolStripMenuItem.Name = "blueSignToolStripMenuItem";
			this.blueSignToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.blueSignToolStripMenuItem.Text = "Blue Sign";
			this.blueSignToolStripMenuItem.Click += new System.EventHandler(this.blueSignToolStripMenuItem_Click);
			// 
			// autoresToolStripMenuItem
			// 
			this.autoresToolStripMenuItem.Name = "autoresToolStripMenuItem";
			this.autoresToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.autoresToolStripMenuItem.Text = "Authors";
			this.autoresToolStripMenuItem.Click += new System.EventHandler(this.autoresToolStripMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.ImageViewer);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 24);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(677, 357);
			this.panel1.TabIndex = 6;
			// 
			// ImageViewer
			// 
			this.ImageViewer.Location = new System.Drawing.Point(0, 0);
			this.ImageViewer.Name = "ImageViewer";
			this.ImageViewer.Size = new System.Drawing.Size(576, 427);
			this.ImageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.ImageViewer.TabIndex = 6;
			this.ImageViewer.TabStop = false;
			this.ImageViewer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ImageViewer_MouseClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(677, 381);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Sistemas Sensoriais 2015/2016 - Image processing";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImageViewer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoZoomToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem binarizationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem otsuBinarizationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem emguDirectivesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem directAccessToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem transformsToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem translationToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem rotationToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem averageMethodAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem matrix3x3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x3ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem x5ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem differentiationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem robertsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem medianToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem signDetectionToolStripMenuItem;
		public System.Windows.Forms.PictureBox ImageViewer;
		private System.Windows.Forms.ToolStripMenuItem redSignToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blueSignToolStripMenuItem;
	}
}

