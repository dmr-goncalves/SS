using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using System.Drawing.Imaging;

namespace SS_OpenCV {
	class ImageClass {

		/// <summary>
		/// Negativo da Imagem
		/// Manipulação Imagem - Primitivas EmguCV
		/// Algoritmo de manipulação de imagem mais lento 
		/// </summary>
		/// <param name="img">Imagem</param>
		internal static void Negative(Image<Bgr, byte> img) {
			Bgr aux;
			for(int y = 0; y < img.Height; y++) {
				for(int x = 0; x < img.Width; x++) {
					// acesso directo : mais lento 
					aux = img[y, x];
					img[y, x] = new Bgr(255 - aux.Blue, 255 - aux.Green, 255 - aux.Red);
				}
			}
		}

		/// <summary>
		/// Negativo da Imagem
		/// Manipulação Imagem - Primitivas EmguCV
		/// Algoritmo de inversão de cores da imagem rápido
		/// </summary>
		/// <param name="img">Imagem</param>
		internal static void NegativeFast(Image<Bgr, byte> img) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = img.MIplImage;
				byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							// guarda na imagem
							dataPtr[0] = (byte)(255 - dataPtr[0]); //blue
							dataPtr[1] = (byte)(255 - dataPtr[1]); //green
							dataPtr[2] = (byte)(255 - dataPtr[2]); //red

							// avança apontador para próximo pixel
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Conversão para Cinzento
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		internal static void ConvertToGray(Image<Bgr, byte> img) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = img.MIplImage;
				byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
				byte gray;

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							// converte para cinza
							gray = (byte)((dataPtr[0]/*blue*/ + dataPtr[1]/*green*/ + dataPtr[2]/*red*/) / 3);

							// guarda na imagem
							dataPtr[0] = gray;
							dataPtr[1] = gray;
							dataPtr[2] = gray;

							// avança apontador para próximo pixel
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Conversão para Preto e Branco
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="threshold">threshold</param>
		internal static void Binarization(Image<Bgr, byte> img, int threshold) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = img.MIplImage;
				byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem
				byte gray;

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							// converte para cinza
							gray = (byte)((dataPtr[0]/*blue*/ + dataPtr[1]/*green*/ + dataPtr[2]/*red*/) / 3);

							if(gray <= threshold) {
								// guarda na imagem
								dataPtr[0] = 0;
								dataPtr[1] = 0;
								dataPtr[2] = 0;
							} else {
								// guarda na imagem
								dataPtr[0] = 255;
								dataPtr[1] = 255;
								dataPtr[2] = 255;
							}

							// avança apontador para próximo pixel
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Filtragem de Cor
		/// Manipulação Imagem - Primitivas EmguCV
		/// Algoritmo de isolamento de cor
		/// </summary>
		/// <param name="img">Imagem</param>
		/// <param name="color">Cor</param>
		internal static void ColorFilter(Image<Bgr, byte> img, string color) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = img.MIplImage;
				byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y;

