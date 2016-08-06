using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace SS_OpenCV {
	public partial class MainForm :Form {
		Image<Bgr, Byte> img = null; // imagem corrente
		Image<Bgr, Byte> imgUndo = null; // imagem backup - UNDO
		string title_bak = "";

		int x_image = -1;
		int y_image = -1;
		bool wait = true;

		string directory = @".\Base Dados\";
		string temp;
		List<Image<Bgr, byte>> DataBase = new List<Image<Bgr, byte>>();
		List<string> NamesDataBase = new List<string>();

		public MainForm() {
			InitializeComponent();
			title_bak = Text;

			foreach(string image in Directory.GetFiles(directory, "*.png")) {
				DataBase.Add(new Image<Bgr, byte>(image));
				temp = image.Substring(image.LastIndexOf("\\") + 1);
				temp = temp.Substring(0, temp.Length - 4);

				NamesDataBase.Add(temp);
			}
		}

		/// <summary>
		/// Abrir uma nova imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void openToolStripMenuItem_Click(object sender, EventArgs e) {
			if(openFileDialog1.ShowDialog() == DialogResult.OK) {
				img = new Image<Bgr, byte>(openFileDialog1.FileName);
				Text = title_bak + " [" +
						openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1) +
						"]";
				imgUndo = img.Copy();
				ImageViewer.Image = img.Bitmap;
				ImageViewer.Refresh();
			}
		}

		/// <summary>
		/// Guardar a imagem com novo nome
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
			if(saveFileDialog1.ShowDialog() == DialogResult.OK) {
				ImageViewer.Image.Save(saveFileDialog1.FileName);
			}
		}

		/// <summary>
		/// Fecha a aplicação
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		/// <summary>
		/// repoe a ultima copia da imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void undoToolStripMenuItem_Click(object sender, EventArgs e) {
			if(imgUndo == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;
			Cursor = Cursors.WaitCursor;
			img = imgUndo.Copy();
			ImageViewer.Image = img.Bitmap;
			ImageViewer.Refresh();
			Cursor = Cursors.Default;
		}

		/// <summary>
		/// Altera o modo de vizualização
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void autoZoomToolStripMenuItem_Click(object sender, EventArgs e) {
			// zoom
			if(autoZoomToolStripMenuItem.Checked) {
				ImageViewer.SizeMode = PictureBoxSizeMode.Zoom;
				ImageViewer.Dock = DockStyle.Fill;
			} else // com scroll bars
			  {
				ImageViewer.Dock = DockStyle.None;
				ImageViewer.SizeMode = PictureBoxSizeMode.AutoSize;
			}
		}

		/// <summary>
		/// Mostra a janela Autores
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void autoresToolStripMenuItem_Click(object sender, EventArgs e) {
			AuthorsForm form = new AuthorsForm();
			form.ShowDialog();
		}

		/// <summary>
		/// Efectua o negativo da imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void emguDirectivesToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;
			Cursor = Cursors.WaitCursor; // cursor relogio

			//copy Undo Image
			imgUndo = img.Copy();

			ImageClass.Negative(img);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Efectua o negativo da imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void directAccessToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;
			Cursor = Cursors.WaitCursor; // cursor relogio

			//copy Undo Image
			imgUndo = img.Copy();

			ImageClass.NegativeFast(img);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Converte a imagem para tons de cinzento
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;
			Cursor = Cursors.WaitCursor; // cursor relogio

			//copy Undo Image
			imgUndo = img.Copy();

			ImageClass.ConvertToGray(img);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Converte a imagem para preto e branco
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void binarizationToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			InputBox formX = new InputBox("Threshold");
			formX.ShowDialog();

			if(formX.ValueTextBox.Text != "") {
				int threshold = Convert.ToInt32(formX.ValueTextBox.Text);

				//copy Undo Image
				imgUndo = img.Copy();

				Cursor = Cursors.WaitCursor; // cursor relogio

				ImageClass.Binarization(img, threshold);

				ImageViewer.Refresh(); // atualiza imagem no ecrã

				Cursor = Cursors.Default; // cursor normal
			}
		}

		/// <summary>
		/// Converte a imagem para preto e branco pelo utilizando o método de Otsu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void otsuBinarizationToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.Otsu(img);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Converte a imagem para tons de cinzento na componente vermelha
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void redToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;
			Cursor = Cursors.WaitCursor; // cursor relogio

			//copy Undo Image
			imgUndo = img.Copy();

			ImageClass.ColorFilter(img, "red");

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Converte a imagem para tons de cinzento na componente verde
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void greenToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;
			Cursor = Cursors.WaitCursor; // cursor relogio

			//copy Undo Image
			imgUndo = img.Copy();

			ImageClass.ColorFilter(img, "green");

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Converte a imagem para tons de cinzento na componente azul
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void blueToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;
			Cursor = Cursors.WaitCursor; // cursor relogio

			//copy Undo Image
			imgUndo = img.Copy();

			ImageClass.ColorFilter(img, "blue");

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Realiza uma translação na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void translationToolStripMenuItem1_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			InputBox formX = new InputBox("Deslocamento em X?");
			formX.ShowDialog();

			if(formX.ValueTextBox.Text != "") {

				//int Dx = Convert.ToInt32(formX.ValueTextBox.Text);
				double Dx = Convert.ToDouble(formX.ValueTextBox.Text);

				InputBox formY = new InputBox("Deslocamento em Y?");
				formY.ShowDialog();

				//int Dy = Convert.ToInt32(formY.ValueTextBox.Text);
				double Dy = Convert.ToDouble(formY.ValueTextBox.Text);

				Cursor = Cursors.WaitCursor; // cursor relogio

				ImageClass.Translation(img, Dx, Dy);

				ImageViewer.Refresh(); // atualiza imagem no ecrã

				Cursor = Cursors.Default; // cursor normal
			}
		}

		/// <summary>
		/// Realiza uma rotação na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rotationToolStripMenuItem1_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			InputBox formX = new InputBox("Rotação em Graus");
			formX.ShowDialog();

			if(formX.ValueTextBox.Text != "") {
				double Ang = Convert.ToDouble(formX.ValueTextBox.Text);

				Cursor = Cursors.WaitCursor; // cursor relogio

				ImageClass.Rotation(img, Ang);

				ImageViewer.Refresh(); // atualiza imagem no ecrã

				Cursor = Cursors.Default; // cursor normal
			}
		}

		/// <summary>
		/// Realiza uma ampliação na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void zoomToolStripMenuItem1_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			InputBox formX = new InputBox("Zoom");
			formX.ShowDialog();
			if(formX.ValueTextBox.Text != "") {
				double zoom = Convert.ToDouble(formX.ValueTextBox.Text);

				wait = true;
				while(wait) {
					Application.DoEvents();
				}

				Cursor = Cursors.WaitCursor; // cursor relogio

				ImageClass.Zoom(img, zoom, x_image, y_image);

				ImageViewer.Refresh(); // atualiza imagem no ecrã

				Cursor = Cursors.Default; // cursor normal
			}
		}

		/// <summary>
		/// Captura a posição do rato na altura do click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ImageViewer_MouseClick(object sender, MouseEventArgs e) {
			x_image = e.X;
			y_image = e.Y;
			wait = false;
		}

		/// <summary>
		/// Aplica um filtro de média na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void averageMethodAToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			InputBox formX = new InputBox("Tamanho do Filtro");
			formX.ShowDialog();

			if(formX.ValueTextBox.Text != "") {
				int Size = Convert.ToInt32(formX.ValueTextBox.Text);

				Cursor = Cursors.WaitCursor; // cursor relogio

				ImageClass.FilterA(img, Size);

				ImageViewer.Refresh(); // atualiza imagem no ecrã

				Cursor = Cursors.Default; // cursor normal
			}
		}

		/// <summary>
		/// Aplica um filtro não-uniforme na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void matrix3x3ToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			MatrixInputBox formX = new MatrixInputBox();
			formX.ShowDialog();

			if(formX.numericUpDown10.Text != "0") {
				int[] v_coeficientes = new int[10];

				v_coeficientes[0] = Convert.ToInt32(formX.numericUpDown1.Text);
				v_coeficientes[1] = Convert.ToInt32(formX.numericUpDown2.Text);
				v_coeficientes[2] = Convert.ToInt32(formX.numericUpDown3.Text);
				v_coeficientes[3] = Convert.ToInt32(formX.numericUpDown4.Text);
				v_coeficientes[4] = Convert.ToInt32(formX.numericUpDown5.Text);
				v_coeficientes[5] = Convert.ToInt32(formX.numericUpDown6.Text);
				v_coeficientes[6] = Convert.ToInt32(formX.numericUpDown7.Text);
				v_coeficientes[7] = Convert.ToInt32(formX.numericUpDown8.Text);
				v_coeficientes[8] = Convert.ToInt32(formX.numericUpDown9.Text);
				v_coeficientes[9] = Convert.ToInt32(formX.numericUpDown10.Text);

				Cursor = Cursors.WaitCursor; // cursor relogio

				ImageClass.FilterMatrix(img, v_coeficientes);

				ImageViewer.Refresh(); // atualiza imagem no ecrã

				Cursor = Cursors.Default; // cursor normal
			}
		}

		/// <summary>
		/// Aplica um filtro de Sobel de 3x3 na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void x3ToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			int[] v_coeficientes1 = new int[9];
			int[] v_coeficientes2 = new int[9];

			v_coeficientes1[0] = 1;
			v_coeficientes1[1] = 0;
			v_coeficientes1[2] = -1;
			v_coeficientes1[3] = 2;
			v_coeficientes1[4] = 0;
			v_coeficientes1[5] = -2;
			v_coeficientes1[6] = 1;
			v_coeficientes1[7] = 0;
			v_coeficientes1[8] = -1;

			v_coeficientes2[0] = -1;
			v_coeficientes2[1] = -2;
			v_coeficientes2[2] = -1;
			v_coeficientes2[3] = 0;
			v_coeficientes2[4] = 0;
			v_coeficientes2[5] = 0;
			v_coeficientes2[6] = 1;
			v_coeficientes2[7] = 2;
			v_coeficientes2[8] = 1;

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.Sobel3x3(img, v_coeficientes1, v_coeficientes2);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Aplica um filtro de Sobel de 5x5 na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void x5ToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			int[] v_coeficientes1 = new int[25];
			int[] v_coeficientes2 = new int[25];

			v_coeficientes1[0] = 1;
			v_coeficientes1[1] = 2;
			v_coeficientes1[2] = 0;
			v_coeficientes1[3] = -2;
			v_coeficientes1[4] = -1;
			v_coeficientes1[5] = 4;
			v_coeficientes1[6] = 8;
			v_coeficientes1[7] = 0;
			v_coeficientes1[8] = -8;
			v_coeficientes1[9] = -4;
			v_coeficientes1[10] = 6;
			v_coeficientes1[11] = 12;
			v_coeficientes1[12] = 0;
			v_coeficientes1[13] = -12;
			v_coeficientes1[14] = -6;
			v_coeficientes1[15] = 4;
			v_coeficientes1[16] = 8;
			v_coeficientes1[17] = 0;
			v_coeficientes1[18] = -8;
			v_coeficientes1[19] = -4;
			v_coeficientes1[20] = 1;
			v_coeficientes1[21] = 2;
			v_coeficientes1[22] = 0;
			v_coeficientes1[23] = -2;
			v_coeficientes1[24] = -1;

			v_coeficientes2[0] = -1;
			v_coeficientes2[1] = -4;
			v_coeficientes2[2] = -6;
			v_coeficientes2[3] = -4;
			v_coeficientes2[4] = -1;
			v_coeficientes2[5] = -2;
			v_coeficientes2[6] = -8;
			v_coeficientes2[7] = -12;
			v_coeficientes2[8] = -8;
			v_coeficientes2[9] = -2;
			v_coeficientes2[10] = 0;
			v_coeficientes2[11] = 0;
			v_coeficientes2[12] = 0;
			v_coeficientes2[13] = 0;
			v_coeficientes2[14] = 0;
			v_coeficientes2[15] = 2;
			v_coeficientes2[16] = 8;
			v_coeficientes2[17] = 12;
			v_coeficientes2[18] = 8;
			v_coeficientes2[19] = 2;
			v_coeficientes2[20] = 1;
			v_coeficientes2[21] = 4;
			v_coeficientes2[22] = 6;
			v_coeficientes2[23] = 4;
			v_coeficientes2[24] = 1;

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.Sobel5x5(img, v_coeficientes1, v_coeficientes2);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Aplica um filtro de diferenciação na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void differentiationToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.Differentiation(img);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Aplica um filtro de Roberts na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void robertsToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.Roberts(img);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Aplica um filtro de mediana na imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void medianToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			//copy Undo Image
			imgUndo = img.Copy();

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.Median(img);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		/// <summary>
		/// Realiza o histrograma da imagem
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void histogramToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.Histogram(img);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		private void redSignToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.RedSignDetection(img, this, DataBase, NamesDataBase);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}

		private void blueSignToolStripMenuItem_Click(object sender, EventArgs e) {
			if(img == null) // protege de executar a função sem ainda ter aberto a imagem 
				return;

			Cursor = Cursors.WaitCursor; // cursor relogio

			ImageClass.BlueSignDetection(img, this, DataBase, NamesDataBase);

			ImageViewer.Refresh(); // atualiza imagem no ecrã

			Cursor = Cursors.Default; // cursor normal
		}
	}
}