				switch(color) {
					case "red":
						if(nChan == 3) { // imagem em RGB
							for(y = 0; y < height; y++) {
								for(x = 0; x < width; x++) {

									// guarda na imagem
									dataPtr[0] = dataPtr[2]; //red
									dataPtr[1] = dataPtr[2]; //red
									dataPtr[2] = dataPtr[2]; //red

									// avança apontador para próximo pixel
									dataPtr += nChan;
								}

								//no fim da linha avança alinhamento (padding)
								dataPtr += padding;
							}
						}; break;
					case "green":
						if(nChan == 3) { // imagem em RGB
							for(y = 0; y < height; y++) {
								for(x = 0; x < width; x++) {

									// guarda na imagem
									dataPtr[0] = dataPtr[1]; //green
									dataPtr[1] = dataPtr[1]; //green
									dataPtr[2] = dataPtr[1]; //green

									// avança apontador para próximo pixel
									dataPtr += nChan;
								}

								//no fim da linha avança alinhamento (padding)
								dataPtr += padding;
							}
						}; break;
					case "blue":
						if(nChan == 3) { // imagem em RGB
							for(y = 0; y < height; y++) {
								for(x = 0; x < width; x++) {

									// guarda na imagem
									dataPtr[0] = dataPtr[0]; //blue
									dataPtr[1] = dataPtr[0]; //blue
									dataPtr[2] = dataPtr[0]; //blue

									// avança apontador para próximo pixel
									dataPtr += nChan;
								}

								//no fim da linha avança alinhamento (padding)
								dataPtr += padding;
							}
						}; break;
				}
			}
		}

		/// <summary>
		/// Tranlação
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="Dx">pixeis de translação no eixo x</param>
		/// <param name="Dy">pixeis de translação no eixo y</param>
		internal static void Translation(Image<Bgr, byte> img, double Dx, double Dy) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, x_origin, y_origin, sum_x, sum_y;
				double R1_b, R1_g, R1_r, R2_b, R2_g, R2_r, point_b, point_g, point_r;

				byte* auxPtr11, auxPtr12, auxPtr21, auxPtr22;

				double offsetX = ((Dx - (int)Dx) < 0 ? -(Dx - (int)Dx) : (Dx - (int)Dx));
				double offsetY = ((Dy - (int)Dy) < 0 ? -(Dy - (int)Dy) : (Dy - (int)Dy));

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							x_origin = x - (int)Dx;
							y_origin = y - (int)Dy;

							if(x_origin < 0 || x_origin >= width || y_origin < 0 || y_origin >= height) {
								destinationDataPtr[0] = 255; //blue
								destinationDataPtr[1] = 255; //green
								destinationDataPtr[2] = 255; //red
							} else {
								sum_y = (y_origin + 1 > (height - 1) ? y_origin : y_origin + 1);
								sum_x = (x_origin + 1 > (width - 1) ? x_origin : x_origin + 1);

								auxPtr11 = (sourceDataPtr + y_origin * destination.widthStep + x_origin * nChan);
								auxPtr12 = (sourceDataPtr + sum_y * destination.widthStep + x_origin * nChan);
								auxPtr21 = (sourceDataPtr + y_origin * destination.widthStep + sum_x * nChan);
								auxPtr22 = (sourceDataPtr + sum_y * destination.widthStep + sum_x * nChan);

								//bilinear
								R1_b = (1 - offsetX) * auxPtr11[0] + offsetX * auxPtr21[0];
								R1_g = (1 - offsetX) * auxPtr11[1] + offsetX * auxPtr21[1];
								R1_r = (1 - offsetX) * auxPtr11[2] + offsetX * auxPtr21[2];

								R2_b = (1 - offsetX) * auxPtr12[0] + offsetX * auxPtr22[0];
								R2_g = (1 - offsetX) * auxPtr12[1] + offsetX * auxPtr22[1];
								R2_r = (1 - offsetX) * auxPtr12[2] + offsetX * auxPtr22[2];

								point_b = (1 - offsetY) * R1_b + offsetY * R2_b;
								point_g = (1 - offsetY) * R1_g + offsetY * R2_g;
								point_r = (1 - offsetY) * R1_r + offsetY * R2_r;

								// guarda na imagem
								destinationDataPtr[0] = (byte)point_b; //blue
								destinationDataPtr[1] = (byte)point_g; //green
								destinationDataPtr[2] = (byte)point_r; //red
							}
							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Rotação
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="Ang">ângulo de rotação</param>
		internal static void Rotation(Image<Bgr, byte> img, double Ang) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, sum_x, sum_y, x_origin_int, y_origin_int;
				double R1_b, R1_g, R1_r, R2_b, R2_g, R2_r;
				int point_b, point_g, point_r;
				double offsetX, offsetY, x_origin, y_origin;

				byte* auxPtr11, auxPtr12, auxPtr21, auxPtr22;

				double radians = (Ang * Math.PI) / 180;
				double cos = Math.Cos(radians);
				double sen = Math.Sin(radians);

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							x_origin = (x - (width / 2)) * cos - ((height / 2) - y) * sen + (width / 2);
							y_origin = (height / 2) - ((height / 2) - y) * cos - (x - (width / 2)) * sen;

							offsetX = ((x_origin - (int)x_origin) < 0 ? -(x_origin - (int)x_origin) : (x_origin - (int)x_origin));
							offsetY = ((y_origin - (int)y_origin) < 0 ? -(y_origin - (int)y_origin) : (y_origin - (int)y_origin));

							if(x_origin < 0 || x_origin >= width || y_origin < 0 || y_origin >= height) {

								destinationDataPtr[0] = 255; //blue
								destinationDataPtr[1] = 255; //green
								destinationDataPtr[2] = 255; //red
							} else {

								x_origin_int = (int)x_origin;
								y_origin_int = (int)y_origin;

								sum_y = (y_origin_int + 1 > (height - 1) ? y_origin_int : y_origin_int + 1);
								sum_x = (x_origin_int + 1 > (width - 1) ? x_origin_int : x_origin_int + 1);

								auxPtr11 = (sourceDataPtr + y_origin_int * destination.widthStep + x_origin_int * nChan);
								auxPtr12 = (sourceDataPtr + sum_y * destination.widthStep + x_origin_int * nChan);
								auxPtr21 = (sourceDataPtr + y_origin_int * destination.widthStep + sum_x * nChan);
								auxPtr22 = (sourceDataPtr + sum_y * destination.widthStep + sum_x * nChan);

								//bilinear
								R1_b = (1 - offsetX) * auxPtr11[0] + offsetX * auxPtr21[0];
								R1_g = (1 - offsetX) * auxPtr11[1] + offsetX * auxPtr21[1];
								R1_r = (1 - offsetX) * auxPtr11[2] + offsetX * auxPtr21[2];

								R2_b = (1 - offsetX) * auxPtr12[0] + offsetX * auxPtr22[0];
								R2_g = (1 - offsetX) * auxPtr12[1] + offsetX * auxPtr22[1];
								R2_r = (1 - offsetX) * auxPtr12[2] + offsetX * auxPtr22[2];

								point_b = (int)((1 - offsetY) * R1_b + offsetY * R2_b);
								point_g = (int)((1 - offsetY) * R1_g + offsetY * R2_g);
								point_r = (int)((1 - offsetY) * R1_r + offsetY * R2_r);

								// guarda na imagem
								destinationDataPtr[0] = (byte)point_b; //blue
								destinationDataPtr[1] = (byte)point_g; //green
								destinationDataPtr[2] = (byte)point_r; //red
							}
							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Zoom
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="zoom">factor de ampliação</param>
		/// <param name="x_image">coordenada x do centro</param>
		/// <param name="y_image">coordenada y do centro</param>
		internal static void Zoom(Image<Bgr, byte> img, double zoom, int x_image, int y_image) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, x_origin, y_origin;

				byte* auxPtr;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							x_origin = (int)Math.Round(x / zoom + x_image - x_image / zoom);
							y_origin = (int)Math.Round(y / zoom + y_image - y_image / zoom);

							if(x_origin < 0 || x_origin >= width || y_origin < 0 || y_origin >= height) {
								destinationDataPtr[0] = 255; //blue
								destinationDataPtr[1] = 255; //green
								destinationDataPtr[2] = 255; //red
							} else {
								// guarda na imagem
								auxPtr = (sourceDataPtr + y_origin * destination.widthStep + x_origin * nChan);

								destinationDataPtr[0] = auxPtr[0]; //blue
								destinationDataPtr[1] = auxPtr[1]; //green
								destinationDataPtr[2] = auxPtr[2]; //red
							}
							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Aplicação de filtro de média pelo método A
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="size">tamanho da matriz</param>
		internal static void FilterA(Image<Bgr, byte> img, int size) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, x_f, y_f, sum_x, sum_y;

				byte* auxPtr;

				int margin = (int)(size / 2);
				int area = size * size;
				int blue = 0, green = 0, red = 0;

				try {
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								for(x_f = -1 * margin; x_f <= margin; x_f++) {
									for(y_f = -1 * margin; y_f <= margin; y_f++) {

										sum_y = (y + y_f < 0 ? -(y + y_f) : ((y + y_f) > (height - 1) ? (y - y_f) : (y + y_f)));
										sum_x = (x + x_f < 0 ? -(x + x_f) : ((x + x_f) > (width - 1) ? (x - x_f) : (x + x_f)));

										auxPtr = (sourceDataPtr + sum_y * destination.widthStep + sum_x * nChan);

										blue += auxPtr[0]; //blue
										green += auxPtr[1]; //green
										red += auxPtr[2]; //red
									}
								}

								// guarda na imagem
								destinationDataPtr[0] = (byte)(blue / area); //blue
								destinationDataPtr[1] = (byte)(green / area); //green
								destinationDataPtr[2] = (byte)(red / area); //red
								blue = 0;
								green = 0;
								red = 0;

								// avança apontador para próximo pixel
								destinationDataPtr += nChan;
							}

							//no fim da linha avança alinhamento (padding)
							destinationDataPtr += padding;
						}
					}
				} catch(Exception ex) {
					Console.WriteLine(ex.ToString());
				}
			}
		}

		/// <summary>
		/// Aplicação de filtro 3x3 com valores expecificados pelo método A
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="v_coeficientes">coeficientes especificados</param>
		internal static void FilterMatrix(Image<Bgr, byte> img, int[] v_coeficientes) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, x_f, y_f;

				int margin = 1;
				int weight = v_coeficientes[9];
				int blue = 0, green = 0, red = 0, blue_total = 0, green_total = 0, red_total = 0;
				int i = 0;
				int sum_x, sum_y;

				byte* auxPtr;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							for(y_f = -1 * margin; y_f <= margin; y_f++) {
								for(x_f = -1 * margin; x_f <= margin; x_f++) {

									sum_y = (y + y_f < 0 ? -(y + y_f) : ((y + y_f) > (height - 1) ? (y - y_f) : (y + y_f)));
									sum_x = (x + x_f < 0 ? -(x + x_f) : ((x + x_f) > (width - 1) ? (x - x_f) : (x + x_f)));

									auxPtr = (sourceDataPtr + sum_y * destination.widthStep + sum_x * nChan);

									blue_total += v_coeficientes[i] * auxPtr[0]; //blue
									green_total += v_coeficientes[i] * auxPtr[1]; //green
									red_total += v_coeficientes[i] * auxPtr[2]; //red
									i++;
								}
							}

							blue = (blue_total < 0 ? -blue_total : blue_total) / weight;
							green = (green_total < 0 ? -green_total : green_total) / weight;
							red = (red_total < 0 ? -red_total : red_total) / weight;

							if(blue > 255)
								blue = 255;

							if(green > 255)
								green = 255;

							if(red > 255)
								red = 255;

							// guarda na imagem
							destinationDataPtr[0] = (byte)blue; //blue
							destinationDataPtr[1] = (byte)green; //green
							destinationDataPtr[2] = (byte)red; //red
							blue_total = 0;
							green_total = 0;
							red_total = 0;
							i = 0;

							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Aplicação de filtro de Sobel 5x5 pelo método A
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="v_coeficientes1">coeficientes verticais</param>
		/// <param name="v_coeficientes2">coeficientes horizontais</param>
		internal static void Sobel3x3(Image<Bgr, byte> img, int[] v_coeficientes1, int[] v_coeficientes2) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, x_f, y_f, sum_x, sum_y;

				int margin = 1;
				int blue = 0, green = 0, red = 0, blue_Sx = 0, blue_Sy = 0, green_Sx = 0, green_Sy = 0, red_Sx = 0, red_Sy = 0;
				int i = 0;

				byte* auxPtr;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							for(y_f = -1 * margin; y_f <= margin; y_f++) {
								for(x_f = -1 * margin; x_f <= margin; x_f++) {

									sum_y = (y + y_f < 0 ? -(y + y_f) : ((y + y_f) > (height - 1) ? (y - y_f) : (y + y_f)));
									sum_x = (x + x_f < 0 ? -(x + x_f) : ((x + x_f) > (width - 1) ? (x - x_f) : (x + x_f)));

									auxPtr = (sourceDataPtr + sum_y * destination.widthStep + sum_x * nChan);

									blue_Sx += v_coeficientes1[i] * auxPtr[0]; //blue
									green_Sx += v_coeficientes1[i] * auxPtr[1]; //green
									red_Sx += v_coeficientes1[i] * auxPtr[2]; //red

									blue_Sy += v_coeficientes2[i] * auxPtr[0]; //blue
									green_Sy += v_coeficientes2[i] * auxPtr[1]; //green
									red_Sy += v_coeficientes2[i] * auxPtr[2]; //red
									i++;
								}
							}

							blue = (blue_Sx < 0 ? -blue_Sx : blue_Sx) + (blue_Sy < 0 ? -blue_Sy : blue_Sy);
							green = (green_Sx < 0 ? -green_Sx : green_Sx) + (green_Sy < 0 ? -green_Sy : green_Sy);
							red = (red_Sx < 0 ? -red_Sx : red_Sx) + (red_Sy < 0 ? -red_Sy : red_Sy);

							if(blue > 255)
								blue = 255;

							if(green > 255)
								green = 255;

							if(red > 255)
								red = 255;

							// guarda na imagem
							destinationDataPtr[0] = (byte)blue; //blue
							destinationDataPtr[1] = (byte)green; //green
							destinationDataPtr[2] = (byte)red; //red
							blue_Sx = 0;
							blue_Sy = 0;
							green_Sx = 0;
							green_Sy = 0;
							red_Sx = 0;
							red_Sy = 0; ;
							i = 0;

							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Aplicação de filtro de Sobel 5x5 pelo método A
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="v_coeficientes1">coeficientes verticais</param>
		/// <param name="v_coeficientes2">coeficientes horizontais</param>
		internal static void Sobel5x5(Image<Bgr, byte> img, int[] v_coeficientes1, int[] v_coeficientes2) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, x_f, y_f, sum_x, sum_y;

				int margin = 2;
				int blue = 0, green = 0, red = 0, blue_Sx = 0, blue_Sy = 0, green_Sx = 0, green_Sy = 0, red_Sx = 0, red_Sy = 0;
				int i = 0;

				byte* auxPtr;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							for(y_f = -1 * margin; y_f <= margin; y_f++) {
								for(x_f = -1 * margin; x_f <= margin; x_f++) {

									sum_y = (y + y_f < 0 ? -(y + y_f) : ((y + y_f) > (height - 1) ? (y - y_f) : (y + y_f)));
									sum_x = (x + x_f < 0 ? -(x + x_f) : ((x + x_f) > (width - 1) ? (x - x_f) : (x + x_f)));

									auxPtr = (sourceDataPtr + sum_y * destination.widthStep + sum_x * nChan);

									blue_Sx += v_coeficientes1[i] * auxPtr[0]; //blue
									green_Sx += v_coeficientes1[i] * auxPtr[1]; //green
									red_Sx += v_coeficientes1[i] * auxPtr[2]; //red

									blue_Sy += v_coeficientes2[i] * auxPtr[0]; //blue
									green_Sy += v_coeficientes2[i] * auxPtr[1]; //green
									red_Sy += v_coeficientes2[i] * auxPtr[2]; //red

									i++;
								}
							}

							blue = (int)Math.Sqrt(blue_Sx * blue_Sx + blue_Sy * blue_Sy);
							green = (int)Math.Sqrt(green_Sx * green_Sx + green_Sy * green_Sy);
							red = (int)Math.Sqrt(red_Sx * red_Sx + red_Sy * red_Sy);

							//blue = (blue_Sx < 0 ? -blue_Sx : blue_Sx) + (blue_Sy < 0 ? -blue_Sy : blue_Sy);
							//green = (green_Sx < 0 ? -green_Sx : green_Sx) + (green_Sy < 0 ? -green_Sy : green_Sy);
							//red = (red_Sx < 0 ? -red_Sx : red_Sx) + (red_Sy < 0 ? -red_Sy : red_Sy);

							if(blue > 255)
								blue = 255;

							if(green > 255)
								green = 255;

							if(red > 255)
								red = 255;

							// guarda na imagem
							destinationDataPtr[0] = (byte)blue; //blue
							destinationDataPtr[1] = (byte)green; //green
							destinationDataPtr[2] = (byte)red; //red
							blue_Sx = 0;
							blue_Sy = 0;
							green_Sx = 0;
							green_Sy = 0;
							red_Sx = 0;
							red_Sy = 0; ;
							i = 0;

							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Aplicação de filtro de Diferenciação
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		internal static void Differentiation(Image<Bgr, byte> img) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, sum_x, sum_y;

				int blue = 0, green = 0, red = 0, blue_right = 0, blue_down = 0, green_right = 0, green_down = 0, red_right = 0, red_down = 0;

				byte* auxPtr, auxPtrRight, auxPtrDown;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							sum_y = ((y + 1) > (height - 1) ? (y - 1) : (y + 1));
							sum_x = ((x + 1) > (width - 1) ? (x - 1) : (x + 1));

							auxPtr = (sourceDataPtr + y * destination.widthStep + x * nChan);
							auxPtrRight = (sourceDataPtr + (sum_y - 1) * destination.widthStep + sum_x * nChan);
							auxPtrDown = (sourceDataPtr + sum_y * destination.widthStep + (sum_x - 1) * nChan);

							blue_right = auxPtr[0] - auxPtrRight[0]; //blue
							green_right = auxPtr[1] - auxPtrRight[1]; //green
							red_right = auxPtr[2] - auxPtrRight[2]; //red

							blue_down = auxPtr[0] - auxPtrDown[0]; //blue
							green_down = auxPtr[1] - auxPtrDown[1]; //green
							red_down = auxPtr[2] - auxPtrDown[2]; //red

							blue = (blue_right < 0 ? -blue_right : blue_right) + (blue_down < 0 ? -blue_down : blue_down);
							green = (green_right < 0 ? -green_right : green_right) + (green_down < 0 ? -green_down : green_down);
							red = (red_right < 0 ? -red_right : red_right) + (red_down < 0 ? -red_down : red_down);

							if(blue > 255)
								blue = 255;

							if(green > 255)
								green = 255;

							if(red > 255)
								red = 255;

							// guarda na imagem
							destinationDataPtr[0] = (byte)blue; //blue
							destinationDataPtr[1] = (byte)green; //green
							destinationDataPtr[2] = (byte)red; //red

							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Aplicação de filtro de Roberts
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		internal static void Roberts(Image<Bgr, byte> img) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, sum_x, sum_y;

				int blue = 0, green = 0, red = 0;
				int blue_diag_principal = 0, green_diag_principal = 0, red_diag_principal = 0;
				int blue_diag_secundary = 0, green_diag_secundary = 0, red_diag_secundary = 0;

				byte* auxPtr, auxPtrRight, auxPtrDown, auxPtrDiag;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							sum_y = ((y + 1) > (height - 1) ? (y - 1) : (y + 1));
							sum_x = ((x + 1) > (width - 1) ? (x - 1) : (x + 1));

							auxPtr = (sourceDataPtr + y * destination.widthStep + x * nChan);
							auxPtrRight = (sourceDataPtr + (sum_y - 1) * destination.widthStep + sum_x * nChan);
							auxPtrDown = (sourceDataPtr + sum_y * destination.widthStep + (sum_x - 1) * nChan);
							auxPtrDiag = (sourceDataPtr + sum_y * destination.widthStep + sum_x * nChan);

							blue_diag_principal = auxPtr[0] - auxPtrDiag[0]; //blue
							green_diag_principal = auxPtr[1] - auxPtrDiag[1]; //green
							red_diag_principal = auxPtr[2] - auxPtrDiag[2]; //red

							blue_diag_secundary = auxPtrRight[0] - auxPtrDown[0]; //blue
							green_diag_secundary = auxPtrRight[1] - auxPtrDown[1]; //green
							red_diag_secundary = auxPtrRight[2] - auxPtrDown[2]; //red

							blue = (blue_diag_principal < 0 ? -blue_diag_principal : blue_diag_principal) + (blue_diag_secundary < 0 ? -blue_diag_secundary : blue_diag_secundary);
							green = (green_diag_principal < 0 ? -green_diag_principal : green_diag_principal) + (green_diag_secundary < 0 ? -green_diag_secundary : green_diag_secundary);
							red = (red_diag_principal < 0 ? -red_diag_principal : red_diag_principal) + (red_diag_secundary < 0 ? -red_diag_secundary : red_diag_secundary);

							if(blue > 255)
								blue = 255;

							if(green > 255)
								green = 255;

							if(red > 255)
								red = 255;

							// guarda na imagem
							destinationDataPtr[0] = (byte)blue; //blue
							destinationDataPtr[1] = (byte)green; //green
							destinationDataPtr[2] = (byte)red; //red

							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Aplicação de filtro de Média
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		internal static void Median(Image<Bgr, byte> img) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				Image<Bgr, byte> imgSource = null;
				imgSource = img.Copy();

				MIplImage source = imgSource.MIplImage;
				byte* sourceDataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				MIplImage destination = img.MIplImage;
				byte* destinationDataPtr = (byte*)destination.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = source.nChannels; // numero de canais 3
				int padding = source.widthStep - source.nChannels * source.width; // alinhamento (padding)
				int x, y, sum_xp, sum_xm, sum_yp, sum_ym, i, j, minIndex, min;

				int[] dist_points = new int[9];

				int[] blue = new int[9];
				int[] green = new int[9];
				int[] red = new int[9];
				int[] delta = new int[9];

				byte* auxPtr11, auxPtr12, auxPtr13, auxPtr21, auxPtr22, auxPtr23, auxPtr31, auxPtr32, auxPtr33;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							sum_ym = (y - 1 < 0 ? -(y - 1) : y - 1);
							sum_yp = ((y + 1) > (height - 1) ? y - 1 : y + 1);
							sum_xm = (x - 1 < 0 ? -(x - 1) : x - 1);
							sum_xp = ((x + 1) > (width - 1) ? x - 1 : x + 1);

							auxPtr11 = (sourceDataPtr + (sum_ym) * destination.widthStep + (sum_xm) * nChan);
							blue[0] = auxPtr11[0]; //blue
							green[0] = auxPtr11[1]; //green
							red[0] = auxPtr11[2]; //red

							auxPtr12 = (sourceDataPtr + (sum_ym) * destination.widthStep + (x) * nChan);
							blue[1] = auxPtr12[0]; //blue
							green[1] = auxPtr12[1]; //green
							red[1] = auxPtr12[2]; //red

							auxPtr13 = (sourceDataPtr + (sum_ym) * destination.widthStep + (sum_xp) * nChan);
							blue[2] = auxPtr13[0]; //blue
							green[2] = auxPtr13[1]; //green
							red[2] = auxPtr13[2]; //red

							auxPtr21 = (sourceDataPtr + (y) * destination.widthStep + (sum_xm) * nChan);
							blue[3] = auxPtr21[0]; //blue
							green[3] = auxPtr21[1]; //green
							red[3] = auxPtr21[2]; //red

							auxPtr22 = (sourceDataPtr + (y) * destination.widthStep + (x) * nChan);
							blue[4] = auxPtr22[0]; //blue
							green[4] = auxPtr22[1]; //green
							red[4] = auxPtr22[2]; //red

							auxPtr23 = (sourceDataPtr + (y) * destination.widthStep + (sum_xp) * nChan);
							blue[5] = auxPtr23[0]; //blue
							green[5] = auxPtr23[1]; //green
							red[5] = auxPtr23[2]; //red

							auxPtr31 = (sourceDataPtr + (sum_yp) * destination.widthStep + (sum_xm) * nChan);
							blue[6] = auxPtr31[0]; //blue
							green[6] = auxPtr31[1]; //green
							red[6] = auxPtr31[2]; //red

							auxPtr32 = (sourceDataPtr + (sum_yp) * destination.widthStep + (x) * nChan);
							blue[7] = auxPtr32[0]; //blue
							green[7] = auxPtr32[1]; //green
							red[7] = auxPtr32[2]; //red

							auxPtr33 = (sourceDataPtr + (sum_yp) * destination.widthStep + (sum_xp) * nChan);
							blue[8] = auxPtr33[0]; //blue
							green[8] = auxPtr33[1]; //green
							red[8] = auxPtr33[2]; //red

							for(i = 0; i < 9; i++) {
								for(j = 0; j < 9; j++) {
									if(i != j) {
										delta[i] += ((blue[i] - blue[j]) < 0 ? -(blue[i] - blue[j]) : (blue[i] - blue[j])) + ((green[i] - green[j]) < 0 ? -(green[i] - green[j]) : (green[i] - green[j])) + ((red[i] - red[j]) < 0 ? -(red[i] - red[j]) : (red[i] - red[j]));
									}
								}
							}

							min = delta.Min();
							minIndex = delta.ToList().IndexOf(min);

							// guarda na imagem
							destinationDataPtr[0] = (byte)blue[minIndex]; //blue
							destinationDataPtr[1] = (byte)green[minIndex]; //green
							destinationDataPtr[2] = (byte)red[minIndex]; //red

							delta[0] = 0;
							delta[1] = 0;
							delta[2] = 0;
							delta[3] = 0;
							delta[4] = 0;
							delta[5] = 0;
							delta[6] = 0;
							delta[7] = 0;
							delta[8] = 0;

							// avança apontador para próximo pixel
							destinationDataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						destinationDataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Binarização por Método de Otsu
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		internal static void Otsu(Image<Bgr, byte> img) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = img.MIplImage;
				byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y, gray, i, n;
				float q1 = 0, q2 = 0, u1 = 0, u2 = 0, difference;

				float max = 0;
				int thres = 0;

				//histogram array
				int[] arrayGray = new int[256];
				//probability array
				float[] arrayProb = new float[256];
				//sigma array
				float[] arraySigma = new float[256];

				//amount of pixels
				int pixel_area = width * height;

				//make a histogram
				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							gray = (dataPtr[0] + dataPtr[1] + dataPtr[2]) / 3;
							arrayGray[gray]++;

							// avança apontador para próximo pixel
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtr += padding;
					}
				}

				//producing array of probabilities
				for(i = 0; i < 256; i++) {
					arrayProb[i] = (float)arrayGray[i] / pixel_area;
				}

				//algoritm
				for(n = 0; n < 256; n++) {

					//sum of probabilities left
					for(i = 0; i <= n; i++) { //q1
						q1 += arrayProb[i];
					}

					//sum of probabilities right
					q2 = 1 - q1; //q2

					for(i = 0; i <= n; i++) { //u1
						u1 += i * arrayProb[i];
					}

					for(i = n + 1; i < 256; i++) { //u2
						u2 += i * arrayProb[i];
					}

					//check if some of the sum of probabilities is 0 for division by 0
					if(q1 * q2 != 0) {
						difference = (u1 / q1) - (u2 / q2);
						arraySigma[n] = q1 * q2 * (difference * difference);
					} else {
						arraySigma[n] = 0;
					}

					//reinicialize variables
					q1 = 0;
					q2 = 0;
					u1 = 0;
					u2 = 0;

					//check for max
					if(max < arraySigma[n]) {
						max = arraySigma[n];
						thres = n;
					}
				}
				//apply threshold
				Binarization(img, thres);
			}
		}

		/// <summary>
		/// Histograma
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		internal static void Histogram(Image<Bgr, byte> img) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = img.MIplImage;
				byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y;
				int gray;

				int[] arrayGray = new int[256];
				int[] arrayB = new int[256];
				int[] arrayG = new int[256];
				int[] arrayR = new int[256];

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							gray = (dataPtr[0] + dataPtr[1] + dataPtr[2]) / 3;

							arrayGray[gray]++;
							arrayB[dataPtr[0]]++;
							arrayG[dataPtr[1]]++;
							arrayR[dataPtr[2]]++;

							// avança apontador para próximo pixel
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtr += padding;
					}
				}
				Histogram formX = new Histogram(arrayGray, arrayB, arrayG, arrayR, arrayGray.Length);
				formX.ShowDialog();
			}
		}

		/// <summary>
		/// Histograma só de um dos eixos
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="axis">eixo</param>
		internal static int[] HistogramXY(Image<Bgr, byte> img, char axis) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = img.MIplImage;
				byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y;

				//amount of pixels
				int pixel_area = width * height;
				int[] array;

				if(axis == 'x') {
					array = new int[width];
				} else {
					array = new int[height];
				}

				if(axis == 'x') {
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								if((dataPtr[0] == 255) && (dataPtr[1] == 255) && (dataPtr[2] == 255)) {
									array[x]++;
								}

								// avança apontador para próximo pixel
								dataPtr += nChan;
							}

							//no fim da linha avança alinhamento (padding)
							dataPtr += padding;
						}
					}
				} else {
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								if((dataPtr[0] == 255) && (dataPtr[1] == 255) && (dataPtr[2] == 255)) {
									array[y]++;
								}

								// avança apontador para próximo pixel
								dataPtr += nChan;
							}

							//no fim da linha avança alinhamento (padding)
							dataPtr += padding;
						}
					}
				}
				//Histogram formX = new Histogram(array, array, array, array, array.Length);
				//formX.ShowDialog();
				return array;
			}
		}

		/// <summary>
		/// Histograma de um dos eixos em cooredenadas especificas
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="axis">eixo</param>
		/// <param name="coordenate1">coordenada de início</param>
		/// <param name="coordenate2">coordenada de fim</param>
		internal static int[] HistogramCustom(Image<Bgr, byte> img, char axis, int coordenate1, int coordenate2) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = img.MIplImage;
				byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y;

				//amount of pixels
				int pixel_area = width * height;
				int[] array;

				if(axis == 'x') {
					array = new int[width];
				} else {
					array = new int[height];
				}

				if(axis == 'x') {
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								if((y >= coordenate1 && y <= coordenate2) && (dataPtr[0] == 255) && (dataPtr[1] == 255) && (dataPtr[2] == 255)) {
									array[x]++;
								}

								// avança apontador para próximo pixel
								dataPtr += nChan;
							}

							//no fim da linha avança alinhamento (padding)
							dataPtr += padding;
						}
					}
				} else {
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								if((x >= coordenate1 && x <= coordenate2) && (dataPtr[0] == 255) && (dataPtr[1] == 255) && (dataPtr[2] == 255)) {
									array[y]++;
								}

								// avança apontador para próximo pixel
								dataPtr += nChan;
							}

							//no fim da linha avança alinhamento (padding)
							dataPtr += padding;
						}
					}
				}
				//Histogram formX = new Histogram(array, array, array, array, array.Length);
				//formX.ShowDialog();
				return array;
			}
		}

		/// <summary>
		/// Detecção de Vermelho
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="MF">MainForm</param>
		internal static void RedDetectionFailed(Image<Bgr, byte> imgOriginal, MainForm MF) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				MIplImage m = imgOriginal.MIplImage;
				byte* dataPtrOriginal = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				Image<Bgr, byte> img = null;
				img = imgOriginal.Copy();

				MIplImage source = img.MIplImage;
				byte* dataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y;

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							if(dataPtr[2] > 120 && dataPtr[1] < 100 && dataPtr[0] < 100) {

								// guarda na imagem
								dataPtr[0] = 255; //blue
								dataPtr[1] = 255; //green
								dataPtr[2] = 255; //red
							} else {
								// guarda na imagem
								dataPtr[0] = 0; //blue
								dataPtr[1] = 0; //green
								dataPtr[2] = 0; //red
							}

							// avança apontador para próximo pixel
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtr += padding;
					}
				}
				FilterA(img, 9);
				Otsu(img);

				int[] arrayX = HistogramXY(img, 'x');
				int[] arrayY = HistogramXY(img, 'y');
				int i, max = 0, index = 0, ptrLeft = 0, ptrRight = 0, dist = 1, area = 0, last_area = 0;

				for(i = 0; i < width; i++) {
					index = (max < arrayX[i] ? i : index);
					max = (max < arrayX[i] ? arrayX[i] : max);
				}

				/*AREA OPTIMIZATION WITH OTSU*/

				float[] arrayProbX = new float[width];
				float[] arrayProbY = new float[height];
				float[] arraySigmaX, arraySigmaY;

				int n, thresX = 0, thresY = 0;
				float q1 = 0, q2 = 0, u1 = 0, u2 = 0, difference;
				float maxX = 0, maxY = 0;

				//amount of pixels
				int pixel_area = width * height;

				//producing array of probabilities for X
				for(i = 0; i < width; i++) {
					arrayProbX[i] = (float)arrayX[i] / pixel_area;
				}

				//producing array of probabilities for Y
				for(i = 0; i < height; i++) {
					arrayProbY[i] = (float)arrayY[i] / pixel_area;
				}

				arraySigmaX = new float[width];

				//algoritm for X
				for(n = 0; n < width; n++) {

					//sum of probabilities left
					for(i = 0; i <= n; i++) { //q1
						q1 += arrayProbX[i];
					}

					//sum of probabilities right
					for(i = n + 1; i < width; i++) { //q2
						q2 += arrayProbX[i];
					}

					for(i = 0; i <= n; i++) { //u1
						u1 += i * arrayProbX[i];
					}

					for(i = n + 1; i < width; i++) { //u2
						u2 += i * arrayProbX[i];
					}

					//check if some of the sum of probabilities is 0 for division by 0
					if(q1 * q2 != 0) {
						difference = (u1 / q1) - (u2 / q2);
						arraySigmaX[n] = q1 * q2 * (difference * difference);
					} else {
						arraySigmaX[n] = 0;
					}

					//reinicialize variables
					q1 = 0;
					q2 = 0;
					u1 = 0;
					u2 = 0;

					//check for max
					if(maxX < arraySigmaX[n]) {
						maxX = arraySigmaX[n];
						thresX = n;
					}
				}

				arraySigmaY = new float[height];

				//algoritm for Y
				for(n = 0; n < height; n++) {

					//sum of probabilities left
					for(i = 0; i <= n; i++) { //q1
						q1 += arrayProbY[i];
					}

					//sum of probabilities right
					for(i = n + 1; i < height; i++) { //q2
						q2 += arrayProbY[i];
					}

					for(i = 0; i <= n; i++) { //u1
						u1 += i * arrayProbY[i];
					}

					for(i = n + 1; i < height; i++) { //u2
						u2 += i * arrayProbY[i];
					}

					//check if some of the sum of probabilities is 0 for division by 0
					if(q1 * q2 != 0) {
						difference = (u1 / q1) - (u2 / q2);
						arraySigmaY[n] = q1 * q2 * (difference * difference);
					} else {
						arraySigmaY[n] = 0;
					}

					//reinicialize variables
					q1 = 0;
					q2 = 0;
					u1 = 0;
					u2 = 0;

					//check for max
					if(maxY < arraySigmaY[n]) {
						maxY = arraySigmaY[n];
						thresY = n;
					}
				}

				/*AREA OPTIMIZATION WITH OTSU*/

				/*GETTING THE OBJECT*/

				int leftDelta = 0, rightDelta = 0;
				int upDelta = 0, downDelta = 0;
				int ptrUp = 0, ptrDown = 0;

				area = arrayX[thresX];
				last_area = area;
				ptrRight = thresX + dist;
				area = area + arrayX[ptrRight];
				rightDelta = area - last_area;

				while(rightDelta > 10 && ptrRight < width) {
					area = area + arrayX[ptrRight];
					rightDelta = area - last_area;
					last_area = area;

					dist++;

					ptrRight = thresX + dist;
				}

				dist = 1; //reset of the variable
				area = arrayX[thresX];
				last_area = area;
				ptrLeft = thresX - dist;
				area = area + arrayX[ptrLeft];
				leftDelta = area - last_area;

				while(leftDelta > 10 && ptrLeft > 0) {
					area = area + arrayX[ptrLeft];
					leftDelta = area - last_area;
					last_area = area;

					dist++;

					ptrLeft = thresX - dist;
				}

				dist = 1; //reset of the variable
				area = arrayY[thresY];
				last_area = area;
				ptrUp = thresY + dist;
				area = area + arrayY[ptrUp];
				upDelta = area - last_area;

				while(upDelta > 20 && ptrUp < height) {
					area = area + arrayY[ptrUp];
					upDelta = area - last_area;
					last_area = area;

					dist++;

					ptrUp = thresY + dist;
				}

				dist = 1; //reset of the variable
				area = arrayY[thresY];
				last_area = area;
				ptrDown = thresY - dist;
				area = area + arrayY[ptrDown];
				downDelta = area - last_area;

				while(downDelta > 20 && ptrDown > 0) {
					area = area + arrayY[ptrDown];
					downDelta = area - last_area;
					last_area = area;

					dist++;

					ptrDown = thresY - dist;
				}

				/*GETTING THE OBJECT*/

				m = img.MIplImage;
				dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				//Image<Bgr, byte> img2 = img.Copy(new System.Drawing.Rectangle(ptrLeft, ptrDown, (ptrRight - ptrLeft), (ptrUp - ptrDown)));

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							if((x >= ptrLeft && y == ptrDown && x <= ptrRight) || (x == ptrRight && y <= ptrUp && y >= ptrDown) || (y == ptrUp && x >= ptrLeft && x <= ptrRight) || (x == ptrLeft && y <= ptrUp && y >= ptrDown)) {

								// guarda na imagem
								dataPtrOriginal[0] = 255; //blue
								dataPtrOriginal[1] = 255; //green
								dataPtrOriginal[2] = 0; //red

								// guarda na imagem
								dataPtr[0] = 255; //blue
								dataPtr[1] = 255; //green
								dataPtr[2] = 0; //red
							}

							// avança apontador para próximo pixel
							dataPtrOriginal += nChan;
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtrOriginal += padding;
						dataPtr += padding;
					}
				}
			}
		}

		/// <summary>
		/// Detecção de Vermelho
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="imgGet">imagem</param>
		/// <param name="MF">MainFrom</param>
		internal static int[] RedDetection(Image<Bgr, byte> imgGet, MainForm MF) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				//vai buscar e guarda uma copia da imagem original
				Image<Bgr, byte> imgOriginal = null;
				imgOriginal = imgGet.Copy();

				MIplImage m = imgOriginal.MIplImage;
				byte* dataPtrOriginal = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				//vai buscar e guarda uma copia da imagem original para ser alterada e analizada
				Image<Bgr, byte> img = null;
				img = imgGet.Copy();

				MIplImage source = img.MIplImage;
				byte* dataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y, i;
				int thickness = 2;

				//diferença entre uma componente de cor e outra
				float diff = 0.15f; //%

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							//verifica se é vermelho (desejado)
							if((((float)dataPtr[1] / 255 <= (float)dataPtr[2] / 255 - diff) && (((float)dataPtr[0] / 255 <= (float)dataPtr[2] / 255 - diff)))) {

								// guarda na imagem
								dataPtr[0] = 255; //blue
								dataPtr[1] = 255; //green
								dataPtr[2] = 255; //red
							} else {
								// guarda na imagem
								dataPtr[0] = 0; //blue
								dataPtr[1] = 0; //green
								dataPtr[2] = 0; //red
							}

							// avança apontador para próximo pixel
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtr += padding;
					}
				}

				//histograma das colunas
				int[] arrayX = HistogramXY(img, 'x');

				List<int> objectsX1X2 = new List<int>();
				List<int> objectsY1Y2 = new List<int>();
				List<int> areaX = new List<int>();
				int same_object = 0;
				int area = 0, x1 = 0, x2 = 0, y1 = 0, y2 = 0;

				//1º NIVEL DE SEGMENTAÇÃO

				//procura tudo o que podemos considerar objecto
				for(i = 0; i < width; i++) {
					if(arrayX[i] != 0 && same_object == 0) {
						objectsX1X2.Add(i); //inicial
						same_object = 1;
					} else if(arrayX[i] == 0 && same_object == 1) {
						objectsX1X2.Add(i - 1); //final
						same_object = 0;
					}
				}

				int[] arrayArea = objectsX1X2.ToArray();

				//procura o maior objecto
				for(i = 0; i < arrayArea.Length - 1; i = i + 2) {
					if(area < arrayArea[i + 1] - arrayArea[i]) {
						area = arrayArea[i + 1] - arrayArea[i];
						x1 = arrayArea[i];
						x2 = arrayArea[i + 1];
					}
				}

				//histograma das linhas entre limitadas verticalmente por x1 e x2
				int[] arrayY = HistogramCustom(img, 'y', x1, x2);
				same_object = 0;

				//procura tudo o que podemos considerar objecto
				for(i = 0; i < arrayY.Length; i++) {
					if(arrayY[i] != 0 && same_object == 0) {
						objectsY1Y2.Add(i); //inicial
						same_object = 1;
					} else if(arrayY[i] == 0 && same_object == 1) {
						objectsY1Y2.Add(i - 1); //final
						same_object = 0;
					}
				}

				arrayArea = objectsY1Y2.ToArray();
				area = 0;

				//procura o maior objecto
				for(i = 0; i < arrayArea.Length - 1; i = i + 2) {
					if(area < arrayArea[i + 1] - arrayArea[i]) {
						area = arrayArea[i + 1] - arrayArea[i];
						y1 = arrayArea[i];
						y2 = arrayArea[i + 1];
					}
				}

				//2º NIVEL DE SEGMENTAÇÃO

				objectsX1X2 = new List<int>();
				same_object = 0;

				//histograma das colunas entre limitadas horizontalmente por y1 e y2
				arrayX = HistogramCustom(img, 'x', y1, y2);

				//procura tudo o que podemos considerar objecto
				for(i = 0; i < arrayX.Length; i++) {
					if(arrayX[i] != 0 && same_object == 0) {
						objectsX1X2.Add(i); //inicial
						same_object = 1;
					} else if(arrayX[i] == 0 && same_object == 1) {
						objectsX1X2.Add(i - 1); //final
						same_object = 0;
					}
				}

				arrayArea = objectsX1X2.ToArray();
				area = 0;

				//procura o maior objecto
				for(i = 0; i < arrayArea.Length - 1; i = i + 2) {
					if(area < arrayArea[i + 1] - arrayArea[i]) {
						area = arrayArea[i + 1] - arrayArea[i];
						x2 = arrayArea[i + 1];
						x1 = arrayArea[i];
					}
				}

				//histograma das linhas entre limitadas verticalmente por x1 e x2
				arrayY = HistogramCustom(img, 'y', x1, x2);
				same_object = 0;

				//procura tudo o que podemos considerar objecto
				for(i = 0; i < arrayY.Length; i++) {
					if(arrayY[i] != 0 && same_object == 0) {
						objectsY1Y2.Add(i); //inicial
						same_object = 1;
					} else if(arrayY[i] == 0 && same_object == 1) {
						objectsY1Y2.Add(i - 1); //final
						same_object = 0;
					}
				}

				arrayArea = objectsY1Y2.ToArray();
				area = 0;

				//procura o maior objecto
				for(i = 0; i < arrayArea.Length - 1; i = i + 2) {
					if(area < arrayArea[i + 1] - arrayArea[i]) {
						area = arrayArea[i + 1] - arrayArea[i];
						y1 = arrayArea[i];
						y2 = arrayArea[i + 1];
					}
				}

				//desenho do quadrado à volta do sinal
				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {
							
							if((x >= x1 - thickness && y >= y2 && y <= y2 + thickness && x <= x2 + thickness) ||
								(x >= x2 && x <= x2 + thickness && y <= y2 && y >= y1) ||
								(y >= y1 - thickness && y <= y1 && x >= x1 - thickness && x <= x2 + thickness) ||
								(x >= x1 - thickness && x <= x1 && y <= y2 && y >= y1)) {

								// guarda na imagem
								dataPtrOriginal[0] = 255; //blue
								dataPtrOriginal[1] = 255; //green
								dataPtrOriginal[2] = 0; //red
							}

							// avança apontador para próximo pixel
							dataPtrOriginal += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtrOriginal += padding;
					}
				}
				MF.ImageViewer.Image = imgOriginal.Bitmap;
				int[] image = new int[] { x1, x2, y1, y2 };
				return image;
			}
		}

		/// <summary>
		/// Detecção de sinal de trânsito vermelhos
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="MF">MainFrom</param>
		/// <param name="DataBase">Base de dados de imagens</param>
		/// <param name="NamesDataBase">Nomes referentes aos sinais de trânsito</param>
		internal static void RedSignDetection(Image<Bgr, byte> img, MainForm MF, List<Image<Bgr, byte>> DataBase, List<string> NamesDataBase) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				//definição de um tamanho standard
				int width = 111;
				int height = 111;

				int x, y, i = 0;
				int nChan;
				int padding;
				int[] coordenates = RedDetection(img, MF);

				//diferença entre uma componente de cor e outra
				float diff = 0.15f; //%

				//verificação se alguma coisa foi encontrada
				if(coordenates[0] != 0 || coordenates[1] != 0 || coordenates[2] != 0 || coordenates[3] != 0) {

					//copiar só o sinal da imagem original
					Image<Bgr, byte> imgSelected = img.Copy(new System.Drawing.Rectangle(coordenates[0], coordenates[2], (coordenates[1] - coordenates[0]), (coordenates[3] - coordenates[2])));

					//redimensionar para o tamanho standard
					Image<Bgr, byte> imgResized = imgSelected.Resize(width, height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

					//apontador para a nova imagem redimensionada
					MIplImage m = imgResized.MIplImage;
					byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

					nChan = m.nChannels; // numero de canais 3
					padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)

					//tudo o que estiver fora do sinal, é retirado (do lado esquerdo)
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								//se vermelho, avança para a linha seguinte
								if((((float)dataPtr[1] / 255 <= (float)dataPtr[2] / 255 - diff) && (((float)dataPtr[0] / 255 <= (float)dataPtr[2] / 255 - diff)))) {
									dataPtr = dataPtr + (width - x) * nChan;
									break;
								}

								dataPtr[2] = 255;
								dataPtr[1] = 255;
								dataPtr[0] = 255;

								// avança apontador para próximo pixel
								dataPtr += nChan;
							}
							//no fim da linha avança alinhamento (padding)
							dataPtr += padding;
						}
					}

					//reinicializar o apontador
					dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

					byte* auxPtr;

					//tudo o que estiver fora do sinal, é retirado (do lado direito)
					for(y = 0; y < height; y++) {
						for(x = width - 1; x >= 0; x--) {

							auxPtr = (dataPtr + y * m.widthStep + x * nChan);

							//se vermelho, avança para a linha seguinte
							if((((float)auxPtr[1] / 255 <= (float)auxPtr[2] / 255 - diff) && (((float)auxPtr[0] / 255 <= (float)auxPtr[2] / 255 - diff)))) {
								break;
							}

							auxPtr[2] = 255;
							auxPtr[1] = 255;
							auxPtr[0] = 255;
						}
					}

					//converte qualquer vermelho para vermelho puro e qualquer "preto" para preto puro
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								//se for vermelho
								if((((float)dataPtr[1] / 255 <= (float)dataPtr[2] / 255 - diff) && (((float)dataPtr[0] / 255 <= (float)dataPtr[2] / 255 - diff)))) {
									dataPtr[2] = 255;
									dataPtr[1] = 0;
									dataPtr[0] = 0;
								} else {
									//se for preto
									if((float)dataPtr[0] / 255 <= 0.35 && (float)dataPtr[1] / 255 <= 0.35 && (float)dataPtr[2] / 255 <= 0.40) {
										dataPtr[2] = 0;
										dataPtr[1] = 0;
										dataPtr[0] = 0;
									} else {
										dataPtr[2] = 255;
										dataPtr[1] = 255;
										dataPtr[0] = 255;
									}
								}

								// avança apontador para próximo pixel
								dataPtr += nChan;
							}
							//no fim da linha avança alinhamento (padding)
							dataPtr += padding;
						}
					}

					int total = 0;
					int nameIndex = 0;
					float total_percentage;
					float percentage = 0;
					Image<Bgr, byte> imgShow = null;
					Image<Bgr, byte> temp = null;

					//amount of pixels
					int pixel_area = width * height;

					//por cada imagem na base de dados
					foreach(Image<Bgr, byte> imgDBGet in DataBase) {

						//redimensionar a imagem para o tamanho standard
						Image<Bgr, byte> imgDB = imgDBGet.Resize(width, height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

						//obter uma copia da imagem para depois ser mostrada
						temp = imgDBGet.Copy();

						//criar apontador para a imagem
						MIplImage n = imgDB.MIplImage;
						byte* dataPtrDB = (byte*)n.imageData.ToPointer(); // obter apontador do inicio da imagem

						//reinicializar o apontador para a imagem a analisar
						m = imgResized.MIplImage;
						dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

						nChan = n.nChannels; // numero de canais 3
						padding = n.widthStep - n.nChannels * n.width; // alinhamento (padding)

						//converte qualquer vermelho para vermelho puro e qualquer "preto" para preto puro
						if(nChan == 3) { // imagem em RGB
							for(y = 0; y < height; y++) {
								for(x = 0; x < width; x++) {

									//se for vermelho
									if((((float)dataPtrDB[1] / 255 <= (float)dataPtrDB[2] / 255 - diff) && (((float)dataPtrDB[0] / 255 <= (float)dataPtrDB[2] / 255 - diff)))) {
										dataPtrDB[2] = 255;
										dataPtrDB[1] = 0;
										dataPtrDB[0] = 0;
									} else {
										//se for preto
										if((float)dataPtrDB[0] / 255 <= 0.15 && (float)dataPtrDB[1] / 255 <= 0.15 && (float)dataPtrDB[2] / 255 <= 0.15) {
											dataPtrDB[2] = 0;
											dataPtrDB[1] = 0;
											dataPtrDB[0] = 0;
										} else {
											dataPtrDB[2] = 255;
											dataPtrDB[1] = 255;
											dataPtrDB[0] = 255;
										}
									}

									// avança apontador para próximo pixel
									dataPtrDB += nChan;
								}
								//no fim da linha avança alinhamento (padding)
								dataPtrDB += padding;
							}
						}

						//reinicializar o apontador da imagem da base de dados
						dataPtrDB = (byte*)n.imageData.ToPointer(); // obter apontador do inicio da imagem

						//compara pixel a pixel para determinar a "igualdade" das imagens
						if(nChan == 3) { // imagem em RGB
							for(y = 0; y < height; y++) {
								for(x = 0; x < width; x++) {

									total = ((dataPtr[0] == dataPtrDB[0] && dataPtr[1] == dataPtrDB[1] && dataPtr[2] == dataPtrDB[2]) ? total + 1 : total);

									// avança apontador para próximo pixel
									dataPtr += nChan;
									dataPtrDB += nChan;
								}

								//no fim da linha avança alinhamento (padding)
								dataPtr += padding;
								dataPtrDB += padding;
							}
						}

						total_percentage = ((float)total / pixel_area);
						total = 0;

						//guarda o sinal com maior percentagem
						if(total_percentage > percentage) {
							percentage = total_percentage;
							nameIndex = i;
							imgShow = temp.Resize(width, height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
						}
						i++;
					}

					//apresenta o caso mais provavel do sinal
					Identified form = new Identified();
					form.Probability.Text = percentage.ToString("p2");
					form.NameSign.Text = NamesDataBase[nameIndex].ToString();
					form.IdentifiedViewer.Image = imgShow.Bitmap;
					form.ShowDialog();
				} else {
					ImageNotFound form = new ImageNotFound();
					form.ShowDialog();
				}
			}
		}

		/// <summary>
		/// Detecção de Azul
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="imgGet">imagem</param>
		/// <param name="MF">MainFrom</param>
		internal static int[] BlueDetection(Image<Bgr, byte> imgGet, MainForm MF) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				//vai buscar e guarda uma copia da imagem original
				Image<Bgr, byte> imgOriginal = null;
				imgOriginal = imgGet.Copy();

				MIplImage m = imgOriginal.MIplImage;
				byte* dataPtrOriginal = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

				//vai buscar e guarda uma copia da imagem original para ser alterada e analizada
				Image<Bgr, byte> img = null;
				img = imgGet.Copy();

				MIplImage source = img.MIplImage;
				byte* dataPtr = (byte*)source.imageData.ToPointer(); // obter apontador do inicio da imagem

				int width = img.Width;
				int height = img.Height;
				int nChan = m.nChannels; // numero de canais 3
				int padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)
				int x, y, i;
				int thickness = 2;

				//diferença entre azul e verde
				float diff = 0.22f; //%
				//diferença entre verde e vermelho
				float diff2 = 0.1f; //%

				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							//verifica se é azul (desejado)
							if((((float)dataPtr[1] / 255 <= (float)dataPtr[0] / 255 - diff) && (((float)dataPtr[2] / 255 <= (float)dataPtr[1] / 255 - diff2)))) {
								
								// guarda na imagem
								dataPtr[0] = 255; //blue
								dataPtr[1] = 255; //green
								dataPtr[2] = 255; //red
							} else {
								// guarda na imagem
								dataPtr[0] = 0; //blue
								dataPtr[1] = 0; //green
								dataPtr[2] = 0; //red
							}

							// avança apontador para próximo pixel
							dataPtr += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtr += padding;
					}
				}

				//histograma das colunas
				int[] arrayX = HistogramXY(img, 'x');

				List<int> objectsX1X2 = new List<int>();
				List<int> objectsY1Y2 = new List<int>();
				List<int> areaX = new List<int>();
				int same_object = 0;
				int area = 0, x1 = 0, x2 = 0, y1 = 0, y2 = 0;

				//1º NIVEL DE SEGMENTAÇÃO

				//procura tudo o que podemos considerar objecto
				for(i = 0; i < width; i++) {
					if(arrayX[i] != 0 && same_object == 0) {
						objectsX1X2.Add(i); //inicial
						same_object = 1;
					} else if(arrayX[i] == 0 && same_object == 1) {
						objectsX1X2.Add(i - 1); //final
						same_object = 0;
					}
				}

				int[] arrayArea = objectsX1X2.ToArray();

				//procura o maior objecto
				for(i = 0; i < arrayArea.Length - 1; i = i + 2) {
					if(area < arrayArea[i + 1] - arrayArea[i]) {
						area = arrayArea[i + 1] - arrayArea[i];
						x1 = arrayArea[i];
						x2 = arrayArea[i + 1];
					}
				}

				//histograma das linhas entre limitadas verticalmente por x1 e x2
				int[] arrayY = HistogramCustom(img, 'y', x1, x2);
				same_object = 0;

				//procura tudo o que podemos considerar objecto
				for(i = 0; i < arrayY.Length; i++) {
					if(arrayY[i] != 0 && same_object == 0) {
						objectsY1Y2.Add(i); //inicial
						same_object = 1;
					} else if(arrayY[i] == 0 && same_object == 1) {
						objectsY1Y2.Add(i - 1); //final
						same_object = 0;
					}
				}

				arrayArea = objectsY1Y2.ToArray();
				area = 0;

				//procura o maior objecto
				for(i = 0; i < arrayArea.Length - 1; i = i + 2) {
					if(area < arrayArea[i + 1] - arrayArea[i]) {
						area = arrayArea[i + 1] - arrayArea[i];
						y1 = arrayArea[i];
						y2 = arrayArea[i + 1];
					}
				}

				//2º NIVEL DE SEGMENTAÇÃO

				objectsX1X2 = new List<int>();
				same_object = 0;

				//histograma das colunas entre limitadas horizontalmente por y1 e y2
				arrayX = HistogramCustom(img, 'x', y1, y2);

				//procura tudo o que podemos considerar objecto
				for(i = 0; i < arrayX.Length; i++) {
					if(arrayX[i] != 0 && same_object == 0) {
						objectsX1X2.Add(i); //inicial
						same_object = 1;
					} else if(arrayX[i] == 0 && same_object == 1) {
						objectsX1X2.Add(i - 1); //final
						same_object = 0;
					}
				}

				arrayArea = objectsX1X2.ToArray();
				area = 0;

				//procura o maior objecto
				for(i = 0; i < arrayArea.Length - 1; i = i + 2) {
					if(area < arrayArea[i + 1] - arrayArea[i]) {
						area = arrayArea[i + 1] - arrayArea[i];
						x2 = arrayArea[i + 1];
						x1 = arrayArea[i];
					}
				}

				//histograma das linhas entre limitadas verticalmente por x1 e x2
				arrayY = HistogramCustom(img, 'y', x1, x2);
				same_object = 0;

				//procura tudo o que podemos considerar objecto
				for(i = 0; i < arrayY.Length; i++) {
					if(arrayY[i] != 0 && same_object == 0) {
						objectsY1Y2.Add(i); //inicial
						same_object = 1;
					} else if(arrayY[i] == 0 && same_object == 1) {
						objectsY1Y2.Add(i - 1); //final
						same_object = 0;
					}
				}

				arrayArea = objectsY1Y2.ToArray();
				area = 0;

				//procura o maior objecto
				for(i = 0; i < arrayArea.Length - 1; i = i + 2) {
					if(area < arrayArea[i + 1] - arrayArea[i]) {
						area = arrayArea[i + 1] - arrayArea[i];
						y1 = arrayArea[i];
						y2 = arrayArea[i + 1];
					}
				}

				//desenho do quadrado à volta do sinal
				if(nChan == 3) { // imagem em RGB
					for(y = 0; y < height; y++) {
						for(x = 0; x < width; x++) {

							if((x >= x1 - thickness && y >= y2 && y <= y2 + thickness && x <= x2 + thickness) ||
								(x >= x2 && x <= x2 + thickness && y <= y2 && y >= y1) ||
								(y >= y1 - thickness && y <= y1 && x >= x1 - thickness && x <= x2 + thickness) ||
								(x >= x1 - thickness && x <= x1 && y <= y2 && y >= y1)) {

								// guarda na imagem
								dataPtrOriginal[0] = 255; //blue
								dataPtrOriginal[1] = 255; //green
								dataPtrOriginal[2] = 0; //red
							}

							// avança apontador para próximo pixel
							dataPtrOriginal += nChan;
						}

						//no fim da linha avança alinhamento (padding)
						dataPtrOriginal += padding;
					}
				}
				MF.ImageViewer.Image = imgOriginal.Bitmap;
				int[] image = new int[] { x1, x2, y1, y2 };
				return image;
			}
		}

		/// <summary>
		/// Detecção de sinal de trânsito azuis
		/// Manipulação Imagem - Acesso directo à memoria
		/// </summary>
		/// <param name="img">imagem</param>
		/// <param name="MF">MainFrom</param>
		/// <param name="DataBase">Base de dados de imagens</param>
		/// <param name="NamesDataBase">Nomes referentes aos sinais de trânsito</param>
		internal static void BlueSignDetection(Image<Bgr, byte> img, MainForm MF, List<Image<Bgr, byte>> DataBase, List<string> NamesDataBase) {
			unsafe
			{
				// acesso directo à memoria da imagem (sequencial)
				// direcção top left -> bottom right

				//definição de um tamanho standard
				int width = 111;
				int height = 111;
				int x, y, i = 0;
				int nChan;
				int padding;
				int[] coordenates = BlueDetection(img, MF);

				//diferença entre azul e verde
				float diff = 0.2f;
				//diferença entre verde e vermelho
				float diff2 = 0.1f;

				//verificação se alguma coisa foi encontrada
				if(coordenates[0] != 0 || coordenates[1] != 0 || coordenates[2] != 0 || coordenates[3] != 0) {

					//copiar só o sinal da imagem original
					Image<Bgr, byte> imgSelected = img.Copy(new System.Drawing.Rectangle(coordenates[0], coordenates[2], (coordenates[1] - coordenates[0]), (coordenates[3] - coordenates[2])));

					//redimensionar para o tamanho standard
					Image<Bgr, byte> imgResized = imgSelected.Resize(width, height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

					//apontador para a nova imagem redimensionada
					MIplImage m = imgResized.MIplImage;
					byte* dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

					nChan = m.nChannels; // numero de canais 3
					padding = m.widthStep - m.nChannels * m.width; // alinhamento (padding)

					//tudo o que estiver fora do sinal, é retirado (do lado esquerdo)
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								//se azul, avança para a linha seguinte
								if((((float)dataPtr[1] / 255 <= (float)dataPtr[0] / 255 - diff) && (((float)dataPtr[2] / 255 <= (float)dataPtr[1] / 255 - diff2)))) {
									dataPtr = dataPtr + (width - x) * nChan;
									break;
								}

								dataPtr[2] = 255;
								dataPtr[1] = 255;
								dataPtr[0] = 255;

								// avança apontador para próximo pixel
								dataPtr += nChan;
							}
							//no fim da linha avança alinhamento (padding)
							dataPtr += padding;
						}
					}

					//reinicializar o apontador
					dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

					byte* auxPtr;

					//tudo o que estiver fora do sinal, é retirado (do lado direito)
					for(y = 0; y < height; y++) {
						for(x = width - 1; x >= 0; x--) {

							auxPtr = (dataPtr + y * m.widthStep + x * nChan);

							if((((float)auxPtr[1] / 255 <= (float)auxPtr[0] / 255 - diff) && (((float)auxPtr[2] / 255 <= (float)auxPtr[1] / 255 - diff2)))) {
								break;
							}

							auxPtr[2] = 255;
							auxPtr[1] = 255;
							auxPtr[0] = 255;
						}
					}

					//converte qualquer azul para azul puro e qualquer "preto" para preto puro
					if(nChan == 3) { // imagem em RGB
						for(y = 0; y < height; y++) {
							for(x = 0; x < width; x++) {

								if((((float)dataPtr[1] / 255 <= (float)dataPtr[0] / 255 - diff) && (((float)dataPtr[2] / 255 <= (float)dataPtr[1] / 255 - diff2)))) {
									dataPtr[2] = 0;
									dataPtr[1] = 0;
									dataPtr[0] = 255;
								} else {
									if((float)dataPtr[0] / 255 <= 0.15 && (float)dataPtr[1] / 255 <= 0.15 && (float)dataPtr[2] / 255 <= 0.15) {
										dataPtr[2] = 0;
										dataPtr[1] = 0;
										dataPtr[0] = 0;
									} else {
										dataPtr[2] = 255;
										dataPtr[1] = 255;
										dataPtr[0] = 255;
									}
								}

								// avança apontador para próximo pixel
								dataPtr += nChan;
							}
							//no fim da linha avança alinhamento (padding)
							dataPtr += padding;
						}
					}

					int total = 0;
					int nameIndex = 0;
					float total_percentage;
					float percentage = 0;
					Image<Bgr, byte> imgShow = null;
					Image<Bgr, byte> temp = null;

					//amount of pixels
					int pixel_area = width * height;

					//por cada imagem na base de dados
					foreach(Image<Bgr, byte> imgDBGet in DataBase) {

						//redimensionar a imagem para o tamanho standard
						Image<Bgr, byte> imgDB = imgDBGet.Resize(width, height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

						//obter uma copia da imagem para depois ser mostrada
						temp = imgDBGet.Copy();

						//criar apontador para a imagem
						MIplImage n = imgDB.MIplImage;
						byte* dataPtrDB = (byte*)n.imageData.ToPointer(); // obter apontador do inicio da imagem

						//reinicializar o apontador para a imagem a analisar
						m = imgResized.MIplImage;
						dataPtr = (byte*)m.imageData.ToPointer(); // obter apontador do inicio da imagem

						nChan = n.nChannels; // numero de canais 3
						padding = n.widthStep - n.nChannels * n.width; // alinhamento (padding)

						//converte qualquer azul para azul puro e qualquer "preto" para preto puro
						if(nChan == 3) { // imagem em RGB
							for(y = 0; y < height; y++) {
								for(x = 0; x < width; x++) {

									//se for azul
									if((((float)dataPtrDB[1] / 255 <= (float)dataPtrDB[0] / 255 - diff) && (((float)dataPtrDB[2] / 255 <= (float)dataPtrDB[1] / 255 - diff2)))) {
										dataPtrDB[2] = 0;
										dataPtrDB[1] = 0;
										dataPtrDB[0] = 255;
									} else {
										//se for preto
										if((float)dataPtrDB[0] / 255 <= 0.1 && (float)dataPtrDB[1] / 255 <= 0.1 && (float)dataPtrDB[2] / 255 <= 0.1) {
											dataPtrDB[2] = 0;
											dataPtrDB[1] = 0;
											dataPtrDB[0] = 0;
										} else {
											dataPtrDB[2] = 255;
											dataPtrDB[1] = 255;
											dataPtrDB[0] = 255;
										}
									}

									// avança apontador para próximo pixel
									dataPtrDB += nChan;
								}
								//no fim da linha avança alinhamento (padding)
								dataPtrDB += padding;
							}
						}

						//reinicializar o apontador da imagem da base de dados
						dataPtrDB = (byte*)n.imageData.ToPointer(); // obter apontador do inicio da imagem

						//compara pixel a pixel para determinar a "igualdade" das imagens
						if(nChan == 3) { // imagem em RGB
							for(y = 0; y < height; y++) {
								for(x = 0; x < width; x++) {

									total = ((dataPtr[0] == dataPtrDB[0] && dataPtr[1] == dataPtrDB[1] && dataPtr[2] == dataPtrDB[2]) ? total + 1 : total);

									// avança apontador para próximo pixel
									dataPtr += nChan;
									dataPtrDB += nChan;
								}

								//no fim da linha avança alinhamento (padding)
								dataPtr += padding;
								dataPtrDB += padding;
							}
						}
						total_percentage = ((float)total / pixel_area);
						total = 0;

						//guarda o sinal com maior percentagem
						if(total_percentage > percentage) {
							percentage = total_percentage;
							nameIndex = i;
							imgShow = temp.Resize(width, height, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
						}
						i++;
					}

					//apresenta o caso mais provavel do sinal
					Identified form = new Identified();
					form.Probability.Text = percentage.ToString("p2");
					form.NameSign.Text = NamesDataBase[nameIndex].ToString();
					form.IdentifiedViewer.Image = imgShow.Bitmap;
					form.ShowDialog();
				} else {
					ImageNotFound form = new ImageNotFound();
					form.ShowDialog();
				}
			}
		}

	}
}